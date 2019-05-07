using System.Threading.Tasks;
using GFT.Starter.Infrastructure.ServiceBus;
using Xunit;

namespace GFT.Starter.Tests
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