// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure;
using Azure.ResourceManager.EventGrid.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen Symptom #7: generated GetAll passes strongly-typed enum to a
    // string-typed REST helper, causing CS1503; only manifests on the one PEC Collection
    // that received a GetAll binding from the dynamic-parent expansion).
    //
    // Rename the Topic-prefixed PEC collection class to the back-compat name AND work around
    // a generator quirk that only affects the Topic-prefixed collection: the generated
    // GetAll/GetAllAsync pass the strongly-typed _parentType (PrivateEndpointConnectionsParentType)
    // directly to the underlying paged result helper which expects a plain string (CS1503).
    // The sibling Domain/Namespace/PartnerNamespace collections do not emit GetAll, so this
    // re-implementation is needed only here. We suppress the broken methods and re-emit them
    // with _parentType.ToString().
    [CodeGenType("TopicEventGridPrivateEndpointConnectionCollection")]
    [CodeGenSuppress("GetAllAsync", typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(string), typeof(int?), typeof(CancellationToken))]
    public partial class EventGridTopicPrivateEndpointConnectionCollection
    {
        /// <summary> Get all private endpoint connections under a topic, domain, or partner namespace or namespace. </summary>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Number of results per page (1-100, default 20). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<EventGridTopicPrivateEndpointConnectionResource> GetAllAsync(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<EventGridPrivateEndpointConnectionData, EventGridTopicPrivateEndpointConnectionResource>(
                new PrivateEndpointConnectionsGetByResourceAsyncCollectionResultOfT(
                    _privateEndpointConnectionsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    _parentType.ToString(),
                    _parentName,
                    filter,
                    top,
                    context,
                    "EventGridTopicPrivateEndpointConnectionCollection.GetAll"),
                data => new EventGridTopicPrivateEndpointConnectionResource(Client, data));
        }

        /// <summary> Get all private endpoint connections under a topic, domain, or partner namespace or namespace. </summary>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Number of results per page (1-100, default 20). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<EventGridTopicPrivateEndpointConnectionResource> GetAll(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<EventGridPrivateEndpointConnectionData, EventGridTopicPrivateEndpointConnectionResource>(
                new PrivateEndpointConnectionsGetByResourceCollectionResultOfT(
                    _privateEndpointConnectionsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    _parentType.ToString(),
                    _parentName,
                    filter,
                    top,
                    context,
                    "EventGridTopicPrivateEndpointConnectionCollection.GetAll"),
                data => new EventGridTopicPrivateEndpointConnectionResource(Client, data));
        }
    }
}
