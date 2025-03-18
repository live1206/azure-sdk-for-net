// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MobileNetwork.Models
{
    /// <summary> Basic UE Information. </summary>
    public partial class UEInfo : ResourceData
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

        /// <summary> Initializes a new instance of <see cref="UEInfo"/>. </summary>
        /// <param name="ratType"> RAT Type. </param>
        /// <param name="ueState"> State of the UE. </param>
        public UEInfo(RatType ratType, UEState ueState)
        {
            RatType = ratType;
            UEState = ueState;
            UEIPAddresses = new ChangeTrackingList<DnnIPPair>();
        }

        /// <summary> Initializes a new instance of <see cref="UEInfo"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="ratType"> RAT Type. </param>
        /// <param name="ueState"> State of the UE. </param>
        /// <param name="ueIPAddresses"></param>
        /// <param name="lastReadOn"> The timestamp of last list UEs call to the packet core (UTC). </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UEInfo(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, RatType ratType, UEState ueState, IList<DnnIPPair> ueIPAddresses, DateTimeOffset? lastReadOn, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            RatType = ratType;
            UEState = ueState;
            UEIPAddresses = ueIPAddresses;
            LastReadOn = lastReadOn;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="UEInfo"/> for deserialization. </summary>
        internal UEInfo()
        {
        }

        /// <summary> RAT Type. </summary>
        [WirePath("properties.ratType")]
        public RatType RatType { get; set; }
        /// <summary> State of the UE. </summary>
        [WirePath("properties.ueState")]
        public UEState UEState { get; set; }
        /// <summary> Gets the ueip addresses. </summary>
        [WirePath("properties.ueIpAddresses")]
        public IList<DnnIPPair> UEIPAddresses { get; }
        /// <summary> The timestamp of last list UEs call to the packet core (UTC). </summary>
        [WirePath("properties.lastReadAt")]
        public DateTimeOffset? LastReadOn { get; set; }
    }
}
