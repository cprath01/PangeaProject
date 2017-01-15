using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PangeaProject.Domain.Common.Interfaces;

namespace PangeaProject.Domain.Queues.Interfaces
{
    public interface IMQMessageCreator
    {
        string CreateMessage<T>(string payload) where T : IRequest,new();
    }
}
