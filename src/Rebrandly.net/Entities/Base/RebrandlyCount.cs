using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Entities.Base
{
    [JsonObject]
    public class RebrandlyCount<T> : RebrandlyEntity<RebrandlyCount<T>>
    {
        [JsonProperty("count")]
        public long Count { get; set; }
    }
}
