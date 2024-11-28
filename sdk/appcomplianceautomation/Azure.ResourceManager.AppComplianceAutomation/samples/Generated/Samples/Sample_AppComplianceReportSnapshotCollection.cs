// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.AppComplianceAutomation.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.AppComplianceAutomation.Samples
{
    public partial class Sample_AppComplianceReportSnapshotCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_SnapshotGet()
        {
            // Generated from example definition: specification/appcomplianceautomation/resource-manager/Microsoft.AppComplianceAutomation/stable/2024-06-27/examples/Snapshot_Get.json
            // this example is just showing the usage of "Snapshot_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AppComplianceReportResource created on azure
            // for more information of creating AppComplianceReportResource, please refer to the document of AppComplianceReportResource
            string reportName = "testReportName";
            ResourceIdentifier appComplianceReportResourceId = AppComplianceReportResource.CreateResourceIdentifier(reportName);
            AppComplianceReportResource appComplianceReport = client.GetAppComplianceReportResource(appComplianceReportResourceId);

            // get the collection of this AppComplianceReportSnapshotResource
            AppComplianceReportSnapshotCollection collection = appComplianceReport.GetAppComplianceReportSnapshots();

            // invoke the operation
            string snapshotName = "testSnapshot";
            AppComplianceReportSnapshotResource result = await collection.GetAsync(snapshotName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            AppComplianceReportSnapshotData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_SnapshotList()
        {
            // Generated from example definition: specification/appcomplianceautomation/resource-manager/Microsoft.AppComplianceAutomation/stable/2024-06-27/examples/Snapshot_List.json
            // this example is just showing the usage of "Snapshot_List" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AppComplianceReportResource created on azure
            // for more information of creating AppComplianceReportResource, please refer to the document of AppComplianceReportResource
            string reportName = "testReportName";
            ResourceIdentifier appComplianceReportResourceId = AppComplianceReportResource.CreateResourceIdentifier(reportName);
            AppComplianceReportResource appComplianceReport = client.GetAppComplianceReportResource(appComplianceReportResourceId);

            // get the collection of this AppComplianceReportSnapshotResource
            AppComplianceReportSnapshotCollection collection = appComplianceReport.GetAppComplianceReportSnapshots();

            // invoke the operation and iterate over the result
            AppComplianceReportSnapshotCollectionGetAllOptions options = new AppComplianceReportSnapshotCollectionGetAllOptions { SkipToken = "1", Top = 100, OfferGuid = "00000000-0000-0000-0000-000000000001", ReportCreatorTenantId = "00000000-0000-0000-0000-000000000000" };
            await foreach (AppComplianceReportSnapshotResource item in collection.GetAllAsync(options))
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                AppComplianceReportSnapshotData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_SnapshotGet()
        {
            // Generated from example definition: specification/appcomplianceautomation/resource-manager/Microsoft.AppComplianceAutomation/stable/2024-06-27/examples/Snapshot_Get.json
            // this example is just showing the usage of "Snapshot_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AppComplianceReportResource created on azure
            // for more information of creating AppComplianceReportResource, please refer to the document of AppComplianceReportResource
            string reportName = "testReportName";
            ResourceIdentifier appComplianceReportResourceId = AppComplianceReportResource.CreateResourceIdentifier(reportName);
            AppComplianceReportResource appComplianceReport = client.GetAppComplianceReportResource(appComplianceReportResourceId);

            // get the collection of this AppComplianceReportSnapshotResource
            AppComplianceReportSnapshotCollection collection = appComplianceReport.GetAppComplianceReportSnapshots();

            // invoke the operation
            string snapshotName = "testSnapshot";
            bool result = await collection.ExistsAsync(snapshotName);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_SnapshotGet()
        {
            // Generated from example definition: specification/appcomplianceautomation/resource-manager/Microsoft.AppComplianceAutomation/stable/2024-06-27/examples/Snapshot_Get.json
            // this example is just showing the usage of "Snapshot_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AppComplianceReportResource created on azure
            // for more information of creating AppComplianceReportResource, please refer to the document of AppComplianceReportResource
            string reportName = "testReportName";
            ResourceIdentifier appComplianceReportResourceId = AppComplianceReportResource.CreateResourceIdentifier(reportName);
            AppComplianceReportResource appComplianceReport = client.GetAppComplianceReportResource(appComplianceReportResourceId);

            // get the collection of this AppComplianceReportSnapshotResource
            AppComplianceReportSnapshotCollection collection = appComplianceReport.GetAppComplianceReportSnapshots();

            // invoke the operation
            string snapshotName = "testSnapshot";
            NullableResponse<AppComplianceReportSnapshotResource> response = await collection.GetIfExistsAsync(snapshotName);
            AppComplianceReportSnapshotResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                AppComplianceReportSnapshotData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
