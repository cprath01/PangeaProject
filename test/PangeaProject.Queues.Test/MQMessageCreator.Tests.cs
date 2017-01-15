using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using PangeaProject.Domain.LoadData;
using System.Text.RegularExpressions;

namespace PangeaProject.Queues.Test
{
    public class MQMessageCreator_Tests
    {
        [Fact]
        public void CreateMessage_Test()
        {
            var objectBeingTested = new MQMessageCreator();

            var actual = objectBeingTested.CreateMessage<LoadDataRequest>("Test Message");
            
            //Have to use Regex to check because of a GUID and timestamp are different everytime.
            var expected = "<" + Regex.Escape("?") + "xml version=\"1.0\" encoding=\"utf-16\"" + Regex.Escape("?") + ">\r\n<LoadDataRequest xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Header>\r\n    <RequestID>[a-zA-Z0-9]+-[a-zA-Z0-9]+-[a-zA-Z0-9]+-[a-zA-Z0-9]+-[a-zA-Z0-9]+</RequestID>\r\n    <Request_TimeStamp>[0-9]{4}-[0-9]{2}-[0-9]{2}T[0-9]{2}:[0-9]{2}:[0-9]{2}.[0-9]+-[0-9]{2}:[0-9]{2}</Request_TimeStamp>\r\n    <Request_Type>Load</Request_Type>\r\n  </Header>\r\n  <Payload>Test Message</Payload>\r\n</LoadDataRequest>";

            var regex = new Regex(expected);
            Assert.True(regex.IsMatch(actual),"Wrong xml format");
        }
    }
}
