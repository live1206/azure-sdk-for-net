// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary> Container for chunks. </summary>
    public partial class RecordingStorageInfo
    {
        /// <summary> Initializes a new instance of <see cref="RecordingStorageInfo"/>. </summary>
        internal RecordingStorageInfo()
        {
            RecordingChunks = new ChangeTrackingList<RecordingChunkStorageInfo>();
        }

        /// <summary> Initializes a new instance of <see cref="RecordingStorageInfo"/>. </summary>
        /// <param name="recordingChunks"> Collection of {Microsoft.Skype.Platform.ExecutionAgent.Azure.Communication.Service.ServerCalling.Content.Contracts.ALPHA4_2024_09_01_preview.Models.RecordingChunkStorageInfo}. </param>
        internal RecordingStorageInfo(IReadOnlyList<RecordingChunkStorageInfo> recordingChunks)
        {
            RecordingChunks = recordingChunks;
        }

        /// <summary> Collection of {Microsoft.Skype.Platform.ExecutionAgent.Azure.Communication.Service.ServerCalling.Content.Contracts.ALPHA4_2024_09_01_preview.Models.RecordingChunkStorageInfo}. </summary>
        public IReadOnlyList<RecordingChunkStorageInfo> RecordingChunks { get; }
    }
}
