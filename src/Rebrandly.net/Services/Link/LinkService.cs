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
using Rebrandly.Services.Link;

namespace Rebrandly
{
    public class LinkService : Service<Link, LinkCount>,
        ICreatable<Link, LinkCreateOptions>,
        IUpdatable<Link, LinkUpdateOptions>,
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

        public virtual Task<Link> Update(string linkId, LinkUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return UpdateEntity(linkId, options, requestOptions, cancellationToken);
        }

        public virtual Task<Link> Get(string linkId, LinkGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return GetEntity(linkId, options, requestOptions, cancellationToken);
        }

        public virtual Task<RebrandlyList<Link>> List(LinkListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return ListEntities(listOptions, requestOptions, cancellationToken);
        }

        public virtual Task<Link> Delete(string linkId, LinkDeleteOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return DeleteEntity(linkId, options, requestOptions, cancellationToken);
        }

        public virtual Task<LinkCount> Count(CountOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return CountEntities(options, requestOptions, cancellationToken);
        }
    }
}
