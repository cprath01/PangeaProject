using MQConsumerService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL.Interfaces
{
    public interface IRepoDAL_Save
    {
        void Save(List<Repos> repos);
    }
}
