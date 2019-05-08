using System;
using System.Collections.Generic;
using System.Text;
using GFT.Starter.Infrastructure.ServiceBus.Contracts;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Management;
using Microsoft.Extensions.DependencyInjection;

namespace GFT.Starter.Infrastructure.ServiceBus.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServiceBus(this IServiceCollection services, IServiceBusSettings settings)
        {
            var managementClient = new ManagementClient(settings.ConnectionString);
            IServiceBusManagementClient serviceBusManagementClient = new ServiceBusManagementClient(managementClient);
            services.AddSingleton(managementClient);
            services.AddSingleton(serviceBusManagementClient);
            services.AddSingleton<IQueueClient>(new QueueClient(settings.ConnectionString, settings.QueueName));
            services.AddSingleton<ITopicClient>(new TopicClient(settings.ConnectionString, settings.TopicName));
            services.AddSingleton<ISubscriptionClient>(new SubscriptionClient(settings.ConnectionString, settings.TopicName, settings.SubscriptionName));

            serviceBusManagementClient.CreateQueue(settings.QueueName).wait();
            serviceBusManagementClient.CreateTopic(settings.TopicName).wait();
            serviceBusManagementClient.CreateSubscription(settings.TopicName, settings.SubscriptionName).wait();


            return services;
        }
    }
}
