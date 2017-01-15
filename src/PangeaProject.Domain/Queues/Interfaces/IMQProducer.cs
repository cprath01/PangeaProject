using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PangeaProject.Domain.Common.Interfaces;

namespace PangeaProject.Domain.Queues.Interfaces
{
    public interface IMQProducer
    {
        bool DropMessage<T>(string message, object QueueHeader = null) where T : IRequest, new();
    }
}
