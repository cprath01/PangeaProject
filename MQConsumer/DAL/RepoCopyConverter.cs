using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQConsumerService.Domain;

namespace DAL
{
    public class RepoCopyConverter : IRepoCopyConverter
    {
        public RepoCopy convert(Repos source)
        {
            var copy = new RepoCopy();

            copy.Name = source.Name;
            copy.URL = source.URL;
            copy.Description = source.Description;
            copy.ID = source.ID;

            return copy;
        }

        public IEnumerable<RepoCopy> convert(IEnumerable<Repos> source)
        {
            var list = new List<RepoCopy>();

            foreach (var item in source)
            {
                list.Add(convert(item));
            }

            return list;
        }
    }
}
