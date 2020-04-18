using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Contracts
{
    public class GetLinksRequest
    {
        public string Last { get; set; }
        public int? Limit { get; set; }
        public OrderBy? OrderBy { get; set; }
        public OrderDirection? OrderDir { get; set; }
    }
}
