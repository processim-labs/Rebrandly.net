using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using RebrandlyApiClient.Contracts;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Net.Http.Headers;
using RebrandlyApiClient.Model;

namespace RebrandlyApiClient
{
    public class RebrandlyApiClient
    {
        public RebrandlyApiClient(string apiKey)
        {
            this.apiKey = apiKey;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("apiKey", apiKey);
        }

        private const string baseUrl = "https://api.rebrandly.com/v1/";

        //singleton service
        private static readonly HttpClient client = new HttpClient();

        private readonly string apiKey;

        public async Task<Link> CreateShortLink(CreateShortLinkRequest request)
        {
            string body = JsonConvert.SerializeObject(request);
            ApiResponse response = await RequestAsync
            (
                HttpMethod.Post,
                body,
                null,
                "links"
            ).ConfigureAwait(false);

            string content = response.Content;
            Link result = JsonConvert.DeserializeObject<Link>(content);

            return result;
        }

        public async Task<ApiResponse> DeleteLink(string id)
        {
            ApiResponse response = await RequestAsync
            (
                HttpMethod.Delete,
                null,
                null,
                $"links/{id}"
            ).ConfigureAwait(false);

            return response;
        }

        public async Task<int> GetLinkCount()
        {
            ApiResponse response = await RequestAsync
            (
                HttpMethod.Get,
                null,
                null,
                "links/count"
            ).ConfigureAwait(false);
            string rawResult = response.Content;
            int result = JObject.Parse(rawResult).GetValue("count").Value<int>();

            return result;
        }

        public async Task<Link> GetLinkInformation(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("GetLinkInformation id is null or empty.");
            }

            ApiResponse response = await RequestAsync
            (
                HttpMethod.Get,
                null,
                null,
                $"links/{id}"
            ).ConfigureAwait(false);

            string information = response.Content;
            Link result = JsonConvert.DeserializeObject<Link>(information);

            return result;
        }

        public Task<IEnumerable<Link>> GetLinks(OrderDirection orderDirection)
        {
            GetLinksRequest parameters = new GetLinksRequest { OrderDir = orderDirection };
            return GetLinks(parameters);
        }

        public async Task<IEnumerable<Link>> GetLinks(GetLinksRequest request)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"limit", request.Limit.ToString()  },
                {"orderDir", request.OrderDir.ToString() },
                {"orderBy", request.OrderBy.ToString() },
                {"last", request.Last }
            };

            ApiResponse response = await RequestAsync
                (
                    HttpMethod.Get,
                    null,
                    parameters,
                    @"links/"
                ).ConfigureAwait(false);

            string links = response.Content;
            List<Link> result = JsonConvert.DeserializeObject<List<Link>>(links);
            return result;
        }

        private async Task<ApiResponse> RequestAsync(
                                                   HttpMethod method,
                                                   string requestBody = null,
                                                   Dictionary<string, string> queryParams = null,
                                                   string urlPath = null,
                                                   CancellationToken cancellationToken = default)
        {
            StringBuilder sb = new StringBuilder(baseUrl.TrimEnd('/') + '/');
            sb.Append(urlPath.TrimEnd('/') + '/');

            if (queryParams != null && queryParams.Count > 0)
            {
                string parameterText = string.Join("&", queryParams.Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => x.Key + "=" + x.Value).ToArray());
                if (parameterText.Length > 0)
                {
                    sb.Append("?");
                    sb.Append(parameterText);
                }
            }

            Uri uri = new Uri(sb.ToString());

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = method,
                RequestUri = uri,
                Content = requestBody == null ? null : new StringContent(requestBody, Encoding.UTF8, "application/json"),
            };

            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.SendAsync(message, cancellationToken).ConfigureAwait(false);
            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            string statusCode = response.StatusCode.ToString();

            return new ApiResponse
            {
                Content = responseContent,
                StatusCode = statusCode
            };
        }
    }
}
