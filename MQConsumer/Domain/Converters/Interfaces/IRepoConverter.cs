using MQConsumerService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQConsumerService.Domain.Common;

namespace Domain.Converters.Interfaces
{
    public interface IRepoConverter
    {
        IEnumerable<Repos> convert(IEnumerable<Repository> source);
        Repos convert(Repository source);
    }
}
