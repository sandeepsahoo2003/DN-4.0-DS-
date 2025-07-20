-- This is a reference script for Kafka topic management
-- Note: Kafka uses command-line tools, not SQL, but this shows the equivalent operations

-- Create Topic (equivalent Kafka command)
-- kafka-topics.bat --create --topic chat-messages --bootstrap-server localhost:9092 --partitions 3 --replication-factor 1

-- List Topics (equivalent Kafka command)
-- kafka-topics.bat --list --bootstrap-server localhost:9092

-- Describe Topic (equivalent Kafka command)
-- kafka-topics.bat --describe --topic chat-messages --bootstrap-server localhost:9092

-- Delete Topic (equivalent Kafka command)
-- kafka-topics.bat --delete --topic chat-messages --bootstrap-server localhost:9092

-- Consumer Group Management
-- kafka-consumer-groups.bat --bootstrap-server localhost:9092 --list
-- kafka-consumer-groups.bat --bootstrap-server localhost:9092 --describe --group chat-consumer-group
