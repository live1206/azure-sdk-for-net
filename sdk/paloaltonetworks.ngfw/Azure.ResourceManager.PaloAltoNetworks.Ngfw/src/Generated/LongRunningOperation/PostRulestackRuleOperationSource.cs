// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    internal class PostRulestackRuleOperationSource : IOperationSource<PostRulestackRuleResource>
    {
        private readonly ArmClient _client;

        internal PostRulestackRuleOperationSource(ArmClient client)
        {
            _client = client;
        }

        PostRulestackRuleResource IOperationSource<PostRulestackRuleResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = PostRulestackRuleData.DeserializePostRulestackRuleData(document.RootElement);
            return new PostRulestackRuleResource(_client, data);
        }

        async ValueTask<PostRulestackRuleResource> IOperationSource<PostRulestackRuleResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = PostRulestackRuleData.DeserializePostRulestackRuleData(document.RootElement);
            return new PostRulestackRuleResource(_client, data);
        }
    }
}
