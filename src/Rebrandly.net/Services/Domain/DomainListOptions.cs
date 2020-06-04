using Newtonsoft.Json;
using Rebrandly.Entities.Enums;
using Rebrandly.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly
{
    public class DomainListOptions : ListOptions
    {
        [JsonProperty ("active")]
        public bool Active { get; set; }

        [JsonProperty("type")]
        public DomainType Type { get; set; }
    }
}
