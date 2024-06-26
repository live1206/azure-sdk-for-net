// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Cdn
{
    internal class FrontDoorCustomDomainOperationSource : IOperationSource<FrontDoorCustomDomainResource>
    {
        private readonly ArmClient _client;

        internal FrontDoorCustomDomainOperationSource(ArmClient client)
        {
            _client = client;
        }

        FrontDoorCustomDomainResource IOperationSource<FrontDoorCustomDomainResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = FrontDoorCustomDomainData.DeserializeFrontDoorCustomDomainData(document.RootElement);
            return new FrontDoorCustomDomainResource(_client, data);
        }

        async ValueTask<FrontDoorCustomDomainResource> IOperationSource<FrontDoorCustomDomainResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = FrontDoorCustomDomainData.DeserializeFrontDoorCustomDomainData(document.RootElement);
            return new FrontDoorCustomDomainResource(_client, data);
        }
    }
}
