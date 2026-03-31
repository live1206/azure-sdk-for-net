// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

// Backward compat: the old SDK (1.1.0) exposed child collection/resource accessors directly on the
// EventGridTopicResource. The new TypeSpec generator uses RoutedOperations with a dynamic parentType
// parameter, so these accessors are no longer generated. This stub restores the old API surface.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid
{
    public partial class EventGridTopicResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual EventGridTopicPrivateEndpointConnectionCollection GetEventGridTopicPrivateEndpointConnections()
        {
            return new EventGridTopicPrivateEndpointConnectionCollection(Client, Id);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<EventGridTopicPrivateEndpointConnectionResource>> GetEventGridTopicPrivateEndpointConnectionAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return await GetEventGridTopicPrivateEndpointConnections().GetAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<EventGridTopicPrivateEndpointConnectionResource> GetEventGridTopicPrivateEndpointConnection(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetEventGridTopicPrivateEndpointConnections().Get(privateEndpointConnectionName, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual EventGridTopicPrivateLinkResourceCollection GetEventGridTopicPrivateLinkResources()
        {
            return new EventGridTopicPrivateLinkResourceCollection(Client, Id);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<EventGridTopicPrivateLinkResource>> GetEventGridTopicPrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return await GetEventGridTopicPrivateLinkResources().GetAsync(privateLinkResourceName, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<EventGridTopicPrivateLinkResource> GetEventGridTopicPrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetEventGridTopicPrivateLinkResources().Get(privateLinkResourceName, cancellationToken);
        }
    }
}
