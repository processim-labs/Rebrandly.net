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
    public class ScriptService : Service<Script>,
        ICreatable<Script, ScriptCreateOptions>,
        IUpdatable<Script, ScriptUpdateOptions>,
        IListable<Script, ScriptListOptions>,
        IDeletable<Script, ScriptDeleteOptions>,
        IRetrievable<Script, ScriptGetOptions>,
        ICountable<Script, ScriptCountOptions>,
        IAttachable<Script, ScriptAttachOptions>,
        IDetachable<Script, ScriptDetachOptions>
    {

        public ScriptService() : base(null)
        {
        }

        public ScriptService(IRebrandlyClient client) : base(client)
        {
        }

        protected override string BasePath => "/scripts";

        public Task<Script> Create(ScriptCreateOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return CreateEntity(createOptions, requestOptions, cancellationToken);
        }

        public Task<Script> Update(string scriptId, ScriptUpdateOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return UpdateEntity(scriptId, createOptions, requestOptions, cancellationToken);
        }

        public Task<RebrandlyList<Script>> List(ScriptListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return ListEntities(listOptions, requestOptions, cancellationToken);
        }

        public Task<Script> Delete(string scriptId, ScriptDeleteOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return DeleteEntity(scriptId, options, requestOptions, cancellationToken);
        }

        public Task<Script> Get(string scriptId, ScriptGetOptions retrieveOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return GetEntity(scriptId, retrieveOptions, requestOptions, cancellationToken);
        }

        public Task<RebrandlyCount<Script>> Count(ScriptCountOptions countableOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return CountEntities(countableOptions, requestOptions, cancellationToken);
        }

        public Task<Script> Attach(string linkId, string scriptId, ScriptAttachOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return AttachEntity(linkId, scriptId, options, requestOptions, cancellationToken);
        }

        public Task<Script> Detach(string linkId, string scriptId, ScriptDetachOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return DetachEntity(linkId, scriptId, options, requestOptions, cancellationToken);
        }
    }
}
