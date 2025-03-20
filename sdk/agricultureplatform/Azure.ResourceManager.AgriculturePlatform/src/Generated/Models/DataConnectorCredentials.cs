// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.AgriculturePlatform.Models
{
    /// <summary> The properties related to an AgriService data connector. </summary>
    public partial class DataConnectorCredentials
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

        /// <summary> Initializes a new instance of <see cref="DataConnectorCredentials"/>. </summary>
        public DataConnectorCredentials()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DataConnectorCredentials"/>. </summary>
        /// <param name="kind"> Type of credential. </param>
        /// <param name="clientId"> Client Id associated with the provider, if type of credentials is OAuthClientCredentials. </param>
        /// <param name="keyVaultUri"> Uri of the key vault. </param>
        /// <param name="keyName"> Name of the key vault key. </param>
        /// <param name="keyVersion"> Version of the key vault key. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DataConnectorCredentials(AuthCredentialsKind? kind, string clientId, string keyVaultUri, string keyName, string keyVersion, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Kind = kind;
            ClientId = clientId;
            KeyVaultUri = keyVaultUri;
            KeyName = keyName;
            KeyVersion = keyVersion;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Type of credential. </summary>
        public AuthCredentialsKind? Kind { get; set; }
        /// <summary> Client Id associated with the provider, if type of credentials is OAuthClientCredentials. </summary>
        public string ClientId { get; set; }
        /// <summary> Uri of the key vault. </summary>
        public string KeyVaultUri { get; set; }
        /// <summary> Name of the key vault key. </summary>
        public string KeyName { get; set; }
        /// <summary> Version of the key vault key. </summary>
        public string KeyVersion { get; set; }
    }
}
