using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rebrandly.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rebrandly.Entities.Base
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class RebrandlyEntity : IRebrandlyEntity
    {
        /// <summary>Deserializes the JSON to the specified Rebrandly object type.</summary>
        /// <typeparam name="T">The type of the Rebrandly object to deserialize to.</typeparam>
        /// <param name="value">The object to deserialize.</param>
        /// <returns>The deserialized Rebrandly object from the JSON string.</returns>
        public static T FromJson<T>(string value) where T : IRebrandlyEntity
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>Serializes the Rebrandly object as a JSON string.</summary>
        /// <returns>An indented JSON string represensation of the object.</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>Reports a Rebrandly object as a string.</summary>
        /// <returns>
        /// A string representing the Rebrandly object, including its JSON serialization.
        /// </returns>
        /// <seealso cref="ToJson"/>
        public override string ToString()
        {
            return string.Format(
                "<{0}@{1} id={2}> JSON: {3}",
                this.GetType().FullName,
                RuntimeHelpers.GetHashCode(this),
                this.GetIdString(),
                this.ToJson());
        }

        private object GetIdString()
        {
            foreach (var property in this.GetType().GetTypeInfo().DeclaredProperties)
            {
                if (property.Name == "Id")
                {
                    return property.GetValue(this);
                }
            }
            return null;
        }
    }

    public abstract class RebrandlyEntity<T> : RebrandlyEntity where T : RebrandlyEntity<T>
    {
        /// <summary>Deserializes the JSON to a Rebrandly object type.</summary>
        /// <param name="value">The object to deserialize.</param>
        /// <returns>The deserialized Rebrandly object from the JSON string.</returns>
        public static T FromJson(string value)
        {
            return FromJson<T>(value);
        }
    }
}

