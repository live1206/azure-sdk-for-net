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
    // IOperationSource that converts the LRO response into an EventGridTopicPrivateEndpointConnectionResource.
    internal class TopicPrivateEndpointConnectionOperationSource : IOperationSource<EventGridTopicPrivateEndpointConnectionResource>
    {
        private readonly ArmClient _client;

        internal TopicPrivateEndpointConnectionOperationSource(ArmClient client) => _client = client;

        EventGridTopicPrivateEndpointConnectionResource IOperationSource<EventGridTopicPrivateEndpointConnectionResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            var data = EventGridPrivateEndpointConnectionData.DeserializeEventGridPrivateEndpointConnectionData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new EventGridTopicPrivateEndpointConnectionResource(_client, data);
        }

        async ValueTask<EventGridTopicPrivateEndpointConnectionResource> IOperationSource<EventGridTopicPrivateEndpointConnectionResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = EventGridPrivateEndpointConnectionData.DeserializeEventGridPrivateEndpointConnectionData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new EventGridTopicPrivateEndpointConnectionResource(_client, data);
        }
    }
}
