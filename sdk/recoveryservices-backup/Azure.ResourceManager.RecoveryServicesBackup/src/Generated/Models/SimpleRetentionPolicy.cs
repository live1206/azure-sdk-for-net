// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    /// <summary> Simple policy retention. </summary>
    public partial class SimpleRetentionPolicy : BackupRetentionPolicy
    {
        /// <summary> Initializes a new instance of <see cref="SimpleRetentionPolicy"/>. </summary>
        public SimpleRetentionPolicy()
        {
            RetentionPolicyType = "SimpleRetentionPolicy";
        }

        /// <summary> Initializes a new instance of <see cref="SimpleRetentionPolicy"/>. </summary>
        /// <param name="retentionPolicyType"> This property will be used as the discriminator for deciding the specific types in the polymorphic chain of types. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="retentionDuration"> Retention duration of the protection policy. </param>
        internal SimpleRetentionPolicy(string retentionPolicyType, IDictionary<string, BinaryData> serializedAdditionalRawData, RetentionDuration retentionDuration) : base(retentionPolicyType, serializedAdditionalRawData)
        {
            RetentionDuration = retentionDuration;
            RetentionPolicyType = retentionPolicyType ?? "SimpleRetentionPolicy";
        }

        /// <summary> Retention duration of the protection policy. </summary>
        public RetentionDuration RetentionDuration { get; set; }
    }
}
