using Newtonsoft.Json;
using Rebrandly.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly
{
    public class LinkCountOptions : BaseOptions
    {
        [JsonProperty("favourite")]
        public bool Favourite { get; set; }

        [JsonProperty("domain.id")]
        public string Id { get; set; }
    }
}
