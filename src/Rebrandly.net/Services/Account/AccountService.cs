using Rebrandly.Entities;
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
    public class AccountService : Service<Account>,
        IRetrievableEntity<Account, AccountGetOptions>
    {
        public AccountService() : base(null)
        {
        }

        public AccountService(IRebrandlyClient client) : base(client)
        {
        }

        protected override string BasePath => "/account";

        public virtual Task<Account> Get(AccountGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return GetEntity(options, requestOptions, cancellationToken);
        }
    }
}
