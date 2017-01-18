using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsumerService.Interfaces
{
    public interface IMQClientWrapper
    {
        void Consume(IMessageProcessorFactory MessageProcessorFactory);
        void StopConsume();
        void Message_Received(object sender, BasicDeliverEventArgs e);
    }
}
