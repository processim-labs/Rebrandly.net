using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rebrandly
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

        /// <summary>Gets the client ID used by the client in OAuth requests.</summary>
        /// <value>The client ID used by the client in OAuth requests.</value>
        string ClientId { get; }


        /// <summary>Sends a request to Rebrandly's API as an asynchronous operation.</summary>
        /// <typeparam name="T">Type of the Rebrandly entity returned by the API.</typeparam>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="RebrandlyException">Thrown if the request fails.</exception>
        Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            CancellationToken cancellationToken = default)
            where T : IRebrandlyEntity;

        /// <summary>Sends a request to Rebrandly's API as an asynchronous operation.</summary>
        /// <typeparam name="T">Type of the Rebrandly entity returned by the API.</typeparam>
        /// <param name="method">The HTTP method.</param>
        /// <param name="requestBody">The body of the request.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="RebrandlyException">Thrown if the request fails.</exception>
        Task<T> RequestAsync<T>(
            HttpMethod method,
            string requestBody,
            string path,
            CancellationToken cancellationToken = default)
            where T : IRebrandlyEntity;

        /// <summary>Sends a request to Rebrandly's API as an asynchronous operation.</summary>
        /// <typeparam name="T">Type of the Rebrandly entity returned by the API.</typeparam>
        /// <param name="method">The HTTP method.</param>
        /// <param name="queryParams">The parameters of the request.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="RebrandlyException">Thrown if the request fails.</exception>
        Task<T> RequestAsync<T>(
            HttpMethod method,
            Dictionary<string, string> queryParams,
            string path,
            CancellationToken cancellationToken = default)
            where T : IRebrandlyEntity;
    }
}
