// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid.Mocking
{
    // Backward compat: bridge old method names to new generated names.
    public partial class MockableEventGridSubscriptionResource
    {
        /// <summary> List all event subscriptions for a topic type at subscription scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetGlobalBySubscriptionForTopicTypeAsync(topicTypeName, filter, top, cancellationToken);

        /// <summary> List all event subscriptions for a topic type at subscription scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetGlobalBySubscriptionForTopicType(topicTypeName, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region at subscription scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(AzureLocation location, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalBySubscriptionAsync(location.Name, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region at subscription scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(AzureLocation location, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalBySubscription(location.Name, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region for a topic type at subscription scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(AzureLocation location, string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalBySubscriptionForTopicTypeAsync(location.Name, topicTypeName, filter, top, cancellationToken);

        /// <summary> List all event subscriptions in a region for a topic type at subscription scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(AzureLocation location, string topicTypeName, string filter = default, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalBySubscriptionForTopicType(location.Name, topicTypeName, filter, top, cancellationToken);
    }
}
