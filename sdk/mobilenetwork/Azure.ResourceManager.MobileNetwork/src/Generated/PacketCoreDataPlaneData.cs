// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.MobileNetwork.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MobileNetwork
{
    /// <summary>
    /// A class representing the PacketCoreDataPlane data model.
    /// Packet core data plane resource. Must be created in the same location as its parent packet core control plane.
    /// </summary>
    public partial class PacketCoreDataPlaneData : TrackedResourceData
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

        /// <summary> Initializes a new instance of <see cref="PacketCoreDataPlaneData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="userPlaneAccessInterface"> The user plane interface on the access network. For 5G networks, this is the N3 interface. For 4G networks, this is the S1-U interface. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userPlaneAccessInterface"/> is null. </exception>
        public PacketCoreDataPlaneData(AzureLocation location, MobileNetworkInterfaceProperties userPlaneAccessInterface) : base(location)
        {
            Argument.AssertNotNull(userPlaneAccessInterface, nameof(userPlaneAccessInterface));

            UserPlaneAccessInterface = userPlaneAccessInterface;
            UserPlaneAccessVirtualIPv4Addresses = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="PacketCoreDataPlaneData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="provisioningState"> The provisioning state of the packet core data plane resource. </param>
        /// <param name="userPlaneAccessInterface"> The user plane interface on the access network. For 5G networks, this is the N3 interface. For 4G networks, this is the S1-U interface. </param>
        /// <param name="userPlaneAccessVirtualIPv4Addresses"> The virtual IP address(es) for the user plane on the access network in a High Availability (HA) system. In an HA deployment the access network router should be configured to forward traffic for this address to the control plane access interface on the active or standby node. In non-HA system this list should be omitted or empty. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal PacketCoreDataPlaneData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, MobileNetworkProvisioningState? provisioningState, MobileNetworkInterfaceProperties userPlaneAccessInterface, IList<string> userPlaneAccessVirtualIPv4Addresses, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            ProvisioningState = provisioningState;
            UserPlaneAccessInterface = userPlaneAccessInterface;
            UserPlaneAccessVirtualIPv4Addresses = userPlaneAccessVirtualIPv4Addresses;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="PacketCoreDataPlaneData"/> for deserialization. </summary>
        internal PacketCoreDataPlaneData()
        {
        }

        /// <summary> The provisioning state of the packet core data plane resource. </summary>
        [WirePath("properties.provisioningState")]
        public MobileNetworkProvisioningState? ProvisioningState { get; }
        /// <summary> The user plane interface on the access network. For 5G networks, this is the N3 interface. For 4G networks, this is the S1-U interface. </summary>
        [WirePath("properties.userPlaneAccessInterface")]
        public MobileNetworkInterfaceProperties UserPlaneAccessInterface { get; set; }
        /// <summary> The virtual IP address(es) for the user plane on the access network in a High Availability (HA) system. In an HA deployment the access network router should be configured to forward traffic for this address to the control plane access interface on the active or standby node. In non-HA system this list should be omitted or empty. </summary>
        [WirePath("properties.userPlaneAccessVirtualIpv4Addresses")]
        public IList<string> UserPlaneAccessVirtualIPv4Addresses { get; }
    }
}
