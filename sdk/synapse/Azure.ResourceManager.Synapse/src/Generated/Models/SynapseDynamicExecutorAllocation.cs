// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Synapse.Models
{
    /// <summary> Dynamic Executor Allocation Properties. </summary>
    public partial class SynapseDynamicExecutorAllocation
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

        /// <summary> Initializes a new instance of <see cref="SynapseDynamicExecutorAllocation"/>. </summary>
        public SynapseDynamicExecutorAllocation()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SynapseDynamicExecutorAllocation"/>. </summary>
        /// <param name="isEnabled"> Indicates whether Dynamic Executor Allocation is enabled or not. </param>
        /// <param name="minExecutors"> The minimum number of executors alloted. </param>
        /// <param name="maxExecutors"> The maximum number of executors alloted. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SynapseDynamicExecutorAllocation(bool? isEnabled, int? minExecutors, int? maxExecutors, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            IsEnabled = isEnabled;
            MinExecutors = minExecutors;
            MaxExecutors = maxExecutors;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Indicates whether Dynamic Executor Allocation is enabled or not. </summary>
        public bool? IsEnabled { get; set; }
        /// <summary> The minimum number of executors alloted. </summary>
        public int? MinExecutors { get; set; }
        /// <summary> The maximum number of executors alloted. </summary>
        public int? MaxExecutors { get; set; }
    }
}
