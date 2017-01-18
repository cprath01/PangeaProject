using Microsoft.Practices.Unity;
using RabbitMQConsumerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsumerService
{
    public class MessageProcessorFactory : IMessageProcessorFactory
    {
        private IUnityContainer _container;

        public MessageProcessorFactory(IUnityContainer continer)
        {
            _container = continer;
        }
        public IMessageProcessor CreateProcessor()
        {
            return _container.Resolve<IMessageProcessor>();
        }
    }
}
