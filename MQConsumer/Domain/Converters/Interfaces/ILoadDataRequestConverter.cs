using Domain.LoadData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Converters.Interfaces
{
    public interface ILoadDataRequestConverter
    {
        LoadDataRequest Convert(string message);
    }
}
