using Newtonsoft.Json;
using Rebrandly.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Services.Base
{
    public class ListOptions : BaseOptions
    {
        [JsonProperty("orderBy")]
        public OrderBy? OrderBy { get; set; }

        [JsonProperty("orderDir")]
        public OrderDirection? OrderDir { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }
    }
}
