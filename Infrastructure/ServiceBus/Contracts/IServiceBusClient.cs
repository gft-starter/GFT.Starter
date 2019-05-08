using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Infrastructure.ServiceBus.Contracts
{
   public class IServiceBusClient
    {
        Task PublishMessageToTopic<T>(T message, Dictionary<string, object> propoerties = null);
        Task ReceiveMessageFromQueue<T>(Func<T, ServiceBusClient.MessageProcessResponse> onProcess);
        Task ReceiveMessageFromTopic<T>(Func<T, ServiceBusClient.MessageProfessResponse> onProcess);
        Task SendMessageToQueue<T>(T message, Dictionary<string, object> properties = null);
    }
}
