// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Synapse
{
    internal class SynapseAttachedDatabaseConfigurationOperationSource : IOperationSource<SynapseAttachedDatabaseConfigurationResource>
    {
        private readonly ArmClient _client;

        internal SynapseAttachedDatabaseConfigurationOperationSource(ArmClient client)
        {
            _client = client;
        }

        SynapseAttachedDatabaseConfigurationResource IOperationSource<SynapseAttachedDatabaseConfigurationResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = SynapseAttachedDatabaseConfigurationData.DeserializeSynapseAttachedDatabaseConfigurationData(document.RootElement);
            return new SynapseAttachedDatabaseConfigurationResource(_client, data);
        }

        async ValueTask<SynapseAttachedDatabaseConfigurationResource> IOperationSource<SynapseAttachedDatabaseConfigurationResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = SynapseAttachedDatabaseConfigurationData.DeserializeSynapseAttachedDatabaseConfigurationData(document.RootElement);
            return new SynapseAttachedDatabaseConfigurationResource(_client, data);
        }
    }
}
