using Newtonsoft.Json;
using Rebrandly.Contracts;
using Rebrandly.Infrastructure.Interfaces;
using Rebrandly.Models;
using Rebrandly.Models.Entities;
using Rebrandly.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rebrandly
{
    public class RebrandlyService : Service<Link>, IListable<Link>
    {
        protected override string BasePath => "/links";

        public virtual Task<Link> CreateShortLink(CreateShortLinkRequest request, CancellationToken cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(request);
            return CreateEntity(body, cancellationToken);
        }

        public virtual Task<Link> GetLink(string id, CancellationToken cancellationToken = default)
        {
            return GetInformationEntity(id, cancellationToken);
        }

        public virtual Task<Link> DeleteLink(string id, CancellationToken cancellationToken = default)
        {
            return DeleteEntity(id, cancellationToken);
        }

        public virtual Task<RebrandlyList<Link>> ListLinks(CancellationToken cancellationToken = default)
        {
            return ListEntities(cancellationToken);
        }

        public virtual Task<RebrandlyList<Link>> ListLinks(GetLinksRequest request, CancellationToken cancellationToken = default)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"limit", request.Limit.ToString()  },
                {"orderDir", request.OrderDir.ToString() },
                {"orderBy", request.OrderBy.ToString() },
                {"last", request.Last }
            };
            return ListEntities(parameters, cancellationToken);
        }

       
    }
}
