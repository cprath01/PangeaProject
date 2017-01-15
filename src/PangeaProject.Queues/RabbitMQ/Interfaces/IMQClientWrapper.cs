using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PangeaProject.Queues.RabbitMQ.Interfaces
{
    public interface IMQClientWrapper
    {
        void Send(string message);
    }
}
