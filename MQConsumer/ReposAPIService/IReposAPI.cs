using MQConsumerService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposAPIService
{
    public interface IReposAPI
    {
        Task<List<Repos>> Get(string repoList = null);
    }
}
