using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Infrastructure.ServiceBus.Contracts
{
   public  interface IServiceBusSettings
    {
        string ConnectionString { get; }
        string QueueName { get; }
        string SubscriptionName { get; }
        string TopicName { get; }
        IList<Type> Filters { get; }
    }
}
