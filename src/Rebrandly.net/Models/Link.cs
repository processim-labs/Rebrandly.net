using Newtonsoft.Json;
using Rebrandly.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Models
{
    public class Link : RebrandlyEntity<Link>
    {
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("domain")]
        public Domain Domain { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("shortUrl")]
        public string ShortUrl { get; set; }

        [JsonProperty("slashtag")]
        public string Slashtag { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; } 
    }
}
