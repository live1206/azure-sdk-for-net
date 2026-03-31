// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

// Backward compat: the old SDK (1.1.0) had resource getters and GetEventTypes on MockableEventGridArmClient.
// The new generated code doesn't include per-parent PE/PL resource getters or GetEventTypes on ArmClient scope.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid.Mocking
{
    public partial class MockableEventGridArmClient
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual EventGridDomainPrivateEndpointConnectionResource GetEventGridDomainPrivateEndpointConnectionResource(ResourceIdentifier id)
            => new EventGridDomainPrivateEndpointConnectionResource(Client, id);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual EventGridDomainPrivateLinkResource GetEventGridDomainPrivateLinkResource(ResourceIdentifier id)
            => new EventGridDomainPrivateLinkResource(Client, id);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual EventGridTopicPrivateEndpointConnectionResource GetEventGridTopicPrivateEndpointConnectionResource(ResourceIdentifier id)
            => new EventGridTopicPrivateEndpointConnectionResource(Client, id);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual EventGridTopicPrivateLinkResource GetEventGridTopicPrivateLinkResource(ResourceIdentifier id)
            => new EventGridTopicPrivateLinkResource(Client, id);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual EventGridPartnerNamespacePrivateEndpointConnectionResource GetEventGridPartnerNamespacePrivateEndpointConnectionResource(ResourceIdentifier id)
            => new EventGridPartnerNamespacePrivateEndpointConnectionResource(Client, id);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual PartnerNamespacePrivateLinkResource GetPartnerNamespacePrivateLinkResource(ResourceIdentifier id)
            => new PartnerNamespacePrivateLinkResource(Client, id);

        // Backward compat: old SDK had GetEventTypes on ArmClient scope taking a ResourceIdentifier.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EventTypeUnderTopic> GetEventTypesAsync(ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            // Parse the resource identifier to extract provider namespace, resource type, resource name
            // Expected format: /subscriptions/{sub}/resourceGroups/{rg}/providers/{ns}/{type}/{name}
            Argument.AssertNotNull(scope, nameof(scope));
            ParseResourceId(scope, out string subscriptionId, out string resourceGroupName, out string providerNamespace, out string resourceTypeName, out string resourceName);
            var clientDiags = new ClientDiagnostics("Azure.ResourceManager.EventGrid.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            var restClient = new Topics(clientDiags, Pipeline, Endpoint, "2025-07-15-preview");
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new TopicsGetEventTypesAsyncCollectionResultOfT(
                restClient, Guid.Parse(subscriptionId), resourceGroupName, providerNamespace, resourceTypeName, resourceName, context);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EventTypeUnderTopic> GetEventTypes(ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            ParseResourceId(scope, out string subscriptionId, out string resourceGroupName, out string providerNamespace, out string resourceTypeName, out string resourceName);
            var clientDiags = new ClientDiagnostics("Azure.ResourceManager.EventGrid.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            var restClient = new Topics(clientDiags, Pipeline, Endpoint, "2025-07-15-preview");
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new TopicsGetEventTypesCollectionResultOfT(
                restClient, Guid.Parse(subscriptionId), resourceGroupName, providerNamespace, resourceTypeName, resourceName, context);
        }

        // Parse a resource ID like /subscriptions/{sub}/resourceGroups/{rg}/providers/{ns}/{type}/{name}
        private static void ParseResourceId(ResourceIdentifier id, out string subscriptionId, out string resourceGroupName, out string providerNamespace, out string resourceTypeName, out string resourceName)
        {
            subscriptionId = id.SubscriptionId;
            resourceGroupName = id.ResourceGroupName;
            resourceName = id.Name;
            // ResourceType gives us something like "Microsoft.EventGrid/topics"
            var rt = id.ResourceType;
            providerNamespace = rt.Namespace;
            // The type portion after namespace, e.g. "topics"
            var types = rt.GetLastType();
            resourceTypeName = types;
        }
    }
}
