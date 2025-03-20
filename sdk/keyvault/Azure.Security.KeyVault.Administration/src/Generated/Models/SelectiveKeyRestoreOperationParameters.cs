// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.Security.KeyVault.Administration.Models
{
    /// <summary> The authentication method and location for the selective key restore operation. </summary>
    internal partial class SelectiveKeyRestoreOperationParameters
    {
        /// <summary> Initializes a new instance of <see cref="SelectiveKeyRestoreOperationParameters"/>. </summary>
        /// <param name="sasTokenParameters"> A user-provided SAS token to an Azure blob storage container. </param>
        /// <param name="folder"> The Folder name of the blob where the previous successful full backup was stored. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sasTokenParameters"/> or <paramref name="folder"/> is null. </exception>
        public SelectiveKeyRestoreOperationParameters(SASTokenParameter sasTokenParameters, string folder)
        {
            Argument.AssertNotNull(sasTokenParameters, nameof(sasTokenParameters));
            Argument.AssertNotNull(folder, nameof(folder));

            SasTokenParameters = sasTokenParameters;
            Folder = folder;
        }

        /// <summary> A user-provided SAS token to an Azure blob storage container. </summary>
        public SASTokenParameter SasTokenParameters { get; }
        /// <summary> The Folder name of the blob where the previous successful full backup was stored. </summary>
        public string Folder { get; }
    }
}
