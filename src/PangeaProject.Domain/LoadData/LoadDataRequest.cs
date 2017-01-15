using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using PangeaProject.Domain.Common.Requests;
using PangeaProject.Domain.Common.Interfaces;

namespace PangeaProject.Domain.LoadData
{
    public class LoadDataRequest : IRequest
    {
        public RequestHeader Header { get; set; }
        public string Payload { get; set; }
    }
}
