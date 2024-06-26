// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Confluent.Models
{
    /// <summary> Details about environment name, metadata and environment id of an environment. </summary>
    public partial class AccessEnvironmentRecord
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

        /// <summary> Initializes a new instance of <see cref="AccessEnvironmentRecord"/>. </summary>
        internal AccessEnvironmentRecord()
        {
        }

        /// <summary> Initializes a new instance of <see cref="AccessEnvironmentRecord"/>. </summary>
        /// <param name="kind"> Type of environment. </param>
        /// <param name="id"> Id of the environment. </param>
        /// <param name="metadata"> Metadata of the record. </param>
        /// <param name="displayName"> Display name of the user. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AccessEnvironmentRecord(string kind, string id, MetadataEntity metadata, string displayName, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Kind = kind;
            Id = id;
            Metadata = metadata;
            DisplayName = displayName;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Type of environment. </summary>
        public string Kind { get; }
        /// <summary> Id of the environment. </summary>
        public string Id { get; }
        /// <summary> Metadata of the record. </summary>
        public MetadataEntity Metadata { get; }
        /// <summary> Display name of the user. </summary>
        public string DisplayName { get; }
    }
}
