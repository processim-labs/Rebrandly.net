using Newtonsoft.Json;
using Rebrandly.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Services.Link
{
    public class LinkUpdateOptions : BaseOptions
    {
        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("favourite")]
        public bool Favourite { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
