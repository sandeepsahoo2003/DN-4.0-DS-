using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaConfiguration
{
    public class KafkaService
    {
        private readonly string _bootstrapServers;
        
        public KafkaService(string bootstrapServers = "localhost:9092")
        {
            _bootstrapServers = bootstrapServers;
        }

        public async Task CreateTopicAsync(string topicName, int numPartitions = 1, short replicationFactor = 1)
        {
            using var adminClient = new AdminClientBuilder(new AdminClientConfig
            {
                BootstrapServers = _bootstrapServers
            }).Build();

            try
            {
                await adminClient.CreateTopicsAsync(new[]
                {
                    new TopicSpecification
                    {
                        Name = topicName,
                        NumPartitions = numPartitions,
                        ReplicationFactor = replicationFactor
                    }
                });
                
                Console.WriteLine($"Topic '{topicName}' created successfully.");
            }
            catch (CreateTopicsException ex)
            {
                Console.WriteLine($"Error creating topic: {ex.Results[0].Error.Reason}");
            }
        }

        public async Task<List<string>> ListTopicsAsync()
        {
            using var adminClient = new AdminClientBuilder(new AdminClientConfig
            {
                BootstrapServers = _bootstrapServers
            }).Build();

            var metadata = adminClient.GetMetadata(TimeSpan.FromSeconds(10));
            var topics = new List<string>();
            
            foreach (var topic in metadata.Topics)
            {
                topics.Add(topic.Topic);
            }
            
            return topics;
        }

        public async Task DeleteTopicAsync(string topicName)
        {
            using var adminClient = new AdminClientBuilder(new AdminClientConfig
            {
                BootstrapServers = _bootstrapServers
            }).Build();

            try
            {
                await adminClient.DeleteTopicsAsync(new[] { topicName });
                Console.WriteLine($"Topic '{topicName}' deleted successfully.");
            }
            catch (DeleteTopicsException ex)
            {
                Console.WriteLine($"Error deleting topic: {ex.Results[0].Error.Reason}");
            }
        }
    }
}
