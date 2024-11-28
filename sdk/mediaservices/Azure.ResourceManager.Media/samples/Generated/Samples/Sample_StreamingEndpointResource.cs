// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Media.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Samples
{
    public partial class Sample_StreamingEndpointResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetAStreamingEndpointByName()
        {
            // Generated from example definition: specification/mediaservices/resource-manager/Microsoft.Media/Streaming/stable/2022-08-01/examples/streamingendpoint-list-by-name.json
            // this example is just showing the usage of "StreamingEndpoints_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this StreamingEndpointResource created on azure
            // for more information of creating StreamingEndpointResource, please refer to the document of StreamingEndpointResource
            string subscriptionId = "0a6ec948-5a62-437d-b9df-934dc7c1b722";
            string resourceGroupName = "mediaresources";
            string accountName = "slitestmedia10";
            string streamingEndpointName = "myStreamingEndpoint1";
            ResourceIdentifier streamingEndpointResourceId = StreamingEndpointResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, streamingEndpointName);
            StreamingEndpointResource streamingEndpoint = client.GetStreamingEndpointResource(streamingEndpointResourceId);

            // invoke the operation
            StreamingEndpointResource result = await streamingEndpoint.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            StreamingEndpointData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_DeleteAStreamingEndpoint()
        {
            // Generated from example definition: specification/mediaservices/resource-manager/Microsoft.Media/Streaming/stable/2022-08-01/examples/streamingendpoint-delete.json
            // this example is just showing the usage of "StreamingEndpoints_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this StreamingEndpointResource created on azure
            // for more information of creating StreamingEndpointResource, please refer to the document of StreamingEndpointResource
            string subscriptionId = "0a6ec948-5a62-437d-b9df-934dc7c1b722";
            string resourceGroupName = "mediaresources";
            string accountName = "slitestmedia10";
            string streamingEndpointName = "myStreamingEndpoint1";
            ResourceIdentifier streamingEndpointResourceId = StreamingEndpointResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, streamingEndpointName);
            StreamingEndpointResource streamingEndpoint = client.GetStreamingEndpointResource(streamingEndpointResourceId);

            // invoke the operation
            await streamingEndpoint.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_UpdateAStreamingEndpoint()
        {
            // Generated from example definition: specification/mediaservices/resource-manager/Microsoft.Media/Streaming/stable/2022-08-01/examples/streamingendpoint-update.json
            // this example is just showing the usage of "StreamingEndpoints_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this StreamingEndpointResource created on azure
            // for more information of creating StreamingEndpointResource, please refer to the document of StreamingEndpointResource
            string subscriptionId = "0a6ec948-5a62-437d-b9df-934dc7c1b722";
            string resourceGroupName = "mediaresources";
            string accountName = "slitestmedia10";
            string streamingEndpointName = "myStreamingEndpoint1";
            ResourceIdentifier streamingEndpointResourceId = StreamingEndpointResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, streamingEndpointName);
            StreamingEndpointResource streamingEndpoint = client.GetStreamingEndpointResource(streamingEndpointResourceId);

            // invoke the operation
            StreamingEndpointData data = new StreamingEndpointData(new AzureLocation("West US"))
            {
                Description = "test event 2",
                ScaleUnits = 5,
                AvailabilitySetName = "availableset",
                Tags =
{
["tag3"] = "value3",
["tag5"] = "value5"
},
            };
            ArmOperation<StreamingEndpointResource> lro = await streamingEndpoint.UpdateAsync(WaitUntil.Completed, data);
            StreamingEndpointResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            StreamingEndpointData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetSupportedSkus_ListAStreamingEndpointSku()
        {
            // Generated from example definition: specification/mediaservices/resource-manager/Microsoft.Media/Streaming/stable/2022-08-01/examples/streamingendpoint-list-skus.json
            // this example is just showing the usage of "StreamingEndpoints_Skus" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this StreamingEndpointResource created on azure
            // for more information of creating StreamingEndpointResource, please refer to the document of StreamingEndpointResource
            string subscriptionId = "0a6ec948-5a62-437d-b9df-934dc7c1b722";
            string resourceGroupName = "mediaresources";
            string accountName = "slitestmedia10";
            string streamingEndpointName = "myStreamingEndpoint1";
            ResourceIdentifier streamingEndpointResourceId = StreamingEndpointResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, streamingEndpointName);
            StreamingEndpointResource streamingEndpoint = client.GetStreamingEndpointResource(streamingEndpointResourceId);

            // invoke the operation and iterate over the result
            await foreach (StreamingEndpointSkuInfo item in streamingEndpoint.GetSupportedSkusAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Start_StartAStreamingEndpoint()
        {
            // Generated from example definition: specification/mediaservices/resource-manager/Microsoft.Media/Streaming/stable/2022-08-01/examples/streamingendpoint-start.json
            // this example is just showing the usage of "StreamingEndpoints_Start" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this StreamingEndpointResource created on azure
            // for more information of creating StreamingEndpointResource, please refer to the document of StreamingEndpointResource
            string subscriptionId = "0a6ec948-5a62-437d-b9df-934dc7c1b722";
            string resourceGroupName = "mediaresources";
            string accountName = "slitestmedia10";
            string streamingEndpointName = "myStreamingEndpoint1";
            ResourceIdentifier streamingEndpointResourceId = StreamingEndpointResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, streamingEndpointName);
            StreamingEndpointResource streamingEndpoint = client.GetStreamingEndpointResource(streamingEndpointResourceId);

            // invoke the operation
            await streamingEndpoint.StartAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Stop_StopAStreamingEndpoint()
        {
            // Generated from example definition: specification/mediaservices/resource-manager/Microsoft.Media/Streaming/stable/2022-08-01/examples/streamingendpoint-stop.json
            // this example is just showing the usage of "StreamingEndpoints_Stop" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this StreamingEndpointResource created on azure
            // for more information of creating StreamingEndpointResource, please refer to the document of StreamingEndpointResource
            string subscriptionId = "0a6ec948-5a62-437d-b9df-934dc7c1b722";
            string resourceGroupName = "mediaresources";
            string accountName = "slitestmedia10";
            string streamingEndpointName = "myStreamingEndpoint1";
            ResourceIdentifier streamingEndpointResourceId = StreamingEndpointResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, streamingEndpointName);
            StreamingEndpointResource streamingEndpoint = client.GetStreamingEndpointResource(streamingEndpointResourceId);

            // invoke the operation
            await streamingEndpoint.StopAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Scale_ScaleAStreamingEndpoint()
        {
            // Generated from example definition: specification/mediaservices/resource-manager/Microsoft.Media/Streaming/stable/2022-08-01/examples/streamingendpoint-scale.json
            // this example is just showing the usage of "StreamingEndpoints_Scale" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this StreamingEndpointResource created on azure
            // for more information of creating StreamingEndpointResource, please refer to the document of StreamingEndpointResource
            string subscriptionId = "0a6ec948-5a62-437d-b9df-934dc7c1b722";
            string resourceGroupName = "mediaresources";
            string accountName = "slitestmedia10";
            string streamingEndpointName = "myStreamingEndpoint1";
            ResourceIdentifier streamingEndpointResourceId = StreamingEndpointResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, streamingEndpointName);
            StreamingEndpointResource streamingEndpoint = client.GetStreamingEndpointResource(streamingEndpointResourceId);

            // invoke the operation
            StreamingEntityScaleUnit streamingEntityScaleUnit = new StreamingEntityScaleUnit
            {
                ScaleUnit = 5,
            };
            await streamingEndpoint.ScaleAsync(WaitUntil.Completed, streamingEntityScaleUnit);

            Console.WriteLine("Succeeded");
        }
    }
}
