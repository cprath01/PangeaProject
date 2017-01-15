using System;
using Xunit;
using PangeaProject.Controllers;
using PangeaProject.Queues;
using Moq;
using PangeaProject.Queues.RabbitMQ.Interfaces;

namespace PangeaProject.Test
{
    public class LoadDataController_Tests
    {
        [Fact]
        public void Get_Blank_Value_Test() 
        {
            string actualMessage = "";
            var mockMQClientWrapper = new Mock<IMQClientWrapper>();
            mockMQClientWrapper.Setup(client => client.Send(It.IsAny<string>())).Callback<string>((s) => actualMessage = s);
            mockMQClientWrapper.Verify(m => m.Send(It.IsAny<string>()), Times.AtMost(1));
            
            var manager = new RabbitMQProducerManager(mockMQClientWrapper.Object, new MQMessageCreator());

            var controller = new LoadDataController(manager);

            var result = controller.Get();

            string expected = "LoadData request has been submitted.";
            Assert.True(result == expected,"Load Data Controller Get method failed.");
        }
    }
}
