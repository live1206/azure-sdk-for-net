// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.ResourceManager.MobileNetwork.Samples
{
    public partial class Sample_MobileNetworkSiteCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CreateOrUpdate_CreateMobileNetworkSite()
        {
            // Generated from example definition: specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2024-04-01/examples/SiteCreate.json
            // this example is just showing the usage of "Sites_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MobileNetworkResource created on azure
            // for more information of creating MobileNetworkResource, please refer to the document of MobileNetworkResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "rg1";
            string mobileNetworkName = "testMobileNetwork";
            ResourceIdentifier mobileNetworkResourceId = MobileNetworkResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, mobileNetworkName);
            MobileNetworkResource mobileNetwork = client.GetMobileNetworkResource(mobileNetworkResourceId);

            // get the collection of this MobileNetworkSiteResource
            MobileNetworkSiteCollection collection = mobileNetwork.GetMobileNetworkSites();

            // invoke the operation
            string siteName = "testSite";
            MobileNetworkSiteData data = new MobileNetworkSiteData(new AzureLocation("testLocation"));
            ArmOperation<MobileNetworkSiteResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, siteName, data);
            MobileNetworkSiteResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MobileNetworkSiteData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetMobileNetworkSite()
        {
            // Generated from example definition: specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2024-04-01/examples/SiteGet.json
            // this example is just showing the usage of "Sites_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MobileNetworkResource created on azure
            // for more information of creating MobileNetworkResource, please refer to the document of MobileNetworkResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "rg1";
            string mobileNetworkName = "testMobileNetwork";
            ResourceIdentifier mobileNetworkResourceId = MobileNetworkResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, mobileNetworkName);
            MobileNetworkResource mobileNetwork = client.GetMobileNetworkResource(mobileNetworkResourceId);

            // get the collection of this MobileNetworkSiteResource
            MobileNetworkSiteCollection collection = mobileNetwork.GetMobileNetworkSites();

            // invoke the operation
            string siteName = "testSite";
            MobileNetworkSiteResource result = await collection.GetAsync(siteName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MobileNetworkSiteData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_ListMobileNetworkSitesInAMobileNetwork()
        {
            // Generated from example definition: specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2024-04-01/examples/SiteListByMobileNetwork.json
            // this example is just showing the usage of "Sites_ListByMobileNetwork" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MobileNetworkResource created on azure
            // for more information of creating MobileNetworkResource, please refer to the document of MobileNetworkResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "rg1";
            string mobileNetworkName = "testMobileNetwork";
            ResourceIdentifier mobileNetworkResourceId = MobileNetworkResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, mobileNetworkName);
            MobileNetworkResource mobileNetwork = client.GetMobileNetworkResource(mobileNetworkResourceId);

            // get the collection of this MobileNetworkSiteResource
            MobileNetworkSiteCollection collection = mobileNetwork.GetMobileNetworkSites();

            // invoke the operation and iterate over the result
            await foreach (MobileNetworkSiteResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                MobileNetworkSiteData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_GetMobileNetworkSite()
        {
            // Generated from example definition: specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2024-04-01/examples/SiteGet.json
            // this example is just showing the usage of "Sites_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MobileNetworkResource created on azure
            // for more information of creating MobileNetworkResource, please refer to the document of MobileNetworkResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "rg1";
            string mobileNetworkName = "testMobileNetwork";
            ResourceIdentifier mobileNetworkResourceId = MobileNetworkResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, mobileNetworkName);
            MobileNetworkResource mobileNetwork = client.GetMobileNetworkResource(mobileNetworkResourceId);

            // get the collection of this MobileNetworkSiteResource
            MobileNetworkSiteCollection collection = mobileNetwork.GetMobileNetworkSites();

            // invoke the operation
            string siteName = "testSite";
            bool result = await collection.ExistsAsync(siteName);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_GetMobileNetworkSite()
        {
            // Generated from example definition: specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2024-04-01/examples/SiteGet.json
            // this example is just showing the usage of "Sites_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MobileNetworkResource created on azure
            // for more information of creating MobileNetworkResource, please refer to the document of MobileNetworkResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "rg1";
            string mobileNetworkName = "testMobileNetwork";
            ResourceIdentifier mobileNetworkResourceId = MobileNetworkResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, mobileNetworkName);
            MobileNetworkResource mobileNetwork = client.GetMobileNetworkResource(mobileNetworkResourceId);

            // get the collection of this MobileNetworkSiteResource
            MobileNetworkSiteCollection collection = mobileNetwork.GetMobileNetworkSites();

            // invoke the operation
            string siteName = "testSite";
            NullableResponse<MobileNetworkSiteResource> response = await collection.GetIfExistsAsync(siteName);
            MobileNetworkSiteResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                MobileNetworkSiteData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
