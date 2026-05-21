// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> Test model with naming issues. </summary>
    public partial class vm_size_info
    {
        /// <summary> Gets the vmSize name. </summary>
        public string VmSizeName { get; }

        /// <summary> Gets the maximum data disk count. </summary>
        public int MaxDataDiskCount { get; }

        /// <summary> Constructor. </summary>
        public vm_size_info(string vmSizeName, int maxDataDiskCount)
        {
            this.VmSizeName = vmSizeName;
            this.MaxDataDiskCount = maxDataDiskCount;
        }
    }
}