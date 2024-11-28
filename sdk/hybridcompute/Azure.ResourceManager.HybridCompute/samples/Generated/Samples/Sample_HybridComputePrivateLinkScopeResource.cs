// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.HybridCompute.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.HybridCompute.Samples
{
    public partial class Sample_HybridComputePrivateLinkScopeResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_PrivateLinkScopeGet()
        {
            // Generated from example definition: specification/hybridcompute/resource-manager/Microsoft.HybridCompute/stable/2024-07-10/examples/privateLinkScope/PrivateLinkScopes_Get.json
            // this example is just showing the usage of "PrivateLinkScopes_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this HybridComputePrivateLinkScopeResource created on azure
            // for more information of creating HybridComputePrivateLinkScopeResource, please refer to the document of HybridComputePrivateLinkScopeResource
            string subscriptionId = "86dc51d3-92ed-4d7e-947a-775ea79b4919";
            string resourceGroupName = "my-resource-group";
            string scopeName = "my-privatelinkscope";
            ResourceIdentifier hybridComputePrivateLinkScopeResourceId = HybridComputePrivateLinkScopeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName);
            HybridComputePrivateLinkScopeResource hybridComputePrivateLinkScope = client.GetHybridComputePrivateLinkScopeResource(hybridComputePrivateLinkScopeResourceId);

            // invoke the operation
            HybridComputePrivateLinkScopeResource result = await hybridComputePrivateLinkScope.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            HybridComputePrivateLinkScopeData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_PrivateLinkScopesDelete()
        {
            // Generated from example definition: specification/hybridcompute/resource-manager/Microsoft.HybridCompute/stable/2024-07-10/examples/privateLinkScope/PrivateLinkScopes_Delete.json
            // this example is just showing the usage of "PrivateLinkScopes_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this HybridComputePrivateLinkScopeResource created on azure
            // for more information of creating HybridComputePrivateLinkScopeResource, please refer to the document of HybridComputePrivateLinkScopeResource
            string subscriptionId = "86dc51d3-92ed-4d7e-947a-775ea79b4919";
            string resourceGroupName = "my-resource-group";
            string scopeName = "my-privatelinkscope";
            ResourceIdentifier hybridComputePrivateLinkScopeResourceId = HybridComputePrivateLinkScopeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName);
            HybridComputePrivateLinkScopeResource hybridComputePrivateLinkScope = client.GetHybridComputePrivateLinkScopeResource(hybridComputePrivateLinkScopeResourceId);

            // invoke the operation
            await hybridComputePrivateLinkScope.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_PrivateLinkScopeUpdateTagsOnly()
        {
            // Generated from example definition: specification/hybridcompute/resource-manager/Microsoft.HybridCompute/stable/2024-07-10/examples/privateLinkScope/PrivateLinkScopes_UpdateTagsOnly.json
            // this example is just showing the usage of "PrivateLinkScopes_UpdateTags" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this HybridComputePrivateLinkScopeResource created on azure
            // for more information of creating HybridComputePrivateLinkScopeResource, please refer to the document of HybridComputePrivateLinkScopeResource
            string subscriptionId = "subid";
            string resourceGroupName = "my-resource-group";
            string scopeName = "my-privatelinkscope";
            ResourceIdentifier hybridComputePrivateLinkScopeResourceId = HybridComputePrivateLinkScopeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName);
            HybridComputePrivateLinkScopeResource hybridComputePrivateLinkScope = client.GetHybridComputePrivateLinkScopeResource(hybridComputePrivateLinkScopeResourceId);

            // invoke the operation
            HybridComputePrivateLinkScopePatch patch = new HybridComputePrivateLinkScopePatch
            {
                Tags =
{
["Tag1"] = "Value1",
["Tag2"] = "Value2"
},
            };
            HybridComputePrivateLinkScopeResource result = await hybridComputePrivateLinkScope.UpdateAsync(patch);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            HybridComputePrivateLinkScopeData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
