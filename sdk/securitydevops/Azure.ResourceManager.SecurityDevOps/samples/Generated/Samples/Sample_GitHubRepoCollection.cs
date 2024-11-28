// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityDevOps.Samples
{
    public partial class Sample_GitHubRepoCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CreateOrUpdate_GitHubRepoCreateOrUpdate()
        {
            // Generated from example definition: specification/securitydevops/resource-manager/Microsoft.SecurityDevOps/preview/2022-09-01-preview/examples/GitHubRepoCreateOrUpdate.json
            // this example is just showing the usage of "GitHubRepo_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this GitHubOwnerResource created on azure
            // for more information of creating GitHubOwnerResource, please refer to the document of GitHubOwnerResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "westusrg";
            string gitHubConnectorName = "testconnector";
            string gitHubOwnerName = "Azure";
            ResourceIdentifier gitHubOwnerResourceId = GitHubOwnerResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, gitHubConnectorName, gitHubOwnerName);
            GitHubOwnerResource gitHubOwner = client.GetGitHubOwnerResource(gitHubOwnerResourceId);

            // get the collection of this GitHubRepoResource
            GitHubRepoCollection collection = gitHubOwner.GetGitHubRepos();

            // invoke the operation
            string gitHubRepoName = "azure-rest-api-specs";
            GitHubRepoData data = new GitHubRepoData();
            ArmOperation<GitHubRepoResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, gitHubRepoName, data);
            GitHubRepoResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            GitHubRepoData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GitHubRepoGet()
        {
            // Generated from example definition: specification/securitydevops/resource-manager/Microsoft.SecurityDevOps/preview/2022-09-01-preview/examples/GitHubRepoGet.json
            // this example is just showing the usage of "GitHubRepo_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this GitHubOwnerResource created on azure
            // for more information of creating GitHubOwnerResource, please refer to the document of GitHubOwnerResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "westusrg";
            string gitHubConnectorName = "testconnector";
            string gitHubOwnerName = "Azure";
            ResourceIdentifier gitHubOwnerResourceId = GitHubOwnerResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, gitHubConnectorName, gitHubOwnerName);
            GitHubOwnerResource gitHubOwner = client.GetGitHubOwnerResource(gitHubOwnerResourceId);

            // get the collection of this GitHubRepoResource
            GitHubRepoCollection collection = gitHubOwner.GetGitHubRepos();

            // invoke the operation
            string gitHubRepoName = "39093389";
            GitHubRepoResource result = await collection.GetAsync(gitHubRepoName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            GitHubRepoData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_GitHubRepoList()
        {
            // Generated from example definition: specification/securitydevops/resource-manager/Microsoft.SecurityDevOps/preview/2022-09-01-preview/examples/GitHubRepoList.json
            // this example is just showing the usage of "GitHubRepo_List" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this GitHubOwnerResource created on azure
            // for more information of creating GitHubOwnerResource, please refer to the document of GitHubOwnerResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "westusrg";
            string gitHubConnectorName = "testconnector";
            string gitHubOwnerName = "Azure";
            ResourceIdentifier gitHubOwnerResourceId = GitHubOwnerResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, gitHubConnectorName, gitHubOwnerName);
            GitHubOwnerResource gitHubOwner = client.GetGitHubOwnerResource(gitHubOwnerResourceId);

            // get the collection of this GitHubRepoResource
            GitHubRepoCollection collection = gitHubOwner.GetGitHubRepos();

            // invoke the operation and iterate over the result
            await foreach (GitHubRepoResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                GitHubRepoData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_GitHubRepoGet()
        {
            // Generated from example definition: specification/securitydevops/resource-manager/Microsoft.SecurityDevOps/preview/2022-09-01-preview/examples/GitHubRepoGet.json
            // this example is just showing the usage of "GitHubRepo_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this GitHubOwnerResource created on azure
            // for more information of creating GitHubOwnerResource, please refer to the document of GitHubOwnerResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "westusrg";
            string gitHubConnectorName = "testconnector";
            string gitHubOwnerName = "Azure";
            ResourceIdentifier gitHubOwnerResourceId = GitHubOwnerResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, gitHubConnectorName, gitHubOwnerName);
            GitHubOwnerResource gitHubOwner = client.GetGitHubOwnerResource(gitHubOwnerResourceId);

            // get the collection of this GitHubRepoResource
            GitHubRepoCollection collection = gitHubOwner.GetGitHubRepos();

            // invoke the operation
            string gitHubRepoName = "39093389";
            bool result = await collection.ExistsAsync(gitHubRepoName);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_GitHubRepoGet()
        {
            // Generated from example definition: specification/securitydevops/resource-manager/Microsoft.SecurityDevOps/preview/2022-09-01-preview/examples/GitHubRepoGet.json
            // this example is just showing the usage of "GitHubRepo_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this GitHubOwnerResource created on azure
            // for more information of creating GitHubOwnerResource, please refer to the document of GitHubOwnerResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "westusrg";
            string gitHubConnectorName = "testconnector";
            string gitHubOwnerName = "Azure";
            ResourceIdentifier gitHubOwnerResourceId = GitHubOwnerResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, gitHubConnectorName, gitHubOwnerName);
            GitHubOwnerResource gitHubOwner = client.GetGitHubOwnerResource(gitHubOwnerResourceId);

            // get the collection of this GitHubRepoResource
            GitHubRepoCollection collection = gitHubOwner.GetGitHubRepos();

            // invoke the operation
            string gitHubRepoName = "39093389";
            NullableResponse<GitHubRepoResource> response = await collection.GetIfExistsAsync(gitHubRepoName);
            GitHubRepoResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                GitHubRepoData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
