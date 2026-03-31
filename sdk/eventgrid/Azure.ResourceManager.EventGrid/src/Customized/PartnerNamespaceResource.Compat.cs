// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

// Backward compat: the old SDK (1.1.0) exposed child collection/resource accessors directly on the
// PartnerNamespaceResource. The new TypeSpec generator uses RoutedOperations with a dynamic parentType
// parameter, so these accessors are no longer generated. This stub restores the old API surface.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid
{
    public partial class PartnerNamespaceResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual EventGridPartnerNamespacePrivateEndpointConnectionCollection GetEventGridPartnerNamespacePrivateEndpointConnections()
        {
            return new EventGridPartnerNamespacePrivateEndpointConnectionCollection(Client, Id);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<EventGridPartnerNamespacePrivateEndpointConnectionResource>> GetEventGridPartnerNamespacePrivateEndpointConnectionAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return await GetEventGridPartnerNamespacePrivateEndpointConnections().GetAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<EventGridPartnerNamespacePrivateEndpointConnectionResource> GetEventGridPartnerNamespacePrivateEndpointConnection(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetEventGridPartnerNamespacePrivateEndpointConnections().Get(privateEndpointConnectionName, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual PartnerNamespacePrivateLinkResourceCollection GetPartnerNamespacePrivateLinkResources()
        {
            return new PartnerNamespacePrivateLinkResourceCollection(Client, Id);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PartnerNamespacePrivateLinkResource>> GetPartnerNamespacePrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return await GetPartnerNamespacePrivateLinkResources().GetAsync(privateLinkResourceName, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PartnerNamespacePrivateLinkResource> GetPartnerNamespacePrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetPartnerNamespacePrivateLinkResources().Get(privateLinkResourceName, cancellationToken);
        }
    }
}
