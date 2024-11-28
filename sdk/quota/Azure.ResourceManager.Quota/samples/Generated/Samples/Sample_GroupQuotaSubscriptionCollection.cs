// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.ResourceManager.Quota.Samples
{
    public partial class Sample_GroupQuotaSubscriptionCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CreateOrUpdate_GroupQuotaSubscriptionsPutSubscriptions()
        {
            // Generated from example definition: specification/quota/resource-manager/Microsoft.Quota/preview/2023-06-01-preview/examples/GroupQuotasSubscriptions/PutGroupQuotasSubscription.json
            // this example is just showing the usage of "GroupQuotaSubscriptions_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this GroupQuotaEntityResource created on azure
            // for more information of creating GroupQuotaEntityResource, please refer to the document of GroupQuotaEntityResource
            string managementGroupId = "E7EC67B3-7657-4966-BFFC-41EFD36BAA09";
            string groupQuotaName = "groupquota1";
            ResourceIdentifier groupQuotaEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);
            GroupQuotaEntityResource groupQuotaEntity = client.GetGroupQuotaEntityResource(groupQuotaEntityResourceId);

            // get the collection of this GroupQuotaSubscriptionResource
            GroupQuotaSubscriptionCollection collection = groupQuotaEntity.GetGroupQuotaSubscriptions();

            // invoke the operation
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            ArmOperation<GroupQuotaSubscriptionResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, subscriptionId);
            GroupQuotaSubscriptionResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            GroupQuotaSubscriptionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GroupQuotaSubscriptionsGetSubscriptions()
        {
            // Generated from example definition: specification/quota/resource-manager/Microsoft.Quota/preview/2023-06-01-preview/examples/GroupQuotasSubscriptions/GetGroupQuotaSubscriptions.json
            // this example is just showing the usage of "GroupQuotaSubscriptions_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this GroupQuotaEntityResource created on azure
            // for more information of creating GroupQuotaEntityResource, please refer to the document of GroupQuotaEntityResource
            string managementGroupId = "E7EC67B3-7657-4966-BFFC-41EFD36BAA09";
            string groupQuotaName = "groupquota1";
            ResourceIdentifier groupQuotaEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);
            GroupQuotaEntityResource groupQuotaEntity = client.GetGroupQuotaEntityResource(groupQuotaEntityResourceId);

            // get the collection of this GroupQuotaSubscriptionResource
            GroupQuotaSubscriptionCollection collection = groupQuotaEntity.GetGroupQuotaSubscriptions();

            // invoke the operation
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            GroupQuotaSubscriptionResource result = await collection.GetAsync(subscriptionId);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            GroupQuotaSubscriptionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_GroupQuotaSubscriptionsListSubscriptions()
        {
            // Generated from example definition: specification/quota/resource-manager/Microsoft.Quota/preview/2023-06-01-preview/examples/GroupQuotasSubscriptions/ListGroupQuotaSubscriptions.json
            // this example is just showing the usage of "GroupQuotaSubscriptions_List" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this GroupQuotaEntityResource created on azure
            // for more information of creating GroupQuotaEntityResource, please refer to the document of GroupQuotaEntityResource
            string managementGroupId = "E7EC67B3-7657-4966-BFFC-41EFD36BAA09";
            string groupQuotaName = "groupquota1";
            ResourceIdentifier groupQuotaEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);
            GroupQuotaEntityResource groupQuotaEntity = client.GetGroupQuotaEntityResource(groupQuotaEntityResourceId);

            // get the collection of this GroupQuotaSubscriptionResource
            GroupQuotaSubscriptionCollection collection = groupQuotaEntity.GetGroupQuotaSubscriptions();

            // invoke the operation and iterate over the result
            await foreach (GroupQuotaSubscriptionResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                GroupQuotaSubscriptionData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_GroupQuotaSubscriptionsGetSubscriptions()
        {
            // Generated from example definition: specification/quota/resource-manager/Microsoft.Quota/preview/2023-06-01-preview/examples/GroupQuotasSubscriptions/GetGroupQuotaSubscriptions.json
            // this example is just showing the usage of "GroupQuotaSubscriptions_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this GroupQuotaEntityResource created on azure
            // for more information of creating GroupQuotaEntityResource, please refer to the document of GroupQuotaEntityResource
            string managementGroupId = "E7EC67B3-7657-4966-BFFC-41EFD36BAA09";
            string groupQuotaName = "groupquota1";
            ResourceIdentifier groupQuotaEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);
            GroupQuotaEntityResource groupQuotaEntity = client.GetGroupQuotaEntityResource(groupQuotaEntityResourceId);

            // get the collection of this GroupQuotaSubscriptionResource
            GroupQuotaSubscriptionCollection collection = groupQuotaEntity.GetGroupQuotaSubscriptions();

            // invoke the operation
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            bool result = await collection.ExistsAsync(subscriptionId);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_GroupQuotaSubscriptionsGetSubscriptions()
        {
            // Generated from example definition: specification/quota/resource-manager/Microsoft.Quota/preview/2023-06-01-preview/examples/GroupQuotasSubscriptions/GetGroupQuotaSubscriptions.json
            // this example is just showing the usage of "GroupQuotaSubscriptions_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this GroupQuotaEntityResource created on azure
            // for more information of creating GroupQuotaEntityResource, please refer to the document of GroupQuotaEntityResource
            string managementGroupId = "E7EC67B3-7657-4966-BFFC-41EFD36BAA09";
            string groupQuotaName = "groupquota1";
            ResourceIdentifier groupQuotaEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);
            GroupQuotaEntityResource groupQuotaEntity = client.GetGroupQuotaEntityResource(groupQuotaEntityResourceId);

            // get the collection of this GroupQuotaSubscriptionResource
            GroupQuotaSubscriptionCollection collection = groupQuotaEntity.GetGroupQuotaSubscriptions();

            // invoke the operation
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            NullableResponse<GroupQuotaSubscriptionResource> response = await collection.GetIfExistsAsync(subscriptionId);
            GroupQuotaSubscriptionResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                GroupQuotaSubscriptionData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
