using Rebrandly.Entities.Base;
using Rebrandly.Infrastructure.Interfaces;
using Rebrandly.Services.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rebrandly.Services.Base
{
    public abstract class Service<TEntityReturned, TAdditionalEntityReturned> where TEntityReturned : IRebrandlyEntity where TAdditionalEntityReturned : IRebrandlyEntity
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

        protected virtual string BaseUrl => Client.ApiBase;

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

        protected Task<TEntityReturned> CreateEntity(BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return Request<TEntityReturned>(HttpMethod.Post, ClassUrl(), options, requestOptions, cancellationToken);
        }

        protected Task<TEntityReturned> UpdateEntity(string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return Request(HttpMethod.Post, InstanceUrl(id), options, requestOptions, cancellationToken);
        }

        protected Task<TEntityReturned> DeleteEntity(string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return Request<TEntityReturned>(HttpMethod.Delete, InstanceUrl(id), options, requestOptions, cancellationToken);
        }

        protected Task<TEntityReturned> GetEntity(string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return Request<TEntityReturned>(HttpMethod.Get, InstanceUrl(id), options, requestOptions, cancellationToken);
        }

        protected Task<RebrandlyList<TEntityReturned>> ListEntities(ListOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return Request<RebrandlyList<TEntityReturned>>(HttpMethod.Get, ClassUrl() + "/", options, requestOptions, cancellationToken);
        }

        protected Task<TEntityReturned> Request(HttpMethod method, string path, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken = default)
        {
            return Request<TEntityReturned>(method, path, options, requestOptions, cancellationToken);
        }

        protected Task<TAdditionalEntityReturned> RequestAdditional(HttpMethod method, string path, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken = default)
        {
            return Request<TAdditionalEntityReturned>(method, path, options, requestOptions, cancellationToken);
        }

        protected async Task<T> Request<T>(HttpMethod method, string path, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken = default) where T : IRebrandlyEntity
        {
            requestOptions = SetupRequestOptions(requestOptions);
            return await Client.RequestAsync<T>(method, path, options, requestOptions, cancellationToken).ConfigureAwait(false);
        }       

        protected RequestOptions SetupRequestOptions(RequestOptions requestOptions)
        {
            if (requestOptions == null)
            {
                requestOptions = new RequestOptions();
            }

            requestOptions.BaseUrl = requestOptions.BaseUrl ?? BaseUrl;

            return requestOptions;
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
