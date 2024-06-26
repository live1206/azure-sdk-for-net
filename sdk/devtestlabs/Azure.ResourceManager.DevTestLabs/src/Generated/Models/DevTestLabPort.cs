// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.DevTestLabs.Models
{
    /// <summary> Properties of a network port. </summary>
    public partial class DevTestLabPort
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

        /// <summary> Initializes a new instance of <see cref="DevTestLabPort"/>. </summary>
        public DevTestLabPort()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DevTestLabPort"/>. </summary>
        /// <param name="transportProtocol"> Protocol type of the port. </param>
        /// <param name="backendPort"> Backend port of the target virtual machine. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DevTestLabPort(DevTestLabTransportProtocol? transportProtocol, int? backendPort, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TransportProtocol = transportProtocol;
            BackendPort = backendPort;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Protocol type of the port. </summary>
        public DevTestLabTransportProtocol? TransportProtocol { get; set; }
        /// <summary> Backend port of the target virtual machine. </summary>
        public int? BackendPort { get; set; }
    }
}
