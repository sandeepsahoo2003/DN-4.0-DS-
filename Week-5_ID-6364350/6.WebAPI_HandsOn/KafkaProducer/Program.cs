using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace KafkaProducer
{
    class Program
    {
        private const string BootstrapServers = "localhost:9092";
        private const string TopicName = "chat-messages";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Kafka Producer - Chat Application");
            Console.WriteLine("Type messages to send (type 'exit' to quit):");

            var config = new ProducerConfig
            {
                BootstrapServers = BootstrapServers,
                ClientId = "chat-producer"
            };

            using var producer = new ProducerBuilder<string, string>(config).Build();

            while (true)
            {
                Console.Write("Enter message: ");
                var message = Console.ReadLine();

                if (message?.ToLower() == "exit")
                    break;

                if (!string.IsNullOrEmpty(message))
                {
                    try
                    {
                        var kafkaMessage = new Message<string, string>
                        {
                            Key = Guid.NewGuid().ToString(),
                            Value = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}"
                        };

                        var deliveryResult = await producer.ProduceAsync(TopicName, kafkaMessage);
                        Console.WriteLine($"Message sent to partition {deliveryResult.Partition} at offset {deliveryResult.Offset}");
                    }
                    catch (ProduceException<string, string> ex)
                    {
                        Console.WriteLine($"Error producing message: {ex.Error.Reason}");
                    }
                }
            }

            producer.Flush(TimeSpan.FromSeconds(10));
            Console.WriteLine("Producer shutting down...");
        }
    }
}
