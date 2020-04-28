using Rebrandly.Contracts;
using Rebrandly.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rebrandly.Infrastructure.Interfaces
{
    public interface IListable<TEntity> where TEntity : IRebrandlyEntity
    {
        Task<RebrandlyList<TEntity>> ListLinks(CancellationToken cancellationToken);
        Task<RebrandlyList<TEntity>> ListLinks(GetLinksRequest request,CancellationToken cancellationToken);
    }
}
