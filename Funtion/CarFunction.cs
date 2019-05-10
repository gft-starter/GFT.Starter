using Core.Models.Commands;
using Core.Models.Events;
using Function.IoC;
using Infrastructure.SeviceBus.Contracts;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Function
{
    public static class CarFunction
    {
        [FunctionName("CreateCarFunction")]
        public static void CreateCar([ServiceBusTrigger("%ServiceBusQueueName%", Connection = "ServiceBusConnectionString")]string createCar, ILogger log, [Inject]IServiceBusClient busClient)
        {
            var car = JsonConvert.DeserializeObject<CreateCar>(createCar);
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
