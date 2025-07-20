using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChatApplication
{
    public partial class MainWindow : Window
    {
        private const string BootstrapServers = "localhost:9092";
        private const string TopicName = "chat-messages";
        private const string GroupId = "chat-gui-consumer";

        private IProducer<string, string> _producer;
        private IConsumer<string, string> _consumer;
        private CancellationTokenSource _cancellationTokenSource;
        private Task _consumerTask;

        public MainWindow()
        {
            InitializeComponent();
            InitializeKafka();
            StartConsumer();
        }

        private void InitializeKafka()
        {
            // Producer configuration
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = BootstrapServers,
                ClientId = "chat-gui-producer"
            };
            _producer = new ProducerBuilder<string, string>(producerConfig).Build();

            // Consumer configuration
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = BootstrapServers,
                GroupId = GroupId,
                AutoOffsetReset = AutoOffsetReset.Latest,
                EnableAutoCommit = true
            };
            _consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
            _consumer.Subscribe(TopicName);

            _cancellationTokenSource = new CancellationTokenSource();
        }

        private void StartConsumer()
        {
            _consumerTask = Task.Run(async () =>
            {
                try
                {
                    while (!_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        try
                        {
                            var consumeResult = _consumer.Consume(_cancellationTokenSource.Token);
                            
                            // Update UI on main thread
                            Dispatcher.Invoke(() =>
                            {
                                ChatMessages.Text += $"{consumeResult.Message.Value}\n";
                                
                                // Auto-scroll to bottom
                                var scrollViewer = ChatMessages.Parent as ScrollViewer;
                                scrollViewer?.ScrollToEnd();
                            });
                        }
                        catch (ConsumeException ex)
                        {
                            Dispatcher.Invoke(() =>
                            {
                                StatusText.Text = $"Error: {ex.Error.Reason}";
                            });
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Expected when cancellation is requested
                }
            });
        }

        private async void SendMessage()
        {
            var message = MessageInput.Text.Trim();
            if (string.IsNullOrEmpty(message))
                return;

            try
            {
                var kafkaMessage = new Message<string, string>
                {
                    Key = Environment.MachineName,
                    Value = $"[{DateTime.Now:HH:mm:ss}] {Environment.UserName}: {message}"
                };

                await _producer.ProduceAsync(TopicName, kafkaMessage);
                MessageInput.Text = "";
                StatusText.Text = "Message sent";
            }
            catch (ProduceException<string, string> ex)
            {
                StatusText.Text = $"Error: {ex.Error.Reason}";
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void MessageInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            _consumerTask?.Wait(TimeSpan.FromSeconds(5));
            
            _producer?.Dispose();
            _consumer?.Close();
            _consumer?.Dispose();
            _cancellationTokenSource?.Dispose();
            
            base.OnClosed(e);
        }
    }
}
