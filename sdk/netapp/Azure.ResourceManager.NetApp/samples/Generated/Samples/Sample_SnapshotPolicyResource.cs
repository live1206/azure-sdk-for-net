// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.NetApp.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Samples
{
    public partial class Sample_SnapshotPolicyResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_SnapshotPoliciesGet()
        {
            // Generated from example definition: specification/netapp/resource-manager/Microsoft.NetApp/stable/2024-07-01/examples/SnapshotPolicies_Get.json
            // this example is just showing the usage of "SnapshotPolicies_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SnapshotPolicyResource created on azure
            // for more information of creating SnapshotPolicyResource, please refer to the document of SnapshotPolicyResource
            string subscriptionId = "D633CC2E-722B-4AE1-B636-BBD9E4C60ED9";
            string resourceGroupName = "myRG";
            string accountName = "account1";
            string snapshotPolicyName = "snapshotPolicyName";
            ResourceIdentifier snapshotPolicyResourceId = SnapshotPolicyResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, snapshotPolicyName);
            SnapshotPolicyResource snapshotPolicy = client.GetSnapshotPolicyResource(snapshotPolicyResourceId);

            // invoke the operation
            SnapshotPolicyResource result = await snapshotPolicy.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            SnapshotPolicyData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_SnapshotPoliciesDelete()
        {
            // Generated from example definition: specification/netapp/resource-manager/Microsoft.NetApp/stable/2024-07-01/examples/SnapshotPolicies_Delete.json
            // this example is just showing the usage of "SnapshotPolicies_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SnapshotPolicyResource created on azure
            // for more information of creating SnapshotPolicyResource, please refer to the document of SnapshotPolicyResource
            string subscriptionId = "D633CC2E-722B-4AE1-B636-BBD9E4C60ED9";
            string resourceGroupName = "resourceGroup";
            string accountName = "accountName";
            string snapshotPolicyName = "snapshotPolicyName";
            ResourceIdentifier snapshotPolicyResourceId = SnapshotPolicyResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, snapshotPolicyName);
            SnapshotPolicyResource snapshotPolicy = client.GetSnapshotPolicyResource(snapshotPolicyResourceId);

            // invoke the operation
            await snapshotPolicy.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_SnapshotPoliciesUpdate()
        {
            // Generated from example definition: specification/netapp/resource-manager/Microsoft.NetApp/stable/2024-07-01/examples/SnapshotPolicies_Update.json
            // this example is just showing the usage of "SnapshotPolicies_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SnapshotPolicyResource created on azure
            // for more information of creating SnapshotPolicyResource, please refer to the document of SnapshotPolicyResource
            string subscriptionId = "D633CC2E-722B-4AE1-B636-BBD9E4C60ED9";
            string resourceGroupName = "myRG";
            string accountName = "account1";
            string snapshotPolicyName = "snapshotPolicyName";
            ResourceIdentifier snapshotPolicyResourceId = SnapshotPolicyResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, snapshotPolicyName);
            SnapshotPolicyResource snapshotPolicy = client.GetSnapshotPolicyResource(snapshotPolicyResourceId);

            // invoke the operation
            SnapshotPolicyPatch patch = new SnapshotPolicyPatch(new AzureLocation("eastus"))
            {
                HourlySchedule = new SnapshotPolicyHourlySchedule
                {
                    SnapshotsToKeep = 2,
                    Minute = 50,
                },
                DailySchedule = new SnapshotPolicyDailySchedule
                {
                    SnapshotsToKeep = 4,
                    Hour = 14,
                    Minute = 30,
                },
                WeeklySchedule = new SnapshotPolicyWeeklySchedule
                {
                    SnapshotsToKeep = 3,
                    Day = "Wednesday",
                    Hour = 14,
                    Minute = 45,
                },
                MonthlySchedule = new SnapshotPolicyMonthlySchedule
                {
                    SnapshotsToKeep = 5,
                    DaysOfMonth = "10,11,12",
                    Hour = 14,
                    Minute = 15,
                },
                IsEnabled = true,
            };
            ArmOperation<SnapshotPolicyResource> lro = await snapshotPolicy.UpdateAsync(WaitUntil.Completed, patch);
            SnapshotPolicyResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            SnapshotPolicyData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetVolumes_SnapshotPoliciesListVolumes()
        {
            // Generated from example definition: specification/netapp/resource-manager/Microsoft.NetApp/stable/2024-07-01/examples/SnapshotPolicies_ListVolumes.json
            // this example is just showing the usage of "SnapshotPolicies_ListVolumes" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SnapshotPolicyResource created on azure
            // for more information of creating SnapshotPolicyResource, please refer to the document of SnapshotPolicyResource
            string subscriptionId = "D633CC2E-722B-4AE1-B636-BBD9E4C60ED9";
            string resourceGroupName = "myRG";
            string accountName = "account1";
            string snapshotPolicyName = "snapshotPolicyName";
            ResourceIdentifier snapshotPolicyResourceId = SnapshotPolicyResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, snapshotPolicyName);
            SnapshotPolicyResource snapshotPolicy = client.GetSnapshotPolicyResource(snapshotPolicyResourceId);

            // invoke the operation and iterate over the result
            await foreach (NetAppVolumeResource item in snapshotPolicy.GetVolumesAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                NetAppVolumeData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }
    }
}
