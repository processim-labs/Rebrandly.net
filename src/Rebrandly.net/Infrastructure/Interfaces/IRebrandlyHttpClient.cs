using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rebrandly.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface for HTTP clients used to make requests to Rebrandly's API.
    /// </summary>
    public interface IRebrandlyHttpClient
    {
        /// <summary>Sends a request to Rebrandly's API as an asynchronous operation.</summary>
        /// <param name="request">The parameters of the request to send.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<RebrandlyResponse> MakeRequestAsync(
            RebrandlyRequest request,
            CancellationToken cancellationToken = default);
    }
}
