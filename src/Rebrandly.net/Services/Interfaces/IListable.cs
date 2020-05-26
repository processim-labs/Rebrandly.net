using Rebrandly.Entities.Base;
using Rebrandly.Infrastructure.Interfaces;
using Rebrandly.Services.Base;
using Rebrandly.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rebrandly.Services.Interfaces
{
    public interface IListable<TEntity, TOptions> where TEntity : IRebrandlyEntity where TOptions : ListOptions, new()
    {
        Task<RebrandlyList<TEntity>> List(TOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
