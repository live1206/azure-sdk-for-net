// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> The minimum number of violations required within the selected lookback time window required to raise an alert. </summary>
    public partial class DynamicThresholdFailingPeriods
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

        /// <summary> Initializes a new instance of <see cref="DynamicThresholdFailingPeriods"/>. </summary>
        /// <param name="numberOfEvaluationPeriods"> The number of aggregated lookback points. The lookback time window is calculated based on the aggregation granularity (windowSize) and the selected number of aggregated points. </param>
        /// <param name="minFailingPeriodsToAlert"> The number of violations to trigger an alert. Should be smaller or equal to numberOfEvaluationPeriods. </param>
        public DynamicThresholdFailingPeriods(float numberOfEvaluationPeriods, float minFailingPeriodsToAlert)
        {
            NumberOfEvaluationPeriods = numberOfEvaluationPeriods;
            MinFailingPeriodsToAlert = minFailingPeriodsToAlert;
        }

        /// <summary> Initializes a new instance of <see cref="DynamicThresholdFailingPeriods"/>. </summary>
        /// <param name="numberOfEvaluationPeriods"> The number of aggregated lookback points. The lookback time window is calculated based on the aggregation granularity (windowSize) and the selected number of aggregated points. </param>
        /// <param name="minFailingPeriodsToAlert"> The number of violations to trigger an alert. Should be smaller or equal to numberOfEvaluationPeriods. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DynamicThresholdFailingPeriods(float numberOfEvaluationPeriods, float minFailingPeriodsToAlert, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            NumberOfEvaluationPeriods = numberOfEvaluationPeriods;
            MinFailingPeriodsToAlert = minFailingPeriodsToAlert;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="DynamicThresholdFailingPeriods"/> for deserialization. </summary>
        internal DynamicThresholdFailingPeriods()
        {
        }

        /// <summary> The number of aggregated lookback points. The lookback time window is calculated based on the aggregation granularity (windowSize) and the selected number of aggregated points. </summary>
        public float NumberOfEvaluationPeriods { get; set; }
        /// <summary> The number of violations to trigger an alert. Should be smaller or equal to numberOfEvaluationPeriods. </summary>
        public float MinFailingPeriodsToAlert { get; set; }
    }
}
