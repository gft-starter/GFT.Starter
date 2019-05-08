using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace Function
{
    public static class CarFunction
    {
        [FunctionName("CreateCarFunction")]
        public static void CreateCar([ServiceBusTrigger("myqueue", Connection = "")]string myQueueItem, TraceWriter log)
        {
            log.Info($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
