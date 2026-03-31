// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

// Backward compat: the old SDK (1.1.0) exposed child collection/resource accessors directly on the
// EventGridDomainResource. The new TypeSpec generator uses RoutedOperations with a dynamic parentType
// parameter, so these accessors are no longer generated. This stub restores the old API surface.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid
{
    public partial class EventGridDomainResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual EventGridDomainPrivateEndpointConnectionCollection GetEventGridDomainPrivateEndpointConnections()
        {
            return new EventGridDomainPrivateEndpointConnectionCollection(Client, Id);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<EventGridDomainPrivateEndpointConnectionResource>> GetEventGridDomainPrivateEndpointConnectionAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return await GetEventGridDomainPrivateEndpointConnections().GetAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<EventGridDomainPrivateEndpointConnectionResource> GetEventGridDomainPrivateEndpointConnection(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetEventGridDomainPrivateEndpointConnections().Get(privateEndpointConnectionName, cancellationToken);
        }

        // Backward compat: old SDK exposed private link resource accessors on domain resource.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual EventGridDomainPrivateLinkResourceCollection GetEventGridDomainPrivateLinkResources()
        {
            return new EventGridDomainPrivateLinkResourceCollection(Client, Id);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<EventGridDomainPrivateLinkResource>> GetEventGridDomainPrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return await GetEventGridDomainPrivateLinkResources().GetAsync(privateLinkResourceName, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<EventGridDomainPrivateLinkResource> GetEventGridDomainPrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetEventGridDomainPrivateLinkResources().Get(privateLinkResourceName, cancellationToken);
        }
    }
}
