using GFT.Starter.Infrastructure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServiceBusTests
{
    public class QueueTests
    {
        private const string SendToQueueMessageText = "SendToQueueTest";
        private const string ReceiveFromQueueMessageText = "ReceiveFromQueueTest";

        [Fact]
        public async Task ReceiveMessageFromQueueShouldMatchSentMessage()
        {
            await TestUtility.Client.SendMessageToQueue(new SampleMessage(ReceiveFromQueueMessageText));
            await TestUtility.WaitForCallback(async () => await TestUtility.Client.ReceiveMessageFromQueue<SampleMessage>(message =>
            {
                Assert.Equal(ReceiveFromQueueMessageText, message.Message);
                TestUtility.CompleteTest();

                return ServiceBusClient.MessageProcessResponse.Complete;
            }));
        }

        [Fact]
        public void SendMessageToQueueShouldNotThrowException()
        {
            TestUtility.Client.SendMessageToQueue(new SampleMessage(SendToQueueMessageText));
        }
    }
}
