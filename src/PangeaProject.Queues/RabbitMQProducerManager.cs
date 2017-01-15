using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PangeaProject.Domain.Queues.Interfaces;
using PangeaProject.Domain.Common.Interfaces;
using PangeaProject.Queues.RabbitMQ.Interfaces;

namespace PangeaProject.Queues
{
    public class RabbitMQProducerManager : IMQProducer
    {
        IMQClientWrapper client;
        IMQMessageCreator messageCreator;

        public RabbitMQProducerManager(IMQClientWrapper Client, IMQMessageCreator MessageCreator)
        {
            client = Client;
            messageCreator = MessageCreator;
        }

        public bool DropMessage<T>(string message, object QueueHeader = null) where T : IRequest, new()
        {
            try
            {
                client.Send(messageCreator.CreateMessage<T>(message));
            }
            catch (Exception)
            {
                //normally log the error
                return false;
            }
            return true;
        }
    }
}
