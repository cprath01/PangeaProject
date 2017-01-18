using Domain.Converters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.LoadData;
using System.Xml.Serialization;

namespace Domain.Converters
{
    public class LoadDataRequestConverter : ILoadDataRequestConverter
    {
        public LoadDataRequest Convert(string message)
        {
            var serializer = new XmlSerializer(typeof(LoadData.LoadDataRequest));
            var reader = new System.IO.StringReader(message);
            var obj = (LoadData.LoadDataRequest)serializer.Deserialize(reader);

            return obj;
        }
    }
}
