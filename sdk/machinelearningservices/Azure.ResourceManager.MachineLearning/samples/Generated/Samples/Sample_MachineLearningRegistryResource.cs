// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.MachineLearning.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearning.Samples
{
    public partial class Sample_MachineLearningRegistryResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetRegistryWithSystemCreatedAccounts()
        {
            // Generated from example definition: specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/stable/2024-04-01/examples/Registries/get-SystemCreated.json
            // this example is just showing the usage of "Registries_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MachineLearningRegistryResource created on azure
            // for more information of creating MachineLearningRegistryResource, please refer to the document of MachineLearningRegistryResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "test-rg";
            string registryName = "string";
            ResourceIdentifier machineLearningRegistryResourceId = MachineLearningRegistryResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, registryName);
            MachineLearningRegistryResource machineLearningRegistry = client.GetMachineLearningRegistryResource(machineLearningRegistryResourceId);

            // invoke the operation
            MachineLearningRegistryResource result = await machineLearningRegistry.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MachineLearningRegistryData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetRegistryWithUserCreatedAccounts()
        {
            // Generated from example definition: specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/stable/2024-04-01/examples/Registries/get-UserCreated.json
            // this example is just showing the usage of "Registries_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MachineLearningRegistryResource created on azure
            // for more information of creating MachineLearningRegistryResource, please refer to the document of MachineLearningRegistryResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "test-rg";
            string registryName = "string";
            ResourceIdentifier machineLearningRegistryResourceId = MachineLearningRegistryResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, registryName);
            MachineLearningRegistryResource machineLearningRegistry = client.GetMachineLearningRegistryResource(machineLearningRegistryResourceId);

            // invoke the operation
            MachineLearningRegistryResource result = await machineLearningRegistry.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MachineLearningRegistryData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_DeleteRegistry()
        {
            // Generated from example definition: specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/stable/2024-04-01/examples/Registries/delete.json
            // this example is just showing the usage of "Registries_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MachineLearningRegistryResource created on azure
            // for more information of creating MachineLearningRegistryResource, please refer to the document of MachineLearningRegistryResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "test-rg";
            string registryName = "string";
            ResourceIdentifier machineLearningRegistryResourceId = MachineLearningRegistryResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, registryName);
            MachineLearningRegistryResource machineLearningRegistry = client.GetMachineLearningRegistryResource(machineLearningRegistryResourceId);

            // invoke the operation
            await machineLearningRegistry.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_UpdateRegistryWithSystemCreatedAccounts()
        {
            // Generated from example definition: specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/stable/2024-04-01/examples/Registries/update-SystemCreated.json
            // this example is just showing the usage of "Registries_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MachineLearningRegistryResource created on azure
            // for more information of creating MachineLearningRegistryResource, please refer to the document of MachineLearningRegistryResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "test-rg";
            string registryName = "string";
            ResourceIdentifier machineLearningRegistryResourceId = MachineLearningRegistryResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, registryName);
            MachineLearningRegistryResource machineLearningRegistry = client.GetMachineLearningRegistryResource(machineLearningRegistryResourceId);

            // invoke the operation
            MachineLearningRegistryPatch patch = new MachineLearningRegistryPatch
            {
                Identity = new ManagedServiceIdentity("SystemAssigned")
                {
                    UserAssignedIdentities =
{
[new ResourceIdentifier("string")] = new UserAssignedIdentity()
},
                },
                Sku = new MachineLearningSkuPatch
                {
                    Name = "string",
                    Tier = MachineLearningSkuTier.Basic,
                    Size = "string",
                    Family = "string",
                    Capacity = 1,
                },
                Tags = { },
            };
            MachineLearningRegistryResource result = await machineLearningRegistry.UpdateAsync(patch);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MachineLearningRegistryData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_UpdateRegistryWithUserCreatedAccounts()
        {
            // Generated from example definition: specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/stable/2024-04-01/examples/Registries/update-UserCreated.json
            // this example is just showing the usage of "Registries_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MachineLearningRegistryResource created on azure
            // for more information of creating MachineLearningRegistryResource, please refer to the document of MachineLearningRegistryResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "test-rg";
            string registryName = "string";
            ResourceIdentifier machineLearningRegistryResourceId = MachineLearningRegistryResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, registryName);
            MachineLearningRegistryResource machineLearningRegistry = client.GetMachineLearningRegistryResource(machineLearningRegistryResourceId);

            // invoke the operation
            MachineLearningRegistryPatch patch = new MachineLearningRegistryPatch
            {
                Identity = new ManagedServiceIdentity("UserAssigned")
                {
                    UserAssignedIdentities =
{
[new ResourceIdentifier("string")] = new UserAssignedIdentity()
},
                },
                Sku = new MachineLearningSkuPatch
                {
                    Name = "string",
                    Tier = MachineLearningSkuTier.Basic,
                    Size = "string",
                    Family = "string",
                    Capacity = 1,
                },
                Tags = { },
            };
            MachineLearningRegistryResource result = await machineLearningRegistry.UpdateAsync(patch);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MachineLearningRegistryData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetBlobReferenceSasRegistryDataReference_GetBlobReferenceSASDataReference()
        {
            // Generated from example definition: specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/stable/2024-04-01/examples/DataReference/getBlobReferenceSAS.json
            // this example is just showing the usage of "RegistryDataReferences_GetBlobReferenceSas" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MachineLearningRegistryResource created on azure
            // for more information of creating MachineLearningRegistryResource, please refer to the document of MachineLearningRegistryResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "test-rg";
            string registryName = "registryName";
            ResourceIdentifier machineLearningRegistryResourceId = MachineLearningRegistryResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, registryName);
            MachineLearningRegistryResource machineLearningRegistry = client.GetMachineLearningRegistryResource(machineLearningRegistryResourceId);

            // invoke the operation
            string name = "string";
            string version = "string";
            BlobReferenceSasContent content = new BlobReferenceSasContent
            {
                AssetId = "string",
                BlobUri = new Uri("https://www.contoso.com/example"),
            };
            BlobReferenceSasResult result = await machineLearningRegistry.GetBlobReferenceSasRegistryDataReferenceAsync(name, version, content);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task RemoveRegions_RemoveRegionsFromRegistry()
        {
            // Generated from example definition: specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/stable/2024-04-01/examples/Registries/removeRegions.json
            // this example is just showing the usage of "Registries_RemoveRegions" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MachineLearningRegistryResource created on azure
            // for more information of creating MachineLearningRegistryResource, please refer to the document of MachineLearningRegistryResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "test-rg";
            string registryName = "string";
            ResourceIdentifier machineLearningRegistryResourceId = MachineLearningRegistryResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, registryName);
            MachineLearningRegistryResource machineLearningRegistry = client.GetMachineLearningRegistryResource(machineLearningRegistryResourceId);

            // invoke the operation
            MachineLearningRegistryData data = new MachineLearningRegistryData(new AzureLocation("string"))
            {
                Identity = new ManagedServiceIdentity("None")
                {
                    UserAssignedIdentities =
{
[new ResourceIdentifier("string")] = new UserAssignedIdentity()
},
                },
                Kind = "string",
                Sku = new MachineLearningSku("string")
                {
                    Tier = MachineLearningSkuTier.Free,
                    Size = "string",
                    Family = "string",
                    Capacity = 1,
                },
                DiscoveryUri = new Uri("string"),
                IntellectualPropertyPublisher = "string",
                ManagedResourceId = new ResourceIdentifier("string"),
                MlFlowRegistryUri = new Uri("string"),
                RegistryPrivateEndpointConnections = {new RegistryPrivateEndpointConnection
{
Id = new ResourceIdentifier("string"),
Location = new AzureLocation("string"),
GroupIds = {"string"},
PrivateEndpoint = new RegistryPrivateEndpoint
{
SubnetArmId = new ResourceIdentifier("string"),
},
RegistryPrivateLinkServiceConnectionState = new RegistryPrivateLinkServiceConnectionState
{
ActionsRequired = "string",
Description = "string",
Status = EndpointServiceConnectionStatus.Approved,
},
ProvisioningState = "string",
}},
                PublicNetworkAccess = "string",
                RegionDetails = {new RegistryRegionArmDetails
{
AcrDetails = {new RegistryAcrDetails
{
SystemCreatedAcrAccount = new SystemCreatedAcrAccount
{
AcrAccountName = "string",
AcrAccountSku = "string",
ArmResourceId = new ResourceIdentifier("string"),
},
ArmResourceId = new ResourceIdentifier("string"),
}},
Location = new AzureLocation("string"),
StorageAccountDetails = {new StorageAccountDetails
{
SystemCreatedStorageAccount = new SystemCreatedStorageAccount
{
AllowBlobPublicAccess = false,
ArmResourceId = new ResourceIdentifier("string"),
StorageAccountHnsEnabled = false,
StorageAccountName = "string",
StorageAccountType = "string",
},
ArmResourceId = new ResourceIdentifier("string"),
}},
}},
                Tags = { },
            };
            ArmOperation<MachineLearningRegistryResource> lro = await machineLearningRegistry.RemoveRegionsAsync(WaitUntil.Completed, data);
            MachineLearningRegistryResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MachineLearningRegistryData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
