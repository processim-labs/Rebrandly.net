using Newtonsoft.Json;
using Rebrandly.Services.Base;

namespace Rebrandly
{
    public class ScriptCreateOptions : BaseOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}