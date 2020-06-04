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
    public class TagService : Service<Tag>,
        IUpdatable<Tag, TagUpdateOptions>,
        IListable<Tag, TagListOptions>,
        IDeletable<Tag, TagDeleteOptions>,
        IRetrievable<Tag, TagGetOptions>,
        ICountable<Tag, TagCountOptions>,
        IAttachable<Tag, TagAttachOptions>,
        IDetachable<Tag, TagDetachOptions>
    {
        public TagService() : base(null)
        {
        }

        public TagService(IRebrandlyClient client) : base(client)
        {
        }

        protected override string BasePath => "/tags";

        public virtual Task<Tag> Update(string tagId, TagUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return UpdateEntity(tagId, options, requestOptions, cancellationToken);
        }

        public virtual Task<Tag> Get(string tagId, TagGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return GetEntity(tagId, options, requestOptions, cancellationToken);
        }

        public virtual Task<RebrandlyList<Tag>> List(TagListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return ListEntities(listOptions, requestOptions, cancellationToken);
        }

        public virtual Task<Tag> Delete(string tagId, TagDeleteOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return DeleteEntity(tagId, options, requestOptions, cancellationToken);
        }

        public virtual Task<RebrandlyCount<Tag>> Count(TagCountOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return CountEntities(options, requestOptions, cancellationToken);
        }

        public Task<Tag> Attach(string linkId, string tagId, TagAttachOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return AttachEntity(linkId, tagId, options, requestOptions, cancellationToken);
        }

        public Task<Tag> Detach(string linkId, string tagId, TagDetachOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return DetachEntity(linkId, tagId, options, requestOptions, cancellationToken);
        }
    }
}
