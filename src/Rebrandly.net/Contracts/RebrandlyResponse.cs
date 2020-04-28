using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Rebrandly.Contracts
{
    public class RebrandlyResponse
    {
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
