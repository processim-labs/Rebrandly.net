using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebrandlyApiClient.Model
{
    public class Domain
    {
        public string CreatedAt { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("active")]
        public bool IsActive { get; set; }

        [JsonProperty("topLevelDomain")]
        public string TopLevelDomain { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }
}
