using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQConsumer.Interfaces
{
    public interface IMQClientWrapper
    {
        void Consume();
    }
}
