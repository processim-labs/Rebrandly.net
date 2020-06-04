using Rebrandly.Entities;
using Rebrandly.Entities.Base;
using Rebrandly.Infrastructure.Interfaces;
using Rebrandly.Services.Base;
using Rebrandly.Services.Common;
using Rebrandly.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rebrandly
{
    public class DomainService : Service<Domain>,
        IRetrievable<Domain, DomainGetOptions>,
        IListable<Domain, DomainListOptions>,
        ICountable<Domain, DomainCountOptions>
    {
        public DomainService() : base(null)
        {
        }

        public DomainService(IRebrandlyClient client) : base(client)
        {
        }

        protected override string BasePath => "/domains";

        public virtual Task<RebrandlyCount<Domain>> Count(DomainCountOptions countableOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return CountEntities(countableOptions, requestOptions, cancellationToken);
        }

        public virtual Task<Domain> Get(string id, DomainGetOptions retrieveOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return GetEntity(id, retrieveOptions, requestOptions, cancellationToken);
        }

        public virtual Task<RebrandlyList<Domain>> List(DomainListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return ListEntities(listOptions, requestOptions, cancellationToken);
        }
    }
}
