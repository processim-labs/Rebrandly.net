using Rebrandly.Infrastructure.Interfaces;
using Rebrandly.Models;
using Rebrandly.Models.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rebrandly.Services
{
    public abstract class Service<TEntityReturned> where TEntityReturned : IRebrandlyEntity
    {
        private IRebrandlyClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{EntityReturned}"/> class.
        /// </summary>
        protected Service()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{EntityReturned}"/> class with a
        /// custom <see cref="IRebrandlyClient"/>.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        protected Service(IRebrandlyClient client)
        {
            this.client = client;
        }

        protected abstract string BasePath { get; }

        /// <summary>
        /// Gets or sets the client used by this service to send requests. If no client was set when the
        /// service instance was created, then the default client in
        /// <see cref="RebrandlyConfiguration.RebrandlyClient"/> is used instead.
        /// </summary>
        /// <remarks>
        /// Setting the client at runtime may not be thread-safe.
        /// If you wish to use a custom client, it is recommended that you pass it to the service's constructor and not change it during the service's lifetime.
        /// </remarks>
        protected IRebrandlyClient Client
        {
            get => this.client ?? RebrandlyConfiguration.RebrandlyClient;
            set => this.client = value;
        }

        protected Task<TEntityReturned> CreateEntity(string requestBody, CancellationToken cancellationToken)
        {
            return RequestAsync<TEntityReturned>(HttpMethod.Post, ClassUrl(), requestBody, cancellationToken);
        }

        protected Task<TEntityReturned> DeleteEntity(string id, CancellationToken cancellationToken)
        {
            return RequestAsync<TEntityReturned>(HttpMethod.Delete, InstanceUrl(id), cancellationToken);
        }

        protected Task<TEntityReturned> GetInformationEntity(string id, CancellationToken cancellationToken)
        {
            return RequestAsync<TEntityReturned>(HttpMethod.Get, InstanceUrl(id), cancellationToken);
        }

        protected Task<TEntityReturned> GetCountEntity( CancellationToken cancellationToken)
        {
            return RequestAsync<TEntityReturned>(HttpMethod.Get, InstanceUrl("count"), cancellationToken);
        }

        protected Task<RebrandlyList<TEntityReturned>> ListEntities(CancellationToken cancellationToken)
        {
            return RequestAsync<RebrandlyList<TEntityReturned>>(HttpMethod.Get, ClassUrl() + "/", cancellationToken);
        }

        protected Task<RebrandlyList<TEntityReturned>> ListEntities(Dictionary<string, string> queryParams, CancellationToken cancellationToken)
        {
            return RequestAsync<RebrandlyList<TEntityReturned>>(HttpMethod.Get, ClassUrl() + "/", queryParams, cancellationToken);
        }

        protected async Task<T> RequestAsync<T>(HttpMethod method, string path, CancellationToken cancellationToken = default) where T : IRebrandlyEntity
        {
            return await Client.RequestAsync<T>(method, path, cancellationToken).ConfigureAwait(false);
        }

        protected async Task<T> RequestAsync<T>(HttpMethod method, string path, string requestBody, CancellationToken cancellationToken = default) where T : IRebrandlyEntity
        {
            return await Client.RequestAsync<T>(method, requestBody, path, cancellationToken).ConfigureAwait(false);
        }

        protected async Task<T> RequestAsync<T>(HttpMethod method, string path, Dictionary<string, string> queryParams, CancellationToken cancellationToken = default) where T : IRebrandlyEntity
        {
            return await Client.RequestAsync<T>(method, queryParams, path, cancellationToken).ConfigureAwait(false);
        }

        protected virtual string ClassUrl()
        {
            return BasePath;
        }

        protected virtual string InstanceUrl(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException(
                    "The resource ID cannot be null or whitespace.",
                    nameof(id));
            }

            return $"{ClassUrl()}/{WebUtility.UrlEncode(id)}";
        }
    }
}
