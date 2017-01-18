using Domain.Converters.Interfaces;
using MQConsumerService.Domain;
using MQConsumerService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Converters
{
    public class RepoConverter : IRepoConverter
    {
        public IEnumerable<Repos> convert(IEnumerable<Repository> source)
        {
            var list = new List<Repos>();

            foreach (var repository in source)
            {
                list.Add(convert(repository));
            }

            return list;
        }

        public Repos convert(Repository source)
        {
            var repo = new Repos();

            repo.Name = source.name;
            repo.URL = source.url;
            repo.Description = source.description;
            repo.ID = source.id;

            return repo;
        }
    }
}
