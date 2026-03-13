// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.EventGrid
{
    /// <summary> Backward-compat: constructor with AzureLocation for PartnerConfigurationData. </summary>
    public partial class PartnerConfigurationData
    {
        /// <summary> Initializes a new instance of <see cref="PartnerConfigurationData"/>. </summary>
        /// <param name="location"> The location. </param>
        public PartnerConfigurationData(AzureLocation location) { }
    }
}
