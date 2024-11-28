// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Billing.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Billing.Samples
{
    public partial class Sample_BillingInvoiceSectionResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_InvoiceSectionsGet()
        {
            // Generated from example definition: specification/billing/resource-manager/Microsoft.Billing/stable/2024-04-01/examples/invoiceSectionsGet.json
            // this example is just showing the usage of "InvoiceSections_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this BillingInvoiceSectionResource created on azure
            // for more information of creating BillingInvoiceSectionResource, please refer to the document of BillingInvoiceSectionResource
            string billingAccountName = "00000000-0000-0000-0000-000000000000:00000000-0000-0000-0000-000000000000_2019-05-31";
            string billingProfileName = "xxxx-xxxx-xxx-xxx";
            string invoiceSectionName = "yyyy-yyyy-yyy-yyy";
            ResourceIdentifier billingInvoiceSectionResourceId = BillingInvoiceSectionResource.CreateResourceIdentifier(billingAccountName, billingProfileName, invoiceSectionName);
            BillingInvoiceSectionResource billingInvoiceSection = client.GetBillingInvoiceSectionResource(billingInvoiceSectionResourceId);

            // invoke the operation
            BillingInvoiceSectionResource result = await billingInvoiceSection.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            BillingInvoiceSectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_InvoiceSectionsDelete()
        {
            // Generated from example definition: specification/billing/resource-manager/Microsoft.Billing/stable/2024-04-01/examples/invoiceSectionsDelete.json
            // this example is just showing the usage of "InvoiceSections_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this BillingInvoiceSectionResource created on azure
            // for more information of creating BillingInvoiceSectionResource, please refer to the document of BillingInvoiceSectionResource
            string billingAccountName = "00000000-0000-0000-0000-000000000000:00000000-0000-0000-0000-000000000000_2019-05-31";
            string billingProfileName = "xxxx-xxxx-xxx-xxx";
            string invoiceSectionName = "yyyy-yyyy-yyy-yyy";
            ResourceIdentifier billingInvoiceSectionResourceId = BillingInvoiceSectionResource.CreateResourceIdentifier(billingAccountName, billingProfileName, invoiceSectionName);
            BillingInvoiceSectionResource billingInvoiceSection = client.GetBillingInvoiceSectionResource(billingInvoiceSectionResourceId);

            // invoke the operation
            await billingInvoiceSection.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_InvoiceSectionsCreateOrUpdate()
        {
            // Generated from example definition: specification/billing/resource-manager/Microsoft.Billing/stable/2024-04-01/examples/invoiceSectionsCreateOrUpdate.json
            // this example is just showing the usage of "InvoiceSections_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this BillingInvoiceSectionResource created on azure
            // for more information of creating BillingInvoiceSectionResource, please refer to the document of BillingInvoiceSectionResource
            string billingAccountName = "00000000-0000-0000-0000-000000000000:00000000-0000-0000-0000-000000000000_2019-05-31";
            string billingProfileName = "xxxx-xxxx-xxx-xxx";
            string invoiceSectionName = "invoice-section-1";
            ResourceIdentifier billingInvoiceSectionResourceId = BillingInvoiceSectionResource.CreateResourceIdentifier(billingAccountName, billingProfileName, invoiceSectionName);
            BillingInvoiceSectionResource billingInvoiceSection = client.GetBillingInvoiceSectionResource(billingInvoiceSectionResourceId);

            // invoke the operation
            BillingInvoiceSectionData data = new BillingInvoiceSectionData
            {
                Properties = new BillingInvoiceSectionProperties
                {
                    DisplayName = "Invoice Section 1",
                    Tags =
{
["costCategory"] = "Support",
["pcCode"] = "A123456"
},
                },
            };
            ArmOperation<BillingInvoiceSectionResource> lro = await billingInvoiceSection.UpdateAsync(WaitUntil.Completed, data);
            BillingInvoiceSectionResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            BillingInvoiceSectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetBillingPermissions_BillingPermissionsListByInvoiceSection()
        {
            // Generated from example definition: specification/billing/resource-manager/Microsoft.Billing/stable/2024-04-01/examples/billingPermissionsListByInvoiceSection.json
            // this example is just showing the usage of "BillingPermissions_ListByInvoiceSection" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this BillingInvoiceSectionResource created on azure
            // for more information of creating BillingInvoiceSectionResource, please refer to the document of BillingInvoiceSectionResource
            string billingAccountName = "10000000-0000-0000-0000-000000000000:00000000-0000-0000-0000-000000000000_2019-05-31";
            string billingProfileName = "xxxx-xxxx-xxx-xxx";
            string invoiceSectionName = "XXXX-XXXX-XXX-XXX";
            ResourceIdentifier billingInvoiceSectionResourceId = BillingInvoiceSectionResource.CreateResourceIdentifier(billingAccountName, billingProfileName, invoiceSectionName);
            BillingInvoiceSectionResource billingInvoiceSection = client.GetBillingInvoiceSectionResource(billingInvoiceSectionResourceId);

            // invoke the operation and iterate over the result
            await foreach (BillingPermission item in billingInvoiceSection.GetBillingPermissionsAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CheckAccessBillingPermissions_CheckAccessByInvoiceSection()
        {
            // Generated from example definition: specification/billing/resource-manager/Microsoft.Billing/stable/2024-04-01/examples/checkAccessByInvoiceSection.json
            // this example is just showing the usage of "BillingPermissions_CheckAccessByInvoiceSection" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this BillingInvoiceSectionResource created on azure
            // for more information of creating BillingInvoiceSectionResource, please refer to the document of BillingInvoiceSectionResource
            string billingAccountName = "10000000-0000-0000-0000-000000000000:00000000-0000-0000-0000-000000000000_2019-05-31";
            string billingProfileName = "xxxx-xxxx-xxx-xxx";
            string invoiceSectionName = "Q7GV-UUVA-PJA-TGB";
            ResourceIdentifier billingInvoiceSectionResourceId = BillingInvoiceSectionResource.CreateResourceIdentifier(billingAccountName, billingProfileName, invoiceSectionName);
            BillingInvoiceSectionResource billingInvoiceSection = client.GetBillingInvoiceSectionResource(billingInvoiceSectionResourceId);

            // invoke the operation and iterate over the result
            BillingCheckAccessContent content = new BillingCheckAccessContent
            {
                Actions = { "Microsoft.Billing/billingAccounts/read", "Microsoft.Subscription/subscriptions/write" },
            };
            await foreach (BillingCheckAccessResult item in billingInvoiceSection.CheckAccessBillingPermissionsAsync(content))
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetBillingRequests_BillingRequestsListByInvoiceSection()
        {
            // Generated from example definition: specification/billing/resource-manager/Microsoft.Billing/stable/2024-04-01/examples/billingRequestsListByInvoiceSection.json
            // this example is just showing the usage of "BillingRequests_ListByInvoiceSection" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this BillingInvoiceSectionResource created on azure
            // for more information of creating BillingInvoiceSectionResource, please refer to the document of BillingInvoiceSectionResource
            string billingAccountName = "00000000-0000-0000-0000-000000000000:00000000-0000-0000-0000-000000000000_2019-05-31";
            string billingProfileName = "xxxx-xxxx-xxx-xxx";
            string invoiceSectionName = "yyyy-yyyy-yyy-yyy";
            ResourceIdentifier billingInvoiceSectionResourceId = BillingInvoiceSectionResource.CreateResourceIdentifier(billingAccountName, billingProfileName, invoiceSectionName);
            BillingInvoiceSectionResource billingInvoiceSection = client.GetBillingInvoiceSectionResource(billingInvoiceSectionResourceId);

            // invoke the operation and iterate over the result
            BillingInvoiceSectionResourceGetBillingRequestsOptions options = new BillingInvoiceSectionResourceGetBillingRequestsOptions();
            await foreach (BillingRequestResource item in billingInvoiceSection.GetBillingRequestsAsync(options))
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                BillingRequestData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CreateByInvoiceSectionBillingRoleAssignment_BillingRoleAssignmentCreateByInvoiceSection()
        {
            // Generated from example definition: specification/billing/resource-manager/Microsoft.Billing/stable/2024-04-01/examples/billingRoleAssignmentCreateByInvoiceSection.json
            // this example is just showing the usage of "BillingRoleAssignments_CreateByInvoiceSection" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this BillingInvoiceSectionResource created on azure
            // for more information of creating BillingInvoiceSectionResource, please refer to the document of BillingInvoiceSectionResource
            string billingAccountName = "00000000-0000-0000-0000-000000000000:00000000-0000-0000-0000-000000000000_2018-09-30";
            string billingProfileName = "BKM6-54VH-BG7-PGB";
            string invoiceSectionName = "xxxx-xxxx-xxx-xxx";
            ResourceIdentifier billingInvoiceSectionResourceId = BillingInvoiceSectionResource.CreateResourceIdentifier(billingAccountName, billingProfileName, invoiceSectionName);
            BillingInvoiceSectionResource billingInvoiceSection = client.GetBillingInvoiceSectionResource(billingInvoiceSectionResourceId);

            // invoke the operation
            BillingRoleAssignmentProperties billingRoleAssignmentProperties = new BillingRoleAssignmentProperties(new ResourceIdentifier("/providers/Microsoft.Billing/billingAccounts/00000000-0000-0000-0000-000000000000:00000000-0000-0000-0000-000000000000_2018-09-30/billingProfiles/BKM6-54VH-BG7-PGB/invoiceSections/xxxx-xxxx-xxx-xxx/billingRoleDefinitions/10000000-aaaa-bbbb-cccc-100000000000"))
            {
                PrincipalId = "00000000-0000-0000-0000-000000000000",
                PrincipalTenantId = Guid.Parse("076915e7-de10-4323-bb34-a58c904068bb"),
                UserEmailAddress = "john@contoso.com",
            };
            ArmOperation<BillingRoleAssignmentData> lro = await billingInvoiceSection.CreateByInvoiceSectionBillingRoleAssignmentAsync(WaitUntil.Completed, billingRoleAssignmentProperties);
            BillingRoleAssignmentData result = lro.Value;

            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {result.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task ResolveByInvoiceSectionBillingRoleAssignment_ResolveBillingRoleAssignmentByInvoiceSection()
        {
            // Generated from example definition: specification/billing/resource-manager/Microsoft.Billing/stable/2024-04-01/examples/resolveBillingRoleAssignmentByInvoiceSection.json
            // this example is just showing the usage of "BillingRoleAssignments_ResolveByInvoiceSection" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this BillingInvoiceSectionResource created on azure
            // for more information of creating BillingInvoiceSectionResource, please refer to the document of BillingInvoiceSectionResource
            string billingAccountName = "00000000-0000-0000-0000-000000000000:00000000-0000-0000-0000-000000000000_2018-09-30";
            string billingProfileName = "BKM6-54VH-BG7-PGB";
            string invoiceSectionName = "xxxx-xxxx-xxx-xxx";
            ResourceIdentifier billingInvoiceSectionResourceId = BillingInvoiceSectionResource.CreateResourceIdentifier(billingAccountName, billingProfileName, invoiceSectionName);
            BillingInvoiceSectionResource billingInvoiceSection = client.GetBillingInvoiceSectionResource(billingInvoiceSectionResourceId);

            // invoke the operation
            ArmOperation<BillingRoleAssignmentListResult> lro = await billingInvoiceSection.ResolveByInvoiceSectionBillingRoleAssignmentAsync(WaitUntil.Completed);
            BillingRoleAssignmentListResult result = lro.Value;

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetBillingSubscriptions_BillingSubscriptionsListByInvoiceSection()
        {
            // Generated from example definition: specification/billing/resource-manager/Microsoft.Billing/stable/2024-04-01/examples/billingSubscriptionsListByInvoiceSection.json
            // this example is just showing the usage of "BillingSubscriptions_ListByInvoiceSection" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this BillingInvoiceSectionResource created on azure
            // for more information of creating BillingInvoiceSectionResource, please refer to the document of BillingInvoiceSectionResource
            string billingAccountName = "a1a9c77e-4cec-4a6c-a089-867d973a6074:a80d3b1f-c626-4e5e-82ed-1173bd91c838_2019-05-31";
            string billingProfileName = "ea36e548-1505-41db-bebc-46fff3d37998";
            string invoiceSectionName = "Q7GV-UUVA-PJA-TGB";
            ResourceIdentifier billingInvoiceSectionResourceId = BillingInvoiceSectionResource.CreateResourceIdentifier(billingAccountName, billingProfileName, invoiceSectionName);
            BillingInvoiceSectionResource billingInvoiceSection = client.GetBillingInvoiceSectionResource(billingInvoiceSectionResourceId);

            // invoke the operation and iterate over the result
            BillingInvoiceSectionResourceGetBillingSubscriptionsOptions options = new BillingInvoiceSectionResourceGetBillingSubscriptionsOptions();
            await foreach (BillingSubscriptionData item in billingInvoiceSection.GetBillingSubscriptionsAsync(options))
            {
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {item.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task ValidateDeleteEligibility_InvoiceSectionsValidateDeleteEligibilityFailure()
        {
            // Generated from example definition: specification/billing/resource-manager/Microsoft.Billing/stable/2024-04-01/examples/invoiceSectionsValidateDeleteEligibilityFailure.json
            // this example is just showing the usage of "InvoiceSections_ValidateDeleteEligibility" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this BillingInvoiceSectionResource created on azure
            // for more information of creating BillingInvoiceSectionResource, please refer to the document of BillingInvoiceSectionResource
            string billingAccountName = "00000000-0000-0000-0000-000000000000:00000000-0000-0000-0000-000000000000_2019-05-31";
            string billingProfileName = "xxxx-xxxx-xxx-xxx";
            string invoiceSectionName = "yyyy-yyyy-yyy-yyy";
            ResourceIdentifier billingInvoiceSectionResourceId = BillingInvoiceSectionResource.CreateResourceIdentifier(billingAccountName, billingProfileName, invoiceSectionName);
            BillingInvoiceSectionResource billingInvoiceSection = client.GetBillingInvoiceSectionResource(billingInvoiceSectionResourceId);

            // invoke the operation
            DeleteInvoiceSectionEligibilityResult result = await billingInvoiceSection.ValidateDeleteEligibilityAsync();

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task ValidateDeleteEligibility_InvoiceSectionsValidateDeleteEligibilitySuccess()
        {
            // Generated from example definition: specification/billing/resource-manager/Microsoft.Billing/stable/2024-04-01/examples/invoiceSectionsValidateDeleteEligibilitySuccess.json
            // this example is just showing the usage of "InvoiceSections_ValidateDeleteEligibility" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this BillingInvoiceSectionResource created on azure
            // for more information of creating BillingInvoiceSectionResource, please refer to the document of BillingInvoiceSectionResource
            string billingAccountName = "00000000-0000-0000-0000-000000000000:00000000-0000-0000-0000-000000000000_2019-05-31";
            string billingProfileName = "xxxx-xxxx-xxx-xxx";
            string invoiceSectionName = "yyyy-yyyy-yyy-yyy";
            ResourceIdentifier billingInvoiceSectionResourceId = BillingInvoiceSectionResource.CreateResourceIdentifier(billingAccountName, billingProfileName, invoiceSectionName);
            BillingInvoiceSectionResource billingInvoiceSection = client.GetBillingInvoiceSectionResource(billingInvoiceSectionResourceId);

            // invoke the operation
            DeleteInvoiceSectionEligibilityResult result = await billingInvoiceSection.ValidateDeleteEligibilityAsync();

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetProducts_ProductsListByInvoiceSection()
        {
            // Generated from example definition: specification/billing/resource-manager/Microsoft.Billing/stable/2024-04-01/examples/productsListByInvoiceSection.json
            // this example is just showing the usage of "Products_ListByInvoiceSection" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this BillingInvoiceSectionResource created on azure
            // for more information of creating BillingInvoiceSectionResource, please refer to the document of BillingInvoiceSectionResource
            string billingAccountName = "a1a9c77e-4cec-4a6c-a089-867d973a6074:a80d3b1f-c626-4e5e-82ed-1173bd91c838_2019-05-31";
            string billingProfileName = "ea36e548-1505-41db-bebc-46fff3d37998";
            string invoiceSectionName = "Q7GV-UUVA-PJA-TGB";
            ResourceIdentifier billingInvoiceSectionResourceId = BillingInvoiceSectionResource.CreateResourceIdentifier(billingAccountName, billingProfileName, invoiceSectionName);
            BillingInvoiceSectionResource billingInvoiceSection = client.GetBillingInvoiceSectionResource(billingInvoiceSectionResourceId);

            // invoke the operation and iterate over the result
            BillingInvoiceSectionResourceGetProductsOptions options = new BillingInvoiceSectionResourceGetProductsOptions();
            await foreach (BillingProductResource item in billingInvoiceSection.GetProductsAsync(options))
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                BillingProductData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetTransactions_TransactionsListByInvoiceSection()
        {
            // Generated from example definition: specification/billing/resource-manager/Microsoft.Billing/stable/2024-04-01/examples/transactionsListByInvoiceSection.json
            // this example is just showing the usage of "Transactions_ListByInvoiceSection" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this BillingInvoiceSectionResource created on azure
            // for more information of creating BillingInvoiceSectionResource, please refer to the document of BillingInvoiceSectionResource
            string billingAccountName = "00000000-0000-0000-0000-000000000000:00000000-0000-0000-0000-000000000000_2019-05-31";
            string billingProfileName = "xxxx-xxxx-xxx-xxx";
            string invoiceSectionName = "22000000-0000-0000-0000-000000000000";
            ResourceIdentifier billingInvoiceSectionResourceId = BillingInvoiceSectionResource.CreateResourceIdentifier(billingAccountName, billingProfileName, invoiceSectionName);
            BillingInvoiceSectionResource billingInvoiceSection = client.GetBillingInvoiceSectionResource(billingInvoiceSectionResourceId);

            // invoke the operation and iterate over the result
            DateTimeOffset periodStartDate = DateTimeOffset.Parse("2024-04-01");
            DateTimeOffset periodEndDate = DateTimeOffset.Parse("2023-05-30");
            TransactionType type = TransactionType.Billed;
            BillingInvoiceSectionResourceGetTransactionsOptions options = new BillingInvoiceSectionResourceGetTransactionsOptions(periodStartDate, periodEndDate, type) { Filter = "properties/date gt '2020-10-01'", Search = "storage" };
            await foreach (BillingTransactionData item in billingInvoiceSection.GetTransactionsAsync(options))
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine("Succeeded");
        }
    }
}
