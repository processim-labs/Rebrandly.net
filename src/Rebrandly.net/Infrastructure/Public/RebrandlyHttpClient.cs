using Rebrandly.Contracts;
using Rebrandly.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rebrandly.Infrastructure
{
    /// <summary>
    /// Standard client to make requests to Rebrandly's API, using
    /// <see cref="System.Net.Http.HttpClient"/> to send HTTP requests.
    /// </summary>
    public class RebrandlyHttpClient : IRebrandlyHttpClient
    {
        private static readonly Lazy<HttpClient> LazyDefaultHttpClient = new Lazy<HttpClient>(BuildDefaultSystemNetHttpClient);
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemNetHttpClient"/> class.
        /// </summary>
        /// <param name="httpClient">
        /// The <see cref="System.Net.Http.HttpClient"/> client to use. If <c>null</c>, an HTTP
        /// client will be created with default parameters.
        /// </param>
        /// <param name="maxNetworkRetries">
        /// The maximum number of times the client will retry requests that fail due to an
        /// intermittent problem.
        /// </param>
        public RebrandlyHttpClient(HttpClient httpClient = null)
        {
            this.httpClient = httpClient ?? LazyDefaultHttpClient.Value;
        }

        /// <summary>Default timespan before the request times out.</summary>
        public static TimeSpan DefaultHttpTimeout => TimeSpan.FromSeconds(80);

        /// <summary>
        /// Initializes a new instance of the <see cref="System.Net.Http.HttpClient"/> class
        /// with default parameters.
        /// </summary>
        /// <returns>The new instance of the <see cref="System.Net.Http.HttpClient"/> class.</returns>
        public static HttpClient BuildDefaultSystemNetHttpClient()
        {
            return new HttpClient
            {
                Timeout = DefaultHttpTimeout,
            };
        }

        /// <summary>Sends a request to Rebrandly's API as an asynchronous operation.</summary>
        /// <param name="request">The parameters of the request to send.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<RebrandlyResponse> MakeRequestAsync(RebrandlyRequest request, CancellationToken cancellationToken = default)
        {
            Exception requestException = null;
            HttpResponseMessage response = null;

            requestException = null;

            var httpRequest = BuildRequestMessage(request);

            try
            {
                response = await httpClient.SendAsync(httpRequest, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                requestException = exception;
            }
            catch (OperationCanceledException exception)
                when (!cancellationToken.IsCancellationRequested)
            {
                requestException = exception;
            }

            if (requestException != null)
            {
                throw requestException;
            }

            return new RebrandlyResponse()
            {
                Content = await response.Content.ReadAsStringAsync().ConfigureAwait(false),
                StatusCode = response.StatusCode
            };
        }

        private HttpRequestMessage BuildRequestMessage(RebrandlyRequest request)
        {
            var requestMessage = new HttpRequestMessage(request.Method, request.Uri);
            // Standard headers
            requestMessage.Headers.Add(request.AuthorizationHeader.Scheme, request.AuthorizationHeader.Parameter);

            // Request body
            requestMessage.Content = request.Content;

            return requestMessage;
        }
    }
}
