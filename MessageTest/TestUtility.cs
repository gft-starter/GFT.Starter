﻿using Infrastructure.SeviceBus;
using Infrastructure.SeviceBus.Contracts;
using Infrastructure.SeviceBus.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MessageTest
{
    public class SampleMessage
    {
        public SampleMessage(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    public class SampleMessage2
    {
        public SampleMessage2(string message2)
        {
            Message2 = message2;
        }

        public string Message2 { get; set; }
    }

    internal static class TestUtility
    {
        private const string ServiceBusConnectionString =
            "Endpoint=sb://aera-latavelha.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SP9E8ZEHEL5R3MjFtmQbJDASOdbd05cv90m7Y3KyLWU=";

        private const string QueueName = "TestQueue";
        private const string TopicName = "TestTopic";
        private const string SubscriptionName = "Test";
        public static readonly IServiceBusClient Client;
        private static readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
        private static readonly CancellationToken Token = CancellationTokenSource.Token;

        static TestUtility()
        {
            IServiceProvider serviceProvider = new ServiceCollection()
                .ConfigureServiceBus(new ServiceBusSettings(ServiceBusConnectionString, QueueName, TopicName,
                    SubscriptionName, new List<Type> { typeof(SampleMessage) }))
                .BuildServiceProvider();


            Client = serviceProvider.GetService<IServiceBusClient>();
            ManagementClient = serviceProvider.GetService<IServiceBusManagementClient>();
        }

        public static IServiceBusManagementClient ManagementClient { get; set; }

        internal static async Task WaitForCallback(Action action, int timeoutInSeconds = -1)
        {
            try
            {
                action();
                await Task.Delay(timeoutInSeconds, Token);
            }
            catch (TaskCanceledException)
            {
            }
        }

        internal static void CompleteTest()
        {
            CancellationTokenSource.Cancel(false);
        }

        internal static async Task ResetSubscription()
        {
            await ManagementClient.DeleteSubscription(TopicName, SubscriptionName);
            await ManagementClient.CreateSubscription(TopicName, SubscriptionName,
                new List<Type> { typeof(SampleMessage) });
        }
    }
}