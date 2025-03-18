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
    /// A class representing the MobileNetworkDiagnosticsPackage data model.
    /// Diagnostics package resource.
    /// </summary>
    public partial class MobileNetworkDiagnosticsPackageData : ResourceData
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

        /// <summary> Initializes a new instance of <see cref="MobileNetworkDiagnosticsPackageData"/>. </summary>
        public MobileNetworkDiagnosticsPackageData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MobileNetworkDiagnosticsPackageData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> The provisioning state of the diagnostics package resource. </param>
        /// <param name="status"> The status of the diagnostics package collection. </param>
        /// <param name="reason"> The reason for the current state of the diagnostics package collection. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MobileNetworkDiagnosticsPackageData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, MobileNetworkProvisioningState? provisioningState, MobileNetworkDiagnosticsPackageStatus? status, string reason, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            ProvisioningState = provisioningState;
            Status = status;
            Reason = reason;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The provisioning state of the diagnostics package resource. </summary>
        [WirePath("properties.provisioningState")]
        public MobileNetworkProvisioningState? ProvisioningState { get; }
        /// <summary> The status of the diagnostics package collection. </summary>
        [WirePath("properties.status")]
        public MobileNetworkDiagnosticsPackageStatus? Status { get; }
        /// <summary> The reason for the current state of the diagnostics package collection. </summary>
        [WirePath("properties.reason")]
        public string Reason { get; }
    }
}
