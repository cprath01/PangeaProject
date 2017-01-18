using Domain.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsumerService.Interfaces
{
    public interface IMessageProcessor
    {
        void ProcessMessage(string message);
    }
}
