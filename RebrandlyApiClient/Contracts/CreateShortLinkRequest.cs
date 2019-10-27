using Newtonsoft.Json;
using RebrandlyApiClient.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebrandlyApiClient.Contracts
{
    public class CreateShortLinkRequest
    {
        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("domain")]
        public Domain Domain { get; set; }

        [JsonProperty("slashtag")]
        public string Slashtag { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
