// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.ResourceConnector.Models
{
    /// <summary> Contains the REP (rendezvous endpoint) and “Listener” access token from notification service (NS). </summary>
    public partial class HybridConnectionConfig
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

        /// <summary> Initializes a new instance of <see cref="HybridConnectionConfig"/>. </summary>
        internal HybridConnectionConfig()
        {
        }

        /// <summary> Initializes a new instance of <see cref="HybridConnectionConfig"/>. </summary>
        /// <param name="expirationTime"> Timestamp when this token will be expired. </param>
        /// <param name="hybridConnectionName"> Name of the connection. </param>
        /// <param name="relay"> Name of the notification service. </param>
        /// <param name="token"> Listener access token. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal HybridConnectionConfig(long? expirationTime, string hybridConnectionName, string relay, string token, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ExpirationTime = expirationTime;
            HybridConnectionName = hybridConnectionName;
            Relay = relay;
            Token = token;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Timestamp when this token will be expired. </summary>
        public long? ExpirationTime { get; }
        /// <summary> Name of the connection. </summary>
        public string HybridConnectionName { get; }
        /// <summary> Name of the notification service. </summary>
        public string Relay { get; }
        /// <summary> Listener access token. </summary>
        public string Token { get; }
    }
}
