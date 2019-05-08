using GFT.Starter.Core.Models.Commands;
using GFT.Starter.Core.Models.Events;
using GFT.Starter.Function.IoC;
using GFT.Starter.Infrastructure.ServiceBus.Contracts;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GFT.Starter.Function
{
    public static class CarFunction
    {
        [FunctionName("CreateCarFunction")]
        public static void CreateCar([ServiceBusTrigger("%ServiceBusQueueName%", Connection = "ServiceBusConnectionString")]string createCar, ILogger log, [Inject]IServiceBusClient busClient)
        {
            var car = JsonConvert.DeserializeObject<CreateCar>(createCar);
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {car.Car.Model}");
            busClient.PublishMessageToTopic(new CarCreated(car.Car));
        }

        [FunctionName("CarCreatedFunction")]
        public static void CarCreated([ServiceBusTrigger("%ServiceBusTopicName%", "%ServiceBusSubscriptionName%", Connection = "ServiceBusConnectionString")]string carCreated, ILogger log)
        {
            var car = JsonConvert.DeserializeObject<CarCreated>(carCreated);
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {car.Car.Model}");
        }
    }
}
