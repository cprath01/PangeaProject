using Domain.Common.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.LoadData
{
    public class LoadDataRequest
    {
        public RequestHeader Header { get; set; }
        public string Payload { get; set; }
    }
}
