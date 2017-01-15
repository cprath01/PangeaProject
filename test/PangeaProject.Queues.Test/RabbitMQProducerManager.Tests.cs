using Xunit;
using Moq;
using PangeaProject.Queues.RabbitMQ.Interfaces;
using PangeaProject.Domain.LoadData;
using System.Text.RegularExpressions;

namespace PangeaProject.Queues.Test
{
    public class RabbitMQProducerManager_Tests
    {
        [Fact]
        public void DropMessageTest()
        {
            string actualMessage = "";
            var mockMQClientWrapper = new Mock<IMQClientWrapper>();
            mockMQClientWrapper.Setup(client => client.Send(It.IsAny<string>())).Callback<string>((s) => actualMessage = s);
            mockMQClientWrapper.Verify(m => m.Send(It.IsAny<string>()), Times.AtMost(1));
            bool expected = true;
            var manager = new RabbitMQProducerManager(mockMQClientWrapper.Object,new MQMessageCreator());

            var actual = manager.DropMessage<LoadDataRequest>("Test Message");

            Assert.True(actual == expected);
            var expectedMessage = "<" + Regex.Escape("?") + "xml version=\"1.0\" encoding=\"utf-16\"" + Regex.Escape("?") + ">\r\n<LoadDataRequest xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Header>\r\n    <RequestID>[a-zA-Z0-9]+-[a-zA-Z0-9]+-[a-zA-Z0-9]+-[a-zA-Z0-9]+-[a-zA-Z0-9]+</RequestID>\r\n    <Request_TimeStamp>[0-9]{4}-[0-9]{2}-[0-9]{2}T[0-9]{2}:[0-9]{2}:[0-9]{2}.[0-9]+-[0-9]{2}:[0-9]{2}</Request_TimeStamp>\r\n    <Request_Type>Load</Request_Type>\r\n  </Header>\r\n  <Payload>Test Message</Payload>\r\n</LoadDataRequest>";

            var regex = new Regex(expectedMessage);
            Assert.True(regex.IsMatch(actualMessage), "Wrong xml format");
        }

        [Fact]
        public void DropMessageTest_exception()
        {
            var manager = new RabbitMQProducerManager(null,new MQMessageCreator());

            var actual = manager.DropMessage<LoadDataRequest>("Test Message");

            Assert.False(actual);
        }
    }
}
