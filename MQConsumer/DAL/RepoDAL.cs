using Domain.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQConsumerService.Domain;
using System.Data.Entity;
using Domain.Converters.Interfaces;

namespace DAL
{
    public class RepoDAL : IRepoDAL_Save
    {
        private IPangeaRepoDBEntities _entities;
        private IRepoCopyConverter _converter;
        public RepoDAL(IPangeaRepoDBEntities entities, IRepoCopyConverter converter)
        {
            _entities = entities;
            _converter = converter;
        }

        public void Save(List<Repos> repos)
        {
            var list = _converter.convert(repos);
            foreach (var repo in list)
            {
                var repoCopy = _entities.RepoCopies.FirstOrDefault(r => r.ID == repo.ID);
                if (repoCopy != null)
                {
                    repoCopy.Name = repo.Name;
                    repoCopy.URL = repo.URL;
                    repoCopy.Description = repo.Description;
                }
                else
                    _entities.RepoCopies.Add(repo);
            }
            _entities.SaveChanges();
        }
    }
}
