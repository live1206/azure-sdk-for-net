// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Projects
{
    /// <summary> Unknown version of TargetModelConfig. </summary>
    internal partial class UnknownTargetModelConfig : TargetModelConfig
    {
        /// <summary> Initializes a new instance of <see cref="UnknownTargetModelConfig"/>. </summary>
        /// <param name="type"> Type of the model configuration. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownTargetModelConfig(string type, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(type, serializedAdditionalRawData)
        {
        }

        /// <summary> Initializes a new instance of <see cref="UnknownTargetModelConfig"/> for deserialization. </summary>
        internal UnknownTargetModelConfig()
        {
        }
    }
}
