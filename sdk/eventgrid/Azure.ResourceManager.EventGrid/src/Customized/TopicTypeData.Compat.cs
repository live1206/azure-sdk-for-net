// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.EventGrid.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    /// <summary> Backward-compat: public constructor and property setters for TopicTypeData. </summary>
    [CodeGenSuppress("TopicTypeData")]
    [CodeGenSuppress("Provider")]
    [CodeGenSuppress("DisplayName")]
    [CodeGenSuppress("Description")]
    [CodeGenSuppress("ResourceRegionType")]
    [CodeGenSuppress("ProvisioningState")]
    [CodeGenSuppress("SourceResourceFormat")]
    [CodeGenSuppress("AreRegionalAndGlobalSourcesSupported")]
    public partial class TopicTypeData
    {
        /// <summary> Initializes a new instance of <see cref="TopicTypeData"/>. </summary>
        public TopicTypeData() : this(default, default, default, default, default, new TopicTypeProperties()) { }

        /// <summary> Namespace of the provider of the topic type. </summary>
        [WirePath("properties.provider")]
        public string Provider { get => Properties?.Provider; set { if (Properties != null) Properties.Provider = value; } }

        /// <summary> Display Name for the topic type. </summary>
        [WirePath("properties.displayName")]
        public string DisplayName { get => Properties?.DisplayName; set { if (Properties != null) Properties.DisplayName = value; } }

        /// <summary> Description of the topic type. </summary>
        [WirePath("properties.description")]
        public string Description { get => Properties?.Description; set { if (Properties != null) Properties.Description = value; } }

        /// <summary> Region type of the resource. </summary>
        [WirePath("properties.resourceRegionType")]
        public EventGridResourceRegionType? ResourceRegionType { get => Properties?.ResourceRegionType; set { if (Properties != null) Properties.ResourceRegionType = value; } }

        /// <summary> Provisioning state of the topic type. </summary>
        [WirePath("properties.provisioningState")]
        public TopicTypeProvisioningState? ProvisioningState { get => Properties?.ProvisioningState; set { if (Properties != null) Properties.ProvisioningState = value; } }

        /// <summary> Source resource format. </summary>
        [WirePath("properties.sourceResourceFormat")]
        public string SourceResourceFormat { get => Properties?.SourceResourceFormat; set { if (Properties != null) Properties.SourceResourceFormat = value; } }

        /// <summary> Flag to indicate that a topic type can support both regional or global system topics. </summary>
        [WirePath("properties.areRegionalAndGlobalSourcesSupported")]
        public bool? AreRegionalAndGlobalSourcesSupported { get => Properties?.AreRegionalAndGlobalSourcesSupported; set { if (Properties != null) Properties.AreRegionalAndGlobalSourcesSupported = value; } }
    }
}
