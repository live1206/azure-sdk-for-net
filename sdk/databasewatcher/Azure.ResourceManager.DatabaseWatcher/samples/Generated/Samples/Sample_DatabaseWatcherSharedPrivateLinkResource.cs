// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.DatabaseWatcher.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DatabaseWatcher.Samples
{
    public partial class Sample_DatabaseWatcherSharedPrivateLinkResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_SharedPrivateLinkResourcesGetMaximumSet()
        {
            // Generated from example definition: 2025-01-02/SharedPrivateLinkResources_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "SharedPrivateLinkResource_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DatabaseWatcherSharedPrivateLinkResource created on azure
            // for more information of creating DatabaseWatcherSharedPrivateLinkResource, please refer to the document of DatabaseWatcherSharedPrivateLinkResource
            string subscriptionId = "49e0fbd3-75e8-44e7-96fd-5b64d9ad818d";
            string resourceGroupName = "apiTest-ddat4p";
            string watcherName = "databasemo3ej9ih";
            string sharedPrivateLinkResourceName = "monitoringh22eed";
            ResourceIdentifier databaseWatcherSharedPrivateLinkResourceId = DatabaseWatcherSharedPrivateLinkResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, watcherName, sharedPrivateLinkResourceName);
            DatabaseWatcherSharedPrivateLinkResource databaseWatcherSharedPrivateLinkResource = client.GetDatabaseWatcherSharedPrivateLinkResource(databaseWatcherSharedPrivateLinkResourceId);

            // invoke the operation
            DatabaseWatcherSharedPrivateLinkResource result = await databaseWatcherSharedPrivateLinkResource.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DatabaseWatcherSharedPrivateLinkResourceData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_SharedPrivateLinkResourcesDeleteMaximumSet()
        {
            // Generated from example definition: 2025-01-02/SharedPrivateLinkResources_Delete_MaximumSet_Gen.json
            // this example is just showing the usage of "SharedPrivateLinkResource_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DatabaseWatcherSharedPrivateLinkResource created on azure
            // for more information of creating DatabaseWatcherSharedPrivateLinkResource, please refer to the document of DatabaseWatcherSharedPrivateLinkResource
            string subscriptionId = "49e0fbd3-75e8-44e7-96fd-5b64d9ad818d";
            string resourceGroupName = "apiTest-ddat4p";
            string watcherName = "databasemo3ej9ih";
            string sharedPrivateLinkResourceName = "monitoringh22eed";
            ResourceIdentifier databaseWatcherSharedPrivateLinkResourceId = DatabaseWatcherSharedPrivateLinkResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, watcherName, sharedPrivateLinkResourceName);
            DatabaseWatcherSharedPrivateLinkResource databaseWatcherSharedPrivateLinkResource = client.GetDatabaseWatcherSharedPrivateLinkResource(databaseWatcherSharedPrivateLinkResourceId);

            // invoke the operation
            await databaseWatcherSharedPrivateLinkResource.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_SharedPrivateLinkResourcesCreateMaximumSet()
        {
            // Generated from example definition: 2025-01-02/SharedPrivateLinkResources_Create_MaximumSet_Gen.json
            // this example is just showing the usage of "SharedPrivateLinkResource_Create" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DatabaseWatcherSharedPrivateLinkResource created on azure
            // for more information of creating DatabaseWatcherSharedPrivateLinkResource, please refer to the document of DatabaseWatcherSharedPrivateLinkResource
            string subscriptionId = "49e0fbd3-75e8-44e7-96fd-5b64d9ad818d";
            string resourceGroupName = "apiTest-ddat4p";
            string watcherName = "databasemo3ej9ih";
            string sharedPrivateLinkResourceName = "monitoringh22eed";
            ResourceIdentifier databaseWatcherSharedPrivateLinkResourceId = DatabaseWatcherSharedPrivateLinkResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, watcherName, sharedPrivateLinkResourceName);
            DatabaseWatcherSharedPrivateLinkResource databaseWatcherSharedPrivateLinkResource = client.GetDatabaseWatcherSharedPrivateLinkResource(databaseWatcherSharedPrivateLinkResourceId);

            // invoke the operation
            DatabaseWatcherSharedPrivateLinkResourceData data = new DatabaseWatcherSharedPrivateLinkResourceData
            {
                Properties = new DatabaseWatcherSharedPrivateLinkResourceProperties(new ResourceIdentifier("/subscriptions/49e0fbd3-75e8-44e7-96fd-5b64d9ad818d/resourceGroups/apiTest-ddat4p/providers/Microsoft.KeyVault/vaults/kvmo3ej9ih"), "vault", "request message")
                {
                    DnsZone = "ec3ae9d410ba",
                },
            };
            ArmOperation<DatabaseWatcherSharedPrivateLinkResource> lro = await databaseWatcherSharedPrivateLinkResource.UpdateAsync(WaitUntil.Completed, data);
            DatabaseWatcherSharedPrivateLinkResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DatabaseWatcherSharedPrivateLinkResourceData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
