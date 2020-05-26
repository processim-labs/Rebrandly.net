using Newtonsoft.Json;
using Rebrandly.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly
{
    public class LinkListOptions : ListOptions
    {
        [JsonProperty("favourite")]
        public bool Favourite { get; set; }
    }
}
