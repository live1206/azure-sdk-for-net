// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Mocking;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventGrid
{
    // Backward compat: old extension method names differed from new generated names.
    public static partial class EventGridExtensions
    {
        // ArmClient-scoped resource getters for backward compat PE/PL types.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventGridDomainPrivateEndpointConnectionResource GetEventGridDomainPrivateEndpointConnectionResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetEventGridDomainPrivateEndpointConnectionResource(id);
        }

        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventGridDomainPrivateLinkResource GetEventGridDomainPrivateLinkResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetEventGridDomainPrivateLinkResource(id);
        }
        */

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventGridTopicPrivateEndpointConnectionResource GetEventGridTopicPrivateEndpointConnectionResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetEventGridTopicPrivateEndpointConnectionResource(id);
        }

        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventGridTopicPrivateLinkResource GetEventGridTopicPrivateLinkResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetEventGridTopicPrivateLinkResource(id);
        }
        */

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventGridPartnerNamespacePrivateEndpointConnectionResource GetEventGridPartnerNamespacePrivateEndpointConnectionResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetEventGridPartnerNamespacePrivateEndpointConnectionResource(id);
        }

        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PartnerNamespacePrivateLinkResource GetPartnerNamespacePrivateLinkResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetPartnerNamespacePrivateLinkResource(id);
        }
        */

        // ArmClient-scoped GetEventTypes for backward compat.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<EventTypeUnderTopic> GetEventTypesAsync(this ArmClient client, ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetEventTypesAsync(scope, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<EventTypeUnderTopic> GetEventTypes(this ArmClient client, ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetEventTypes(scope, cancellationToken);
        }

        // Subscription-scoped bridges
        /// <summary> List all event subscriptions for a topic type at subscription scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(this SubscriptionResource subscriptionResource, string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetGlobalBySubscriptionForTopicTypeAsync(subscriptionResource, topicTypeName, filter, top, cancellationToken);

        /// <summary> List all event subscriptions for a topic type at subscription scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(this SubscriptionResource subscriptionResource, string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetGlobalBySubscriptionForTopicType(subscriptionResource, topicTypeName, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region at subscription scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(this SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalBySubscriptionAsync(subscriptionResource, location.Name, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region at subscription scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(this SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalBySubscription(subscriptionResource, location.Name, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region for a topic type at subscription scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(this SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalBySubscriptionForTopicTypeAsync(subscriptionResource, location.Name, topicTypeName, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region for a topic type at subscription scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(this SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalBySubscriptionForTopicType(subscriptionResource, location.Name, topicTypeName, filter, top, cancellationToken);

        // Resource group-scoped bridges
        /// <summary> List all event subscriptions for a topic type at resource group scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(this ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetGlobalByResourceGroupForTopicTypeAsync(resourceGroupResource, topicTypeName, filter, top, cancellationToken);

        /// <summary> List all event subscriptions for a topic type at resource group scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(this ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetGlobalByResourceGroupForTopicType(resourceGroupResource, topicTypeName, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region at resource group scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(this ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroupAsync(resourceGroupResource, location.Name, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region at resource group scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(this ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroup(resourceGroupResource, location.Name, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region for a topic type at resource group scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(this ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroupForTopicTypeAsync(resourceGroupResource, location.Name, topicTypeName, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region for a topic type at resource group scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(this ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroupForTopicType(resourceGroupResource, location.Name, topicTypeName, filter, top, cancellationToken);
    }
}
