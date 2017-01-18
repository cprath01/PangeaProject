using MQConsumerService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepoCopyConverter
    {
        IEnumerable<RepoCopy> convert(IEnumerable<Repos> source);
        RepoCopy convert(Repos source);
    }
}
