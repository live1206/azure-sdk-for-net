// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.DeviceRegistry
{
    internal class DeviceRegistryAssetEndpointProfileOperationSource : IOperationSource<DeviceRegistryAssetEndpointProfileResource>
    {
        private readonly ArmClient _client;

        internal DeviceRegistryAssetEndpointProfileOperationSource(ArmClient client)
        {
            _client = client;
        }

        DeviceRegistryAssetEndpointProfileResource IOperationSource<DeviceRegistryAssetEndpointProfileResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = DeviceRegistryAssetEndpointProfileData.DeserializeDeviceRegistryAssetEndpointProfileData(document.RootElement);
            return new DeviceRegistryAssetEndpointProfileResource(_client, data);
        }

        async ValueTask<DeviceRegistryAssetEndpointProfileResource> IOperationSource<DeviceRegistryAssetEndpointProfileResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = DeviceRegistryAssetEndpointProfileData.DeserializeDeviceRegistryAssetEndpointProfileData(document.RootElement);
            return new DeviceRegistryAssetEndpointProfileResource(_client, data);
        }
    }
}
