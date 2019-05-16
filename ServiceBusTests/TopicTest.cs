using GFT.Starter.Infrastructure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServiceBusTests
{
    public class TopicTests
    {
        private const string SendToTopicMessageText = "SendToTopicTest";
        private const string ReceiveFromTopicMessageText = "ReceiveFromTopicTest";
        private const string ReceiveFromTopicMessageText2 = "ReceiveFromTopicTest2";

        public TopicTests()
        {
            TestUtility.ResetSubscription().Wait();
        }

        [Fact]
        public async Task ReceiveMessageFromTopicShouldMatchSentMessage()
        {
            await TestUtility.Client.PublishMessageToTopic(new SampleMessage(ReceiveFromTopicMessageText));
            await TestUtility.WaitForCallback(async () => await TestUtility.Client.ReceiveMessageFromTopic<SampleMessage>(message =>
            {
                Assert.Equal(ReceiveFromTopicMessageText, message.Message);
                TestUtility.CompleteTest();

                return ServiceBusClient.MessageProcessResponse.Complete;
            }));
        }

        //[Fact(Skip = "Issues with message timing")]
        [Fact]
        public async Task SendOneFilteredAndOneUnfilteredMessageToTopicShouldReceiveOnlyOneMessage()
        {
            int messageCount = 0;
            await TestUtility.Client.PublishMessageToTopic(new SampleMessage(ReceiveFromTopicMessageText));
            await TestUtility.Client.PublishMessageToTopic(new SampleMessage2(ReceiveFromTopicMessageText2));
            await TestUtility.WaitForCallback(async () => await TestUtility.Client.ReceiveMessageFromTopic<SampleMessage>(message =>
            {
                messageCount++;
                Assert.Equal(ReceiveFromTopicMessageText, message.Message);
                return ServiceBusClient.MessageProcessResponse.Complete;
            }), 20000);

            Assert.True(messageCount > 0);
        }


        [Fact]
        public async Task SendOneUnfilteredMessageToTopicShouldNotReceiveAnyMessages()
        {
            int messageCount = 0;
            await TestUtility.Client.PublishMessageToTopic(new SampleMessage2(ReceiveFromTopicMessageText2));
            await TestUtility.WaitForCallback(async () => await TestUtility.Client.ReceiveMessageFromTopic<SampleMessage>(message =>
            {
                messageCount++;
                return ServiceBusClient.MessageProcessResponse.Complete;
            }), 10000);

            Assert.Equal(0, messageCount);
        }

        [Fact]
        public void SendMessageToTopicShouldNotThrowException()
        {
            TestUtility.Client.PublishMessageToTopic(new SampleMessage(SendToTopicMessageText));
        }
    }
}
