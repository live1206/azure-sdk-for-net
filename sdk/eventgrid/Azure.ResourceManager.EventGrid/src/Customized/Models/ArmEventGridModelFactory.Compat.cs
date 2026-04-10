// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

// Suppress generated backward-compat ModelFactory overloads that reference
// EventGridPrivateEndpointConnectionData in root namespace (generator bug:
// PEC uses RoutedOperations → Data class in Models namespace, but backward-compat
// overloads reference root namespace).
// Re-implement with correct type reference for backward compat.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    [CodeGenSuppress("EventGridDomainData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ManagedServiceIdentity), typeof(IEnumerable<EventGridPrivateEndpointConnectionData>), typeof(EventGridDomainProvisioningState?), typeof(TlsVersion?), typeof(Uri), typeof(EventGridInputSchema?), typeof(PartnerTopicEventTypeInfo), typeof(EventGridInputSchemaMapping), typeof(string), typeof(EventGridPublicNetworkAccess?), typeof(IEnumerable<EventGridInboundIPRule>), typeof(bool?), typeof(bool?), typeof(bool?), typeof(DataResidencyBoundary?))]
    [CodeGenSuppress("EventGridNamespaceData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(NamespaceSku), typeof(ManagedServiceIdentity), typeof(IEnumerable<EventGridPrivateEndpointConnectionData>), typeof(NamespaceProvisioningState?), typeof(TopicsConfiguration), typeof(TopicSpacesConfiguration), typeof(bool?), typeof(EventGridPublicNetworkAccess?), typeof(IEnumerable<EventGridInboundIPRule>), typeof(TlsVersion?))]
    [CodeGenSuppress("EventGridTopicData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ManagedServiceIdentity), typeof(IEnumerable<EventGridPrivateEndpointConnectionData>), typeof(EventGridTopicProvisioningState?), typeof(Uri), typeof(PartnerTopicEventTypeInfo), typeof(TlsVersion?), typeof(EventGridInputSchema?), typeof(EventGridInputSchemaMapping), typeof(string), typeof(EventGridPublicNetworkAccess?), typeof(IEnumerable<EventGridInboundIPRule>), typeof(bool?), typeof(DataResidencyBoundary?))]
    public static partial class ArmEventGridModelFactory
    {
        // Backward compat: old ModelFactory overloads for Domain/Namespace/Topic Data
        // that accepted IEnumerable<EventGridPrivateEndpointConnectionData>.
        // The generated overloads referenced the wrong namespace.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventGridDomainData EventGridDomainData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, IEnumerable<EventGridPrivateEndpointConnectionData> privateEndpointConnections, EventGridDomainProvisioningState? provisioningState, TlsVersion? minimumTlsVersionAllowed, Uri endpoint, EventGridInputSchema? inputSchema, PartnerTopicEventTypeInfo eventTypeInfo, EventGridInputSchemaMapping inputSchemaMapping, string metricResourceId, EventGridPublicNetworkAccess? publicNetworkAccess, IEnumerable<EventGridInboundIPRule> inboundIPRules, bool? isLocalAuthDisabled, bool? autoCreateTopicWithFirstSubscription, bool? autoDeleteTopicWithLastSubscription, DataResidencyBoundary? dataResidencyBoundary)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();
            return new EventGridDomainData(
                id, name, resourceType, systemData,
                additionalBinaryDataProperties: null,
                tags, location, default, default, identity);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventGridNamespaceData EventGridNamespaceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, NamespaceSku sku, ManagedServiceIdentity identity, IEnumerable<EventGridPrivateEndpointConnectionData> privateEndpointConnections, NamespaceProvisioningState? provisioningState, TopicsConfiguration topicsConfiguration, TopicSpacesConfiguration topicSpacesConfiguration, bool? isZoneRedundant, EventGridPublicNetworkAccess? publicNetworkAccess, IEnumerable<EventGridInboundIPRule> inboundIPRules, TlsVersion? minimumTlsVersionAllowed)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();
            return new EventGridNamespaceData(
                id, name, resourceType, systemData,
                additionalBinaryDataProperties: null,
                tags, location, default, sku, identity);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventGridTopicData EventGridTopicData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, IEnumerable<EventGridPrivateEndpointConnectionData> privateEndpointConnections, EventGridTopicProvisioningState? provisioningState, Uri endpoint, PartnerTopicEventTypeInfo eventTypeInfo, TlsVersion? minimumTlsVersionAllowed, EventGridInputSchema? inputSchema, EventGridInputSchemaMapping inputSchemaMapping, string metricResourceId, EventGridPublicNetworkAccess? publicNetworkAccess, IEnumerable<EventGridInboundIPRule> inboundIPRules, bool? isLocalAuthDisabled, DataResidencyBoundary? dataResidencyBoundary)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();
            return new EventGridTopicData(
                id, name, resourceType, systemData,
                additionalBinaryDataProperties: null,
                tags, location, default, default, identity, default, default);
        }
    }
}
