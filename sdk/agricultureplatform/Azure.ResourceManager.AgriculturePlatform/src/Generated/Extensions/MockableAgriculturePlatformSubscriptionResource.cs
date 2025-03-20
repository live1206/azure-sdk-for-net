// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.AgriculturePlatform.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableAgriculturePlatformSubscriptionResource : ArmResource
    {
        private ClientDiagnostics _agricultureServiceAgriServiceClientDiagnostics;
        private AgriServiceRestOperations _agricultureServiceAgriServiceRestClient;

        /// <summary> Initializes a new instance of the <see cref="MockableAgriculturePlatformSubscriptionResource"/> class for mocking. </summary>
        protected MockableAgriculturePlatformSubscriptionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableAgriculturePlatformSubscriptionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableAgriculturePlatformSubscriptionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics AgricultureServiceAgriServiceClientDiagnostics => _agricultureServiceAgriServiceClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.AgriculturePlatform", AgricultureServiceResource.ResourceType.Namespace, Diagnostics);
        private AgriServiceRestOperations AgricultureServiceAgriServiceRestClient => _agricultureServiceAgriServiceRestClient ??= new AgriServiceRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(AgricultureServiceResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// List AgriServiceResource resources by subscription ID
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AgriculturePlatform/agriServices</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgriServiceResource_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AgricultureServiceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AgricultureServiceResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AgricultureServiceResource> GetAgricultureServicesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AgricultureServiceAgriServiceRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => AgricultureServiceAgriServiceRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new AgricultureServiceResource(Client, AgricultureServiceData.DeserializeAgricultureServiceData(e)), AgricultureServiceAgriServiceClientDiagnostics, Pipeline, "MockableAgriculturePlatformSubscriptionResource.GetAgricultureServices", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List AgriServiceResource resources by subscription ID
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AgriculturePlatform/agriServices</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgriServiceResource_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AgricultureServiceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AgricultureServiceResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AgricultureServiceResource> GetAgricultureServices(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AgricultureServiceAgriServiceRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => AgricultureServiceAgriServiceRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new AgricultureServiceResource(Client, AgricultureServiceData.DeserializeAgricultureServiceData(e)), AgricultureServiceAgriServiceClientDiagnostics, Pipeline, "MockableAgriculturePlatformSubscriptionResource.GetAgricultureServices", "value", "nextLink", cancellationToken);
        }
    }
}
