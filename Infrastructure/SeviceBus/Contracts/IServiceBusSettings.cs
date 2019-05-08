using System;
using System.Collections.Generic;

namespace Infrastructure.SeviceBus.Contracts
{
    public interface IServiceBusSettings
    {
        string ConnectionString { get; }
        string QueueName { get; }
        string SubscriptionName { get; }
        string TopicName { get; }
        IList<Type> Filters { get; }
    }
}
