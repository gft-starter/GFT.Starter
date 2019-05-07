using System;
using System.Collections.Generic;

namespace GFT.Starter.Infrastructure.ServiceBus.Contracts
{
    public interface IServiceBusSettings
    {
        string ConnectionString { get; }
        string QueueName { get; }
        string SubscriptionName { get; }
        string TopicName { get; }
        IEnumerable<Type> Filters { get; }
    }
}