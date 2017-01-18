using Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Requests
{
    public class RequestHeader
    {
        public Guid RequestID { get; set; }
        public DateTime Request_TimeStamp { get; set; }
        public RequestType Request_Type { get; set; }
    }
}
