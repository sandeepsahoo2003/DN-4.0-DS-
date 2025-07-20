# Kafka Integration with C# - Complete Guide

## Table of Contents
1. [Introduction to Kafka](#introduction-to-kafka)
2. [Kafka Architecture](#kafka-architecture)
3. [Installation Guide](#installation-guide)
4. [Demo Applications](#demo-applications)
5. [Running the Applications](#running-the-applications)

## Introduction to Kafka

Apache Kafka is a distributed streaming platform that is used for building real-time data pipelines and streaming applications. It is horizontally scalable, fault-tolerant, and incredibly fast.

### Key Features:
- **High Throughput**: Handle thousands of messages per second
- **Scalability**: Easily scale horizontally
- **Durability**: Messages are persisted on disk
- **Fault Tolerance**: Replicated across multiple brokers

## Kafka Architecture

### Core Components:

#### 1. **Topics**
- Logical channels where messages are published
- Similar to tables in a database
- Messages in topics are ordered and immutable

#### 2. **Partitions**
- Topics are divided into partitions for scalability
- Each partition is an ordered, immutable sequence of messages
- Messages within a partition are ordered by offset

#### 3. **Brokers**
- Kafka servers that store and serve data
- A Kafka cluster consists of multiple brokers
- Each broker can handle thousands of reads/writes per second

#### 4. **Producers**
- Applications that publish messages to topics
- Can choose which partition to send messages to

#### 5. **Consumers**
- Applications that read messages from topics
- Can be part of consumer groups for load balancing

#### 6. **Zookeeper**
- Manages and coordinates Kafka brokers
- Stores metadata about topics, partitions, and brokers
- Handles leader election for partitions

## Installation Guide

### Prerequisites
1. Java 8 or higher
2. .NET 6.0 or higher
3. Visual Studio or VS Code

### Step 1: Install Kafka
1. Download Kafka from [Apache Kafka Downloads](https://kafka.apache.org/downloads)
2. Extract to a directory (e.g., `C:\kafka`)
3. Add Kafka bin directory to PATH

### Step 2: Start Zookeeper
\`\`\`bash
# Windows
bin\windows\zookeeper-server-start.bat config\zookeeper.properties

# Linux/Mac
bin/zookeeper-server-start.sh config/zookeeper.properties
\`\`\`

### Step 3: Start Kafka Server
\`\`\`bash
# Windows
bin\windows\kafka-server-start.bat config\server.properties

# Linux/Mac
bin/kafka-server-start.sh config/server.properties
\`\`\`

### Step 4: Create Topic
\`\`\`bash
# Create chat-messages topic
bin\windows\kafka-topics.bat --create --topic chat-messages --bootstrap-server localhost:9092 --partitions 3 --replication-factor 1
\`\`\`

### Step 5: Install NuGet Package
\`\`\`xml
<PackageReference Include="Confluent.Kafka" Version="2.3.0" />
\`\`\`

## Demo Applications

This project includes three demo applications:

### 1. Console Chat Application
- **KafkaProducer**: Console app for sending messages
- **KafkaConsumer**: Console app for receiving messages

### 2. Windows Forms Chat Application
- **ChatApplication**: WPF GUI application with real-time messaging

### 3. Kafka Configuration Service
- **KafkaService**: Utility class for managing topics

## Running the Applications

### Demo 1: Console Chat Application

1. **Start the Consumer**:
   \`\`\`bash
   cd KafkaConsumer
   dotnet run
   \`\`\`

2. **Start the Producer**:
   \`\`\`bash
   cd KafkaProducer
   dotnet run
   \`\`\`

3. **Send Messages**:
   - Type messages in the producer console
   - See them appear in the consumer console

### Demo 2: Windows Chat Application

1. **Build and Run**:
   \`\`\`bash
   cd ChatApplication
   dotnet run
   \`\`\`

2. **Multiple Clients**:
   - Run multiple instances of the application
   - Messages sent from one client appear in all others

## Key Concepts Demonstrated

### Producer Configuration
```csharp
var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092",
    ClientId = "my-producer"
};
