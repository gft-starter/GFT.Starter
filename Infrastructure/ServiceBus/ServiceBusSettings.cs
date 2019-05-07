using System;
using System.Collections.Generic;
using GFT.Starter.Infrastructure.ServiceBus.Contracts;

namespace GFT.Starter.Infrastructure.ServiceBus
{
    public class ServiceBusSettings : IServiceBusSettings
    {
        public ServiceBusSettings(string connectionString, string queueName, string topicName, string subscriptionName, IEnumerable<Type> filters = null)
        {
            ConnectionString = connectionString;
            QueueName = queueName;
            TopicName = topicName;
            SubscriptionName = subscriptionName;
            Filters = filters ?? new List<Type>();
        }

        public string ConnectionString { get; }
        public string QueueName { get; }
        public string TopicName { get; }
        public string SubscriptionName { get; }
        public IEnumerable<Type> Filters { get; }
    }
}