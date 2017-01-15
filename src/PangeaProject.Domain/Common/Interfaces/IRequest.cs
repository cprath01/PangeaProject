using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PangeaProject.Domain.Common.Requests;

namespace PangeaProject.Domain.Common.Interfaces
{
    public interface IRequest
    {
        RequestHeader Header { get; set; }
        string Payload { get; set; }
    }
}
