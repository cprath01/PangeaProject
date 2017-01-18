using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMQConsumerService;
using Moq;
using RabbitMQConsumerService.Interfaces;
using RabbitMQ;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQConsumerService.Tests
{
    [TestClass]
    public class RabbitMQConsumer_Tests
    {
        [TestMethod]
        public void RabbitMQConsumer_Start_Test()
        {
            //This test needs work. It is not checking the IMQClientWrapper can handle events from the RabbitMQ Consumer
            try
            {
                var mockClient = new Mock<IMQClientWrapper>();
                mockClient.Setup(client => client.Message_Received(It.IsAny<object>(), It.IsAny<BasicDeliverEventArgs>()));
                mockClient.Setup(client => client.Consume(It.IsAny<IMessageProcessorFactory>()));
                var objectBeingTested = new RabbitMQConsumer(mockClient.Object, null);

                objectBeingTested.Start();

                mockClient.Verify(client => client.Consume(It.IsAny<IMessageProcessorFactory>()), Times.AtMostOnce());
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail("Not All Verify conditions where meet.");
            }
        }
    }
}
