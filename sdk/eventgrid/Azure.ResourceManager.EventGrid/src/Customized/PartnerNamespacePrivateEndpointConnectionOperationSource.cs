// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid
{
    // IOperationSource that converts the LRO response into an EventGridPartnerNamespacePrivateEndpointConnectionResource.
    internal class PartnerNamespacePrivateEndpointConnectionOperationSource : IOperationSource<EventGridPartnerNamespacePrivateEndpointConnectionResource>
    {
        private readonly ArmClient _client;

        internal PartnerNamespacePrivateEndpointConnectionOperationSource(ArmClient client) => _client = client;

        EventGridPartnerNamespacePrivateEndpointConnectionResource IOperationSource<EventGridPartnerNamespacePrivateEndpointConnectionResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            var data = EventGridPrivateEndpointConnectionData.DeserializeEventGridPrivateEndpointConnectionData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new EventGridPartnerNamespacePrivateEndpointConnectionResource(_client, data);
        }

        async ValueTask<EventGridPartnerNamespacePrivateEndpointConnectionResource> IOperationSource<EventGridPartnerNamespacePrivateEndpointConnectionResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = EventGridPrivateEndpointConnectionData.DeserializeEventGridPrivateEndpointConnectionData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new EventGridPartnerNamespacePrivateEndpointConnectionResource(_client, data);
        }
    }
}
