// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    /// <summary> Class representing the H264 Configuration. </summary>
    public partial class H264Configuration
    {
        /// <summary> Initializes a new instance of <see cref="H264Configuration"/>. </summary>
        public H264Configuration()
        {
        }

        /// <summary> Initializes a new instance of <see cref="H264Configuration"/>. </summary>
        /// <param name="govLength"> Group of Video frames length. </param>
        /// <param name="profile"> The H264 Profile. </param>
        internal H264Configuration(float? govLength, H264Profile? profile)
        {
            GovLength = govLength;
            Profile = profile;
        }

        /// <summary> Group of Video frames length. </summary>
        public float? GovLength { get; set; }
        /// <summary> The H264 Profile. </summary>
        public H264Profile? Profile { get; set; }
    }
}
