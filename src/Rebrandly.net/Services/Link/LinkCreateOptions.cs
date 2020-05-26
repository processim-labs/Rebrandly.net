using Newtonsoft.Json;
using Rebrandly.Entities;
using Rebrandly.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly
{
    public class LinkCreateOptions : BaseOptions
    {
        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("slashtag")]
        public string Slashtag { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("domain")]
        public Domain Domain { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
