using Newtonsoft.Json;
using Rebrandly.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Entities
{
    public class LinkCount : RebrandlyEntity<LinkCount>
    {
        [JsonProperty("count")]
        public long Count { get; set; }
    }
}
