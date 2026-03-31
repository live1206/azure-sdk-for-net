// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid.Mocking
{
    // Backward compat: bridge old method names to new generated names.
    public partial class MockableEventGridResourceGroupResource
    {
        /// <summary> List all event subscriptions for a topic type at resource group scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetGlobalByResourceGroupForTopicTypeAsync(topicTypeName, filter, top, cancellationToken);

        /// <summary> List all event subscriptions for a topic type at resource group scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetGlobalByResourceGroupForTopicType(topicTypeName, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region at resource group scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(AzureLocation location, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroupAsync(location.Name, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region at resource group scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(AzureLocation location, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroup(location.Name, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region for a topic type at resource group scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(AzureLocation location, string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroupForTopicTypeAsync(location.Name, topicTypeName, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region for a topic type at resource group scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(AzureLocation location, string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroupForTopicType(location.Name, topicTypeName, filter, top, cancellationToken);
    }
}
