using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Model
{
    public class Link
    {
        public int Clicks { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string Destination { get; set; }

        public string DomainId { get; set; }

        public string DomainName { get; set; }

        public bool Favourite { get; set; }

        public bool Https { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        public bool Integrated { get; set; }
        public bool IsPublic { get; set; }
        public string ShortUrl { get; set; }
        public string Slashtag { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
