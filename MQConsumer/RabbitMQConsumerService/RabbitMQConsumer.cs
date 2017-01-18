using System.IO;
using System.Text;
using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQConsumerService.Interfaces;
using Microsoft.Practices.Unity;

namespace RabbitMQConsumerService
{
    public class RabbitMQConsumer
    {
        private IMQClientWrapper _MQClient;
        private IMessageProcessorFactory _MessageProcessorFactory;
        public RabbitMQConsumer(IUnityContainer container):this(container.Resolve<IMQClientWrapper>(),container.Resolve<IMessageProcessorFactory>()) { }
        public RabbitMQConsumer(IMQClientWrapper MQClient, IMessageProcessorFactory MessageProcessorFactory)
        {
            _MQClient = MQClient;
            _MessageProcessorFactory = MessageProcessorFactory;
        }

        public void Start() { _MQClient.Consume(_MessageProcessorFactory); }

        public void Stop() { _MQClient.StopConsume(); }
    }

    public class RabbitMQClient : IMQClientWrapper
    {
        private string _HostName;
        private string _QueueName;
        private bool _Durable;
        private bool _Exclusive;
        private bool _AutoDelete;
        private string _Exchange;
        private string _RoutingKey;
        private IBasicProperties _BasicProperties;
        private IMessageProcessorFactory _MessageProcessorFactory;
        private EventingBasicConsumer _Consumer;
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        public RabbitMQClient()
        {
            //TODO: Move this to a configuration file
            _HostName = "localhost";
            _QueueName = "local";
            _Durable = true;
            _Exclusive = false;
            _AutoDelete = false;
            _Exchange = "";
            _RoutingKey = "local";
            _BasicProperties = null;
        }
        

        public void Consume(IMessageProcessorFactory MessageProcessorFactory)
        {
            try
            {
                _MessageProcessorFactory = MessageProcessorFactory;
                _factory = new ConnectionFactory() { HostName = _HostName };
                _connection = _factory.CreateConnection();
                _channel = _connection.CreateModel();
                {
                    _channel.QueueDeclare(queue: _QueueName,
                                         durable: _Durable,
                                         exclusive: _Exclusive,
                                         autoDelete: _AutoDelete,
                                         arguments: null);

                    _Consumer = new EventingBasicConsumer(_channel);
                    _Consumer.Received += Message_Received;
                    _channel.BasicConsume(queue: _QueueName,
                                 noAck: true,
                                 consumer: _Consumer);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void StopConsume()
        {
            _Consumer.Received -= Message_Received;
            _channel.Dispose();
            _connection.Dispose();
            _Consumer = null;
            _channel = null;
            _connection = null;
            _factory = null;
        }

        public void Message_Received(object sender, BasicDeliverEventArgs e)
        {
            var processor = _MessageProcessorFactory.CreateProcessor();
            processor.ProcessMessage(Encoding.UTF8.GetString(e.Body));
        }
        
    }
}