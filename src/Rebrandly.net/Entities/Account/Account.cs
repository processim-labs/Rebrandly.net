using Newtonsoft.Json;
using Rebrandly.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Entities
{
    [JsonObject]
    public class Account : RebrandlyEntity<Account>
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("avatarUrl")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }
    }
}
