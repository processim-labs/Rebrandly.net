using Newtonsoft.Json;
using Rebrandly.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Entities
{
    [JsonObject]
    public class Domain : RebrandlyEntity<Domain>
    {
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("active")]
        public bool IsActive { get; set; }

        [JsonProperty("ref")]
        public string Reference { get; set; }

        [JsonProperty("topLevelDomain")]
        public string TopLevelDomain { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
