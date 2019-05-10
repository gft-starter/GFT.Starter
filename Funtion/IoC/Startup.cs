using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.WebJobs.Host;
using Infrastructure.SeviceBus;
using Infrastructure.SeviceBus.IoC;

namespace Function.IoC
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var serviceCollection = builder.Services;
            serviceCollection.AddSingleton<IConfiguration>(configuration);

            //Registering a filter
            serviceCollection.AddSingleton<IFunctionFilter, ScopeCleanupFilter>();

            serviceCollection.AddSingleton(new InjectBindingProvider(serviceCollection));

            builder.AddExtension<InjectConfiguration>();

            ConfigureServices(builder.Services, configuration);
        }


        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureServiceBus(new ServiceBusSettings(
                configuration["ServiceBusConnectionString"], configuration["ServiceBusQueueName"],
                configuration["ServiceBusTopicName"], configuration["ServiceBusSubscriptionName"]));
        }
    }
}
