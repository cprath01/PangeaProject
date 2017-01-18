using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQConsumer.Interfaces;

namespace MQConsumer
{
    public class MessageProcessor : IMessageProcessor
    {
        public void ProcessMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
