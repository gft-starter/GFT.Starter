using GFT.Starter.Infrastructure.ServiceBus;
using GFT.Starter.Infrastructure.ServiceBus.Contracts;
using GFT.Starter.Infrastructure.ServiceBus.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceBusTests
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
            "Endpoint=sb://faisca.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Vs5ELctE44nRBA7W3EmVJgZgHy12dH/rWmQJcBhFa6s=";

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
