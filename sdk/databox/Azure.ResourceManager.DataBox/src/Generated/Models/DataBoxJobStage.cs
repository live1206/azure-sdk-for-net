// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.DataBox.Models
{
    /// <summary> Job stages. </summary>
    public partial class DataBoxJobStage
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

        /// <summary> Initializes a new instance of <see cref="DataBoxJobStage"/>. </summary>
        internal DataBoxJobStage()
        {
            DelayInformation = new ChangeTrackingList<JobDelayDetails>();
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxJobStage"/>. </summary>
        /// <param name="stageName"> Name of the job stage. </param>
        /// <param name="displayName"> Display name of the job stage. </param>
        /// <param name="stageStatus"> Status of the job stage. </param>
        /// <param name="stageTime"> Time for the job stage in UTC ISO 8601 format. </param>
        /// <param name="jobStageDetails"> Job Stage Details. </param>
        /// <param name="delayInformation"> Delay information for the job stages. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DataBoxJobStage(DataBoxStageName? stageName, string displayName, DataBoxStageStatus? stageStatus, DateTimeOffset? stageTime, BinaryData jobStageDetails, IReadOnlyList<JobDelayDetails> delayInformation, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            StageName = stageName;
            DisplayName = displayName;
            StageStatus = stageStatus;
            StageTime = stageTime;
            JobStageDetails = jobStageDetails;
            DelayInformation = delayInformation;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Name of the job stage. </summary>
        public DataBoxStageName? StageName { get; }
        /// <summary> Display name of the job stage. </summary>
        public string DisplayName { get; }
        /// <summary> Status of the job stage. </summary>
        public DataBoxStageStatus? StageStatus { get; }
        /// <summary>
        /// Job Stage Details
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
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
        public BinaryData JobStageDetails { get; }
        /// <summary> Delay information for the job stages. </summary>
        public IReadOnlyList<JobDelayDetails> DelayInformation { get; }
    }
}
