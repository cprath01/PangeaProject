using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PangeaProject.Domain.LoadData;
using PangeaProject.Domain.Queues.Interfaces;
using PangeaProject.Domain.Common.Interfaces;
using System.Xml.Serialization;
using System.Text;

namespace PangeaProject.Queues
{
    public class MQMessageCreator : IMQMessageCreator
    {
        public string CreateMessage<T>(string payload) where T : IRequest, new()
        {
            var request = new T();

            request.Header = new Domain.Common.Requests.RequestHeader()
            {
                  RequestID = Guid.NewGuid()
                , Request_TimeStamp = DateTime.Now
                , Request_Type = Common.Enums.RequestType.Load
            };

            request.Payload = payload;


            var serializer = new XmlSerializer(typeof(T));
            var writer = new System.IO.StringWriter();
            serializer.Serialize(writer,request);
            return writer.ToString();
        }
    }
}
