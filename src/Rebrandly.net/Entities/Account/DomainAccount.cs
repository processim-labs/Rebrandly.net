using Newtonsoft.Json;
using Rebrandly.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Entities
{
    [JsonObject]
    public class DomainAccount : RebrandlyEntity<DomainAccount>
    {
        [JsonProperty("used")]
        public long Used { get; set; }

        [JsonProperty("max")]
        public long Max { get; set; }
    }
}
