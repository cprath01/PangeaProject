using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PangeaProject.Queues.RabbitMQ.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace PangeaProject.Queues.RabbitMQ
{
    public class RabbitMQClient: IMQClientWrapper
    {
        private string _HostName;
        private string _QueueName;
        private bool _Durable;
        private bool _Exclusive;
        private bool _AutoDelete;
        private string _Exchange;
        private string _RoutingKey;
        private IBasicProperties _BasicProperties;

        public RabbitMQClient(string HostName = "localhost", string QueueName = "local", bool Durable = true, bool Exclusive = false, bool AutoDelete = false, string Exchange = "", string RoutingKey = "local", IBasicProperties BasicProperties = null)
        {
            _HostName = HostName;
            _QueueName = QueueName;
            _Durable = Durable;
            _Exclusive = Exclusive;
            _AutoDelete = AutoDelete;
            _Exchange = Exchange;
            _RoutingKey = RoutingKey;
            _BasicProperties = BasicProperties;
        }

        public void Send(string message)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = _HostName };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _QueueName,
                                         durable: _Durable,
                                         exclusive: _Exclusive,
                                         autoDelete: _AutoDelete,
                                         arguments: null);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: _Exchange,
                                         routingKey: _RoutingKey,
                                         basicProperties: _BasicProperties,
                                         body: body);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
