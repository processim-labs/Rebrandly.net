using Rebrandly.Exceptions;
using Rebrandly.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Rebrandly.Contracts
{
    /// <summary>
    /// Represents a request to Rebrandly's API.
    /// </summary>
    public class RebrandlyRequest
    {
        private readonly string requestBody;

        /// <summary>Initializes a new instance of the <see cref="RebrandlyRequest"/> class.</summary>
        /// <param name="client">The client creating the request.</param>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="queryParams">The parameters of the request.</param>
        /// <param name="requestBody">The body of the request.</param>
        public RebrandlyRequest(IRebrandlyClient client, HttpMethod method, string path, Dictionary<string, string> queryParams, string requestBody)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            this.requestBody = requestBody;
            Method = method;
            Uri = BuildUri(client, method, path, queryParams);
            AuthorizationHeader = BuildAuthorizationHeader(client);
        }

        /// <summary>The HTTP method for the request (GET, POST or DELETE).</summary>
        public HttpMethod Method { get; }

        /// <summary>
        /// The URL for the request. If this is a GET or DELETE request, the URL also includes
        /// the request parameters in its query string.
        /// </summary>
        public Uri Uri { get; }

        /// <summary>The value of the <c>Authorization</c> header with the API key.</summary>
        public AuthenticationHeaderValue AuthorizationHeader { get; }


        /// <summary>
        /// The body of the request. For POST requests, this will be either a
        /// <c>application/x-www-form-urlencoded</c> or a <c>multipart/form-data</c> payload.
        /// For non-POST requests, this will be <c>null</c>.
        /// </summary>
        /// <remarks>This getter creates a new instance every time it is called.</remarks>
        public HttpContent Content => BuildContent(this.Method, this.requestBody);

        /// <summary>Returns a string that represents the <see cref="RebrandlyRequest"/>.</summary>
        /// <returns>A string that represents the <see cref="RebrandlyRequest"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "<{0} Method={1} Uri={2}>",
                this.GetType().FullName,
                this.Method,
                this.Uri.ToString());
        }

        private static Uri BuildUri(
            IRebrandlyClient client,
            HttpMethod method,
            string path,
            Dictionary<string, string> queryParams)
        {
            StringBuilder sb = new StringBuilder(client.ApiBase.TrimEnd('/'));
            sb.Append(path.TrimEnd('/'));

            if (queryParams != null && queryParams.Count > 0)
            {
                if (method != HttpMethod.Post)
                {
                    string parameterText = string.Join("&", queryParams.Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => x.Key + "=" + x.Value).ToArray());
                    if (parameterText.Length > 0)
                    {
                        sb.Append("?");
                        sb.Append(parameterText);
                    }
                }                
            }
            Uri uri = new Uri(sb.ToString());
            return uri;
        }

        private static AuthenticationHeaderValue BuildAuthorizationHeader(IRebrandlyClient client)
        {
            string apiKey = client.ApiKey;

            if (apiKey == null)
            {
                var message = "No API key provided. Set your API key using "
                    + "`RebrandlyConfiguration.ApiKey = \"<API-KEY>\"`. You can generate API keys "
                    + "from the Rebrandly Dashboard. See "
                    + "https://developers.rebrandly.com/docs/api-key-authentication for details or contact support "
                    + "at https://support.rebrandly.com/hc/en-us/requests/new if you have any questions.";
                throw new RebrandlyException(message);
            }

            return new AuthenticationHeaderValue("apikey", apiKey);
        }

        private static HttpContent BuildContent(HttpMethod method, string requestBody)
        {
            if (method != HttpMethod.Post)
            {
                return null;
            }

            return new StringContent(requestBody, Encoding.UTF8, "application/json");
        }
    }
}
