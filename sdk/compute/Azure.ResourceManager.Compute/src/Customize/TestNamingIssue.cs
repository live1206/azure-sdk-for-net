// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> Test model with intentional naming issues for review workflow testing. </summary>
    public partial class vm_size_info
    {
        /// <summary> Gets the vmSize name. </summary>
        public string vmSizeName { get; }

        /// <summary> Gets the Max_Data_Disk_Count. </summary>
        public int Max_Data_Disk_Count { get; }

        /// <summary> Constructor. </summary>
        public vm_size_info(string vmSizeName, int maxDataDiskCount)
        {
            this.vmSizeName = vmSizeName;
            this.Max_Data_Disk_Count = maxDataDiskCount;
        }
    }
}