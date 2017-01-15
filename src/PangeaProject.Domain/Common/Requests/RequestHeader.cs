using Common.Enums;
using System;
namespace PangeaProject.Domain.Common.Requests
{
    public class RequestHeader
    {
        public Guid RequestID { get; set; }
        public DateTime Request_TimeStamp { get; set; }
        public RequestType Request_Type { get; set; }
    }
}