﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace GFT.Starter.Infrastructure.ServiceBus.Contracts
{
    public interface IServiceBusManagementClient
    {
        Task CreateQueue(string queueName);
        Task DeleteQueue(string queueName);
        Task CreateTopic(string topicName);
        Task DeleteTopic(string topicName);
        Task CreateSubscription(string topicName, string subscriptionName, IEnumerable<Type> filters = null);
        Task DeleteSubscription(string topicName, string subscriptionName);
    }
}