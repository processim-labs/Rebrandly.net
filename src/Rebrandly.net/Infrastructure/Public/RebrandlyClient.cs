using Newtonsoft.Json.Linq;
using Rebrandly.Entities.Base;
using Rebrandly.Exceptions;
using Rebrandly.Infrastructure.Interfaces;
using Rebrandly.Services.Base;
using Rebrandly.Services.Common;
using Rebrandly.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rebrandly.Infrastructure
{
    /// <summary>
    /// A Rebrandly client, used to issue requests to Rebrandly's API and deserialize responses.
    /// </summary>
    public class RebrandlyClient : IRebrandlyClient
    {
        /// <summary>Initializes a new instance of the <see cref="RebrandlyClient"/> class.</summary>
        /// <param name="apiKey">The API key used by the client to make requests.</param>
        /// <param name="clientId">The client ID used by the client in OAuth requests.</param>
        /// <param name="httpClient">
        /// The <see cref="IHttpClient"/> client to use. If <c>null</c>, an HTTP client will be
        /// created with default parameters.
        /// </param>
        /// <param name="apiBase">
        /// The base URL for Rebrandly's API. Defaults to <see cref="DefaultApiBase"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">if <c>apiKey</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// if <c>apiKey</c> is empty or contains whitespace.
        /// </exception>
        public RebrandlyClient(
            string apiKey = null,
            string clientId = null,
            IRebrandlyHttpClient httpClient = null,
            string apiBase = null)
        {
            if (apiKey != null && apiKey.Length == 0)
            {
                throw new ArgumentException("API key cannot be the empty string.", nameof(apiKey));
            }

            if (apiKey != null && StringUtils.ContainsWhitespace(apiKey))
            {
                throw new ArgumentException("API key cannot contain whitespace.", nameof(apiKey));
            }

            ApiKey = apiKey;
            ClientId = clientId;
            HttpClient = httpClient ?? BuildDefaultHttpClient();
            ApiBase = apiBase ?? DefaultApiBase;
        }

        /// <summary>Default base URL for Rebrandly's API.</summary>
        public static string DefaultApiBase => "https://api.rebrandly.com/v1";


        /// <summary>Gets the base URL for Rebrandly's API.</summary>
        /// <value>The base URL for Rebrandly's API.</value>
        public string ApiBase { get; }

        /// <summary>Gets the API key used by the client to send requests.</summary>
        /// <value>The API key used by the client to send requests.</value>
        public string ApiKey { get; }

        /// <summary>Gets the client ID used by the client in OAuth requests.</summary>
        /// <value>The client ID used by the client in OAuth requests.</value>
        public string ClientId { get; }

        /// <summary>Gets the <see cref="IRebrandlyHttpClient"/> used to send HTTP requests.</summary>
        /// <value>The <see cref="IRebrandlyHttpClient"/> used to send HTTP requests.</value>
        public IRebrandlyHttpClient HttpClient { get; }

        public async Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default) where T : IRebrandlyEntity
        {
            var request = new RebrandlyRequest(this, method, path, options, requestOptions);
            var response = await HttpClient.MakeRequestAsync(request, cancellationToken).ConfigureAwait(false);
            return ProcessResponse<T>(response);
        }

        private static IRebrandlyHttpClient BuildDefaultHttpClient()
        {
            return new RebrandlyHttpClient();
        }

        private static T ProcessResponse<T>(RebrandlyResponse response) where T : IRebrandlyEntity
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw BuildInvalidResponseException(response);
            }

            T obj;
            try
            {
                obj = RebrandlyEntity.FromJson<T>((response.Content.StartsWith("[")) ? @"{""data"":" + response.Content + "}" : response.Content);
            }
            catch (Newtonsoft.Json.JsonException)
            {
                throw BuildInvalidResponseException(response);
            }

            obj.RebrandlyResponse = response;

            return obj;
        }


        private static RebrandlyException BuildInvalidResponseException(RebrandlyResponse response)
        {
            return new RebrandlyException(response.StatusCode, $"Invalid response object from API: \"{response.Content}\"")
            {
                RebrandlyResponse = response,
            };
        }
    }
}
