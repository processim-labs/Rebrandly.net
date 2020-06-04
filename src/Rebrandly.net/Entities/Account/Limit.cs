using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Entities
{
    [JsonObject]
    public class Limit
    {
        [JsonProperty("links")]
        public DomainAccount Links { get; set; }

        [JsonProperty("domains")]
        public DomainAccount Domains { get; set; }

        [JsonProperty("teammates")]
        public DomainAccount Teammates { get; set; }

        [JsonProperty("tags")]
        public DomainAccount Tags { get; set; }

        [JsonProperty("scripts")]
        public DomainAccount Scripts { get; set; }
    }
}
