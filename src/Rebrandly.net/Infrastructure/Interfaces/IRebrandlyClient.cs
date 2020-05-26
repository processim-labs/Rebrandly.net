using Rebrandly.Services.Base;
using Rebrandly.Services.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rebrandly.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface for a Rebrandly client.
    /// </summary>
    public interface IRebrandlyClient
    {
        /// <summary>Gets the base URL for Rebrandly's API.</summary>
        /// <value>The base URL for Rebrandly's API.</value>
        string ApiBase { get; }

        /// <summary>Gets the API key used by the client to send requests.</summary>
        /// <value>The API key used by the client to send requests.</value>
        string ApiKey { get; }

        /// <summary>Sends a request to Rebrandly's API as an asynchronous operation.</summary>
        /// <typeparam name="T">Type of the Rebrandly entity returned by the API.</typeparam>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="options">The parameters of the request.</param>
        /// <param name="requestOptions">The special modifiers of the request.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="RebrandlyException">Thrown if the request fails.</exception>
        Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
            where T : IRebrandlyEntity;
    }
}
