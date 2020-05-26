using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Entities.Base
{
    [JsonObject]
    public class RebrandlyList<T> : RebrandlyEntity<RebrandlyList<T>>, IEnumerable<T>
    {
        /// <summary>
        /// A list containing the actual response elements, paginated by any request parameters.
        /// </summary>
        /// 
        [JsonProperty("data")]
        public List<T> Data { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }
    }
}
