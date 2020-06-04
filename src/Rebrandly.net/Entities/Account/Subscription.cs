using Newtonsoft.Json;
using Rebrandly.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Entities
{
    [JsonObject]
    public class Subscription : RebrandlyEntity<Account>
    {
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("limits")]
        public Limit Limit { get; set; }
    }
}
