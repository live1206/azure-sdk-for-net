// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    // Backward compat: old SDK had AddTag/RemoveTag/SetTags on PartnerTopicResource.
    // New generator does not generate tag operations. Add them back as bridge methods.
    public partial class PartnerTopicResource
    {
        /// <summary> Add a tag to the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PartnerTopicResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(key, nameof(key));
            var current = (await GetAsync(cancellationToken).ConfigureAwait(false)).Value;
            var patch = new PartnerTopicPatch();
            foreach (var tag in current.Data.Tags)
            {
                patch.Tags.Add(tag);
            }
            patch.Tags[key] = value;
            await UpdateAsync(patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Add a tag to the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PartnerTopicResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(key, nameof(key));
            var current = Get(cancellationToken).Value;
            var patch = new PartnerTopicPatch();
            foreach (var tag in current.Data.Tags)
            {
                patch.Tags.Add(tag);
            }
            patch.Tags[key] = value;
            Update(patch, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PartnerTopicResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            var patch = new PartnerTopicPatch();
            foreach (var tag in tags)
            {
                patch.Tags.Add(tag);
            }
            await UpdateAsync(patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PartnerTopicResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            var patch = new PartnerTopicPatch();
            foreach (var tag in tags)
            {
                patch.Tags.Add(tag);
            }
            Update(patch, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Remove a tag from the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PartnerTopicResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(key, nameof(key));
            var current = (await GetAsync(cancellationToken).ConfigureAwait(false)).Value;
            var patch = new PartnerTopicPatch();
            foreach (var tag in current.Data.Tags)
            {
                if (tag.Key != key)
                {
                    patch.Tags.Add(tag);
                }
            }
            await UpdateAsync(patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Remove a tag from the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PartnerTopicResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(key, nameof(key));
            var current = Get(cancellationToken).Value;
            var patch = new PartnerTopicPatch();
            foreach (var tag in current.Data.Tags)
            {
                if (tag.Key != key)
                {
                    patch.Tags.Add(tag);
                }
            }
            Update(patch, cancellationToken);
            return Get(cancellationToken);
        }
    }
}
