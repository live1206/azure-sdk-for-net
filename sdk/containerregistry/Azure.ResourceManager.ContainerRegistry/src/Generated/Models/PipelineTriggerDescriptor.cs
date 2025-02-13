// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    /// <summary> The PipelineTriggerDescriptor. </summary>
    internal partial class PipelineTriggerDescriptor
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

        /// <summary> Initializes a new instance of <see cref="PipelineTriggerDescriptor"/>. </summary>
        internal PipelineTriggerDescriptor()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PipelineTriggerDescriptor"/>. </summary>
        /// <param name="sourceTrigger"> The source trigger that caused the pipeline run. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal PipelineTriggerDescriptor(PipelineSourceTriggerDescriptor sourceTrigger, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            SourceTrigger = sourceTrigger;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The source trigger that caused the pipeline run. </summary>
        internal PipelineSourceTriggerDescriptor SourceTrigger { get; }
        /// <summary> The timestamp when the source update happened. </summary>
        [WirePath("sourceTrigger.timestamp")]
        public DateTimeOffset? SourceTriggerTimestamp
        {
            get => SourceTrigger?.Timestamp;
        }
    }
}
