using System.IO;
using System.Text;
using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using MQConsumer.Interfaces;

namespace MQConsumer
{
    internal class RabbitMQConsumer
    {
        private IMQClientWrapper _MQClient;
        public RabbitMQConsumer(IMQClientWrapper MQClient)
        {
            _MQClient = MQClient;
        }

        public void Start() { _MQClient.Consume(); }

        public void Stop() { }
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
        private IMessageProcessor _MessageProcessor;
        private EventingBasicConsumer _Consumer;
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        public RabbitMQClient(IMessageProcessor MessageProcessor, string HostName = "localhost", string QueueName = "local", bool Durable = true, bool Exclusive = false, bool AutoDelete = false, string Exchange = "", string RoutingKey = "local", IBasicProperties BasicProperties = null)
        {
            _HostName = HostName;
            _QueueName = QueueName;
            _Durable = Durable;
            _Exclusive = Exclusive;
            _AutoDelete = AutoDelete;
            _Exchange = Exchange;
            _RoutingKey = RoutingKey;
            _BasicProperties = BasicProperties;
            _MessageProcessor = MessageProcessor;
        }

        public void Consume()
        {
            try
            {
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

        private void Message_Received(object sender, BasicDeliverEventArgs e)
        {
            _MessageProcessor.ProcessMessage(Encoding.UTF8.GetString(e.Body));
        }
    }
}