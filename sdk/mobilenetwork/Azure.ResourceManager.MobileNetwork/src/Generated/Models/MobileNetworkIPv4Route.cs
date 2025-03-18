// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MobileNetwork.Models
{
    /// <summary> An IPv4 route. </summary>
    public partial class MobileNetworkIPv4Route
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

        /// <summary> Initializes a new instance of <see cref="MobileNetworkIPv4Route"/>. </summary>
        public MobileNetworkIPv4Route()
        {
            NextHops = new ChangeTrackingList<MobileNetworkIPv4RouteNextHop>();
        }

        /// <summary> Initializes a new instance of <see cref="MobileNetworkIPv4Route"/>. </summary>
        /// <param name="destination"> The destination IPv4 prefix. </param>
        /// <param name="nextHops"> A list of next hops for the destination. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MobileNetworkIPv4Route(string destination, IList<MobileNetworkIPv4RouteNextHop> nextHops, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Destination = destination;
            NextHops = nextHops;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The destination IPv4 prefix. </summary>
        [WirePath("destination")]
        public string Destination { get; set; }
        /// <summary> A list of next hops for the destination. </summary>
        [WirePath("nextHops")]
        public IList<MobileNetworkIPv4RouteNextHop> NextHops { get; }
    }
}
