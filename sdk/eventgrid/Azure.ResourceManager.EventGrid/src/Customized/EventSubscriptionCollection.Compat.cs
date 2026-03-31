// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

// Backward compat: the old SDK (1.1.0) had EventSubscriptionCollection implementing
// IEnumerable<EventSubscriptionResource> and GetAll with filter/top parameters.
// The new generated collection does not have these. This stub restores the old API surface.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.EventGrid
{
    public partial class EventSubscriptionCollection :
        IEnumerable<EventSubscriptionResource>,
        IAsyncEnumerable<EventSubscriptionResource>
    {
        // Backward compat: old SDK had GetAllAsync/GetAll with filter and top parameters.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EventSubscriptionResource> GetAllAsync(string filter, int? top, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            var providerNamespace = Id.ResourceType.Namespace;
            var resourceTypeName = Id.ResourceType.GetLastType();
            var resourceName = Id.Name;
            var inner = new EventSubscriptionsGetByResourceAsyncCollectionResultOfT(
                _eventSubscriptionsRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerNamespace, resourceTypeName, resourceName, filter, top, context);
            return new CompatAsyncPageable<EventGridSubscriptionData, EventSubscriptionResource>(
                inner, d => new EventSubscriptionResource(Client, d));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EventSubscriptionResource> GetAll(string filter, int? top, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            var providerNamespace = Id.ResourceType.Namespace;
            var resourceTypeName = Id.ResourceType.GetLastType();
            var resourceName = Id.Name;
            var inner = new EventSubscriptionsGetByResourceCollectionResultOfT(
                _eventSubscriptionsRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerNamespace, resourceTypeName, resourceName, filter, top, context);
            return new CompatPageable<EventGridSubscriptionData, EventSubscriptionResource>(
                inner, d => new EventSubscriptionResource(Client, d));
        }

        IEnumerator<EventSubscriptionResource> IEnumerable<EventSubscriptionResource>.GetEnumerator()
            => GetAll(null, null).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetAll(null, null).GetEnumerator();

        IAsyncEnumerator<EventSubscriptionResource> IAsyncEnumerable<EventSubscriptionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(null, null, cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
