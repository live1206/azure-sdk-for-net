// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.StorageCache.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Samples
{
    public partial class Sample_StorageCacheCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CreateOrUpdate_CachesCreateOrUpdate()
        {
            // Generated from example definition: specification/storagecache/resource-manager/Microsoft.StorageCache/stable/2024-03-01/examples/Caches_CreateOrUpdate.json
            // this example is just showing the usage of "Caches_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "scgroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this StorageCacheResource
            StorageCacheCollection collection = resourceGroupResource.GetStorageCaches();

            // invoke the operation
            string cacheName = "sc1";
            StorageCacheData data = new StorageCacheData(new AzureLocation("westus"))
            {
                Identity = new ManagedServiceIdentity("UserAssigned")
                {
                    UserAssignedIdentities =
{
[new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/scgroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1")] = new UserAssignedIdentity()
},
                },
                SkuName = "Standard_2G",
                CacheSizeGB = 3072,
                Subnet = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/scgroup/providers/Microsoft.Network/virtualNetworks/scvnet/subnets/sub1"),
                UpgradeSettings = new StorageCacheUpgradeSettings
                {
                    EnableUpgradeSchedule = true,
                    ScheduledOn = DateTimeOffset.Parse("2022-04-26T18:25:43.511Z"),
                },
                EncryptionSettings = new StorageCacheEncryptionSettings
                {
                    KeyEncryptionKey = new StorageCacheEncryptionKeyVaultKeyReference(new Uri("https://keyvault-cmk.vault.azure.net/keys/key2047/test"), new WritableSubResource
                    {
                        Id = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/scgroup/providers/Microsoft.KeyVault/vaults/keyvault-cmk"),
                    }),
                },
                SecurityAccessPolicies = {new NfsAccessPolicy("default", new NfsAccessRule[]
{
new NfsAccessRule(NfsAccessRuleScope.Default, NfsAccessRuleAccess.ReadWrite)
{
AllowSuid = false,
AllowSubmountAccess = true,
EnableRootSquash = false,
}
})},
                DirectoryServicesSettings = new StorageCacheDirectorySettings
                {
                    ActiveDirectory = new StorageCacheActiveDirectorySettings(IPAddress.Parse("192.0.2.10"), "contosoAd.contoso.local", "contosoAd", "contosoSmb")
                    {
                        SecondaryDnsIPAddress = IPAddress.Parse("192.0.2.11"),
                        Credentials = new StorageCacheActiveDirectorySettingsCredentials("consotoAdmin")
                        {
                            Password = "<password>",
                        },
                    },
                    UsernameDownload = new StorageCacheUsernameDownloadSettings
                    {
                        EnableExtendedGroups = true,
                        UsernameSource = StorageCacheUsernameSourceType.Ldap,
                        LdapServer = "192.0.2.12",
                        LdapBaseDN = "dc=contosoad,dc=contoso,dc=local",
                        Credentials = new StorageCacheUsernameDownloadCredential
                        {
                            BindDistinguishedName = "cn=ldapadmin,dc=contosoad,dc=contoso,dc=local",
                            BindPassword = "<bindPassword>",
                        },
                    },
                },
                Tags =
{
["Dept"] = "Contoso"
},
            };
            ArmOperation<StorageCacheResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, cacheName, data);
            StorageCacheResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            StorageCacheData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CreateOrUpdate_CachesCreateOrUpdateLdapOnly()
        {
            // Generated from example definition: specification/storagecache/resource-manager/Microsoft.StorageCache/stable/2024-03-01/examples/Caches_CreateOrUpdate_ldap_only.json
            // this example is just showing the usage of "Caches_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "scgroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this StorageCacheResource
            StorageCacheCollection collection = resourceGroupResource.GetStorageCaches();

            // invoke the operation
            string cacheName = "sc1";
            StorageCacheData data = new StorageCacheData(new AzureLocation("westus"))
            {
                SkuName = "Standard_2G",
                CacheSizeGB = 3072,
                Subnet = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/scgroup/providers/Microsoft.Network/virtualNetworks/scvnet/subnets/sub1"),
                UpgradeSettings = new StorageCacheUpgradeSettings
                {
                    EnableUpgradeSchedule = true,
                    ScheduledOn = DateTimeOffset.Parse("2022-04-26T18:25:43.511Z"),
                },
                EncryptionSettings = new StorageCacheEncryptionSettings
                {
                    KeyEncryptionKey = new StorageCacheEncryptionKeyVaultKeyReference(new Uri("https://keyvault-cmk.vault.azure.net/keys/key2048/test"), new WritableSubResource
                    {
                        Id = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/scgroup/providers/Microsoft.KeyVault/vaults/keyvault-cmk"),
                    }),
                },
                SecurityAccessPolicies = {new NfsAccessPolicy("default", new NfsAccessRule[]
{
new NfsAccessRule(NfsAccessRuleScope.Default, NfsAccessRuleAccess.ReadWrite)
{
AllowSuid = false,
AllowSubmountAccess = true,
EnableRootSquash = false,
}
})},
                DirectoryServicesSettings = new StorageCacheDirectorySettings
                {
                    UsernameDownload = new StorageCacheUsernameDownloadSettings
                    {
                        EnableExtendedGroups = true,
                        UsernameSource = StorageCacheUsernameSourceType.Ldap,
                        LdapServer = "192.0.2.12",
                        LdapBaseDN = "dc=contosoad,dc=contoso,dc=local",
                        Credentials = new StorageCacheUsernameDownloadCredential
                        {
                            BindDistinguishedName = "cn=ldapadmin,dc=contosoad,dc=contoso,dc=local",
                            BindPassword = "<bindPassword>",
                        },
                    },
                },
                Tags =
{
["Dept"] = "Contoso"
},
            };
            ArmOperation<StorageCacheResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, cacheName, data);
            StorageCacheResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            StorageCacheData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_CachesGet()
        {
            // Generated from example definition: specification/storagecache/resource-manager/Microsoft.StorageCache/stable/2024-03-01/examples/Caches_Get.json
            // this example is just showing the usage of "Caches_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "scgroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this StorageCacheResource
            StorageCacheCollection collection = resourceGroupResource.GetStorageCaches();

            // invoke the operation
            string cacheName = "sc1";
            StorageCacheResource result = await collection.GetAsync(cacheName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            StorageCacheData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_CachesListByResourceGroup()
        {
            // Generated from example definition: specification/storagecache/resource-manager/Microsoft.StorageCache/stable/2024-03-01/examples/Caches_ListByResourceGroup.json
            // this example is just showing the usage of "Caches_ListByResourceGroup" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "scgroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this StorageCacheResource
            StorageCacheCollection collection = resourceGroupResource.GetStorageCaches();

            // invoke the operation and iterate over the result
            await foreach (StorageCacheResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                StorageCacheData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_CachesGet()
        {
            // Generated from example definition: specification/storagecache/resource-manager/Microsoft.StorageCache/stable/2024-03-01/examples/Caches_Get.json
            // this example is just showing the usage of "Caches_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "scgroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this StorageCacheResource
            StorageCacheCollection collection = resourceGroupResource.GetStorageCaches();

            // invoke the operation
            string cacheName = "sc1";
            bool result = await collection.ExistsAsync(cacheName);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_CachesGet()
        {
            // Generated from example definition: specification/storagecache/resource-manager/Microsoft.StorageCache/stable/2024-03-01/examples/Caches_Get.json
            // this example is just showing the usage of "Caches_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "scgroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this StorageCacheResource
            StorageCacheCollection collection = resourceGroupResource.GetStorageCaches();

            // invoke the operation
            string cacheName = "sc1";
            NullableResponse<StorageCacheResource> response = await collection.GetIfExistsAsync(cacheName);
            StorageCacheResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                StorageCacheData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
