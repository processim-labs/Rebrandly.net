using Rebrandly.Services.Base;
using Rebrandly.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rebrandly.Services.Common;
using System.Threading;
using System.Net.Http;
using Rebrandly.Entities;
using Rebrandly.Entities.Base;
using Rebrandly.Services.Interfaces;

namespace Rebrandly
{
    public class LinkService : Service<Link, LinkCount>,
        ICreatable<Link, LinkCreateOptions>,
        IListable<Link, LinkListOptions>,
        IDeletable<Link, LinkDeleteOptions>,
        IRetrievable<Link, LinkGetOptions>
    {
        public LinkService() : base(null)
        {
        }

        public LinkService(IRebrandlyClient client) : base(client)
        {
        }

        protected override string BasePath => "/links";

        public virtual Task<Link> Create(LinkCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return CreateEntity(options, requestOptions, cancellationToken);
        }

        public virtual Task<Link> Get(string tokenId, LinkGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return GetEntity(tokenId, options, requestOptions, cancellationToken);
        }

        public virtual Task<RebrandlyList<Link>> List(LinkListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return ListEntities(listOptions, requestOptions, cancellationToken);
        }

        public virtual Task<Link> Delete(string customerId, LinkDeleteOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return DeleteEntity(customerId, options, requestOptions, cancellationToken);
        }

        public virtual Task<LinkCount> Count(CountOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return RequestAdditional(HttpMethod.Get, $"{ClassUrl()}/count", options, requestOptions, cancellationToken);
        }
    }
}
