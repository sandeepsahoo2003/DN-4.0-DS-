using Confluent.Kafka;
using System;
using System.Threading;

namespace KafkaConsumer
{
    class Program
    {
        private const string BootstrapServers = "localhost:9092";
        private const string TopicName = "chat-messages";
        private const string GroupId = "chat-consumer-group";

        static void Main(string[] args)
        {
            Console.WriteLine("Kafka Consumer - Chat Message Receiver");
            Console.WriteLine("Listening for messages... (Press Ctrl+C to exit)");

            var config = new ConsumerConfig
            {
                BootstrapServers = BootstrapServers,
                GroupId = GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true
            };

            using var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe(TopicName);

            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(cts.Token);
                        Console.WriteLine($"Received: {consumeResult.Message.Value}");
                        Console.WriteLine($"Key: {consumeResult.Message.Key}, Partition: {consumeResult.Partition}, Offset: {consumeResult.Offset}");
                        Console.WriteLine(new string('-', 50));
                    }
                    catch (ConsumeException ex)
                    {
                        Console.WriteLine($"Error consuming message: {ex.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Consumer cancelled.");
            }
            finally
            {
                consumer.Close();
                Console.WriteLine("Consumer closed.");
            }
        }
    }
}
