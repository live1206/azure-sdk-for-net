// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.MobileNetwork.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.MobileNetwork
{
    /// <summary>
    /// A class representing the MobileNetworkSite data model.
    /// Site resource. Must be created in the same location as its parent mobile network.
    /// </summary>
    public partial class MobileNetworkSiteData : TrackedResourceData
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="MobileNetworkSiteData"/>. </summary>
        /// <param name="location"> The location. </param>
        public MobileNetworkSiteData(AzureLocation location) : base(location)
        {
            NetworkFunctions = new ChangeTrackingList<SubResource>();
        }

        /// <summary> Initializes a new instance of <see cref="MobileNetworkSiteData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="provisioningState"> The provisioning state of the site resource. </param>
        /// <param name="networkFunctions"> An array of IDs of the network functions deployed in the site. Deleting the site will delete any network functions that are deployed in the site. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MobileNetworkSiteData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, MobileNetworkProvisioningState? provisioningState, IReadOnlyList<SubResource> networkFunctions, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            ProvisioningState = provisioningState;
            NetworkFunctions = networkFunctions;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="MobileNetworkSiteData"/> for deserialization. </summary>
        internal MobileNetworkSiteData()
        {
        }

        /// <summary> The provisioning state of the site resource. </summary>
        [WirePath("properties.provisioningState")]
        public MobileNetworkProvisioningState? ProvisioningState { get; }
        /// <summary> An array of IDs of the network functions deployed in the site. Deleting the site will delete any network functions that are deployed in the site. </summary>
        [WirePath("properties.networkFunctions")]
        public IReadOnlyList<SubResource> NetworkFunctions { get; }
    }
}
