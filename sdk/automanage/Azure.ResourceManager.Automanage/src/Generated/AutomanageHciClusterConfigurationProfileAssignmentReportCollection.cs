// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Automanage
{
    /// <summary>
    /// A class representing a collection of <see cref="AutomanageHciClusterConfigurationProfileAssignmentReportResource"/> and their operations.
    /// Each <see cref="AutomanageHciClusterConfigurationProfileAssignmentReportResource"/> in the collection will belong to the same instance of <see cref="AutomanageHciClusterConfigurationProfileAssignmentResource"/>.
    /// To get an <see cref="AutomanageHciClusterConfigurationProfileAssignmentReportCollection"/> instance call the GetAutomanageHciClusterConfigurationProfileAssignmentReports method from an instance of <see cref="AutomanageHciClusterConfigurationProfileAssignmentResource"/>.
    /// </summary>
    public partial class AutomanageHciClusterConfigurationProfileAssignmentReportCollection : ArmCollection, IEnumerable<AutomanageHciClusterConfigurationProfileAssignmentReportResource>, IAsyncEnumerable<AutomanageHciClusterConfigurationProfileAssignmentReportResource>
    {
        private readonly ClientDiagnostics _automanageHciClusterConfigurationProfileAssignmentReportHciReportsClientDiagnostics;
        private readonly HCIReportsRestOperations _automanageHciClusterConfigurationProfileAssignmentReportHciReportsRestClient;

        /// <summary> Initializes a new instance of the <see cref="AutomanageHciClusterConfigurationProfileAssignmentReportCollection"/> class for mocking. </summary>
        protected AutomanageHciClusterConfigurationProfileAssignmentReportCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AutomanageHciClusterConfigurationProfileAssignmentReportCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AutomanageHciClusterConfigurationProfileAssignmentReportCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _automanageHciClusterConfigurationProfileAssignmentReportHciReportsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Automanage", AutomanageHciClusterConfigurationProfileAssignmentReportResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(AutomanageHciClusterConfigurationProfileAssignmentReportResource.ResourceType, out string automanageHciClusterConfigurationProfileAssignmentReportHciReportsApiVersion);
            _automanageHciClusterConfigurationProfileAssignmentReportHciReportsRestClient = new HCIReportsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, automanageHciClusterConfigurationProfileAssignmentReportHciReportsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != "Microsoft.Automanage/configurationProfileAssignments")
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, "Microsoft.Automanage/configurationProfileAssignments"), nameof(id));
        }

        /// <summary>
        /// Get information about a report associated with a configuration profile assignment run
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>HCIReports_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-05-04</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutomanageHciClusterConfigurationProfileAssignmentReportResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportName"> The report name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="reportName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="reportName"/> is null. </exception>
        public virtual async Task<Response<AutomanageHciClusterConfigurationProfileAssignmentReportResource>> GetAsync(string reportName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(reportName, nameof(reportName));

            using var scope = _automanageHciClusterConfigurationProfileAssignmentReportHciReportsClientDiagnostics.CreateScope("AutomanageHciClusterConfigurationProfileAssignmentReportCollection.Get");
            scope.Start();
            try
            {
                var response = await _automanageHciClusterConfigurationProfileAssignmentReportHciReportsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, reportName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AutomanageHciClusterConfigurationProfileAssignmentReportResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get information about a report associated with a configuration profile assignment run
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>HCIReports_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-05-04</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutomanageHciClusterConfigurationProfileAssignmentReportResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportName"> The report name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="reportName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="reportName"/> is null. </exception>
        public virtual Response<AutomanageHciClusterConfigurationProfileAssignmentReportResource> Get(string reportName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(reportName, nameof(reportName));

            using var scope = _automanageHciClusterConfigurationProfileAssignmentReportHciReportsClientDiagnostics.CreateScope("AutomanageHciClusterConfigurationProfileAssignmentReportCollection.Get");
            scope.Start();
            try
            {
                var response = _automanageHciClusterConfigurationProfileAssignmentReportHciReportsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, reportName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AutomanageHciClusterConfigurationProfileAssignmentReportResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve a list of reports within a given configuration profile assignment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>HCIReports_ListByConfigurationProfileAssignments</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-05-04</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutomanageHciClusterConfigurationProfileAssignmentReportResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AutomanageHciClusterConfigurationProfileAssignmentReportResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AutomanageHciClusterConfigurationProfileAssignmentReportResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _automanageHciClusterConfigurationProfileAssignmentReportHciReportsRestClient.CreateListByConfigurationProfileAssignmentsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new AutomanageHciClusterConfigurationProfileAssignmentReportResource(Client, AutomanageConfigurationProfileAssignmentReportData.DeserializeAutomanageConfigurationProfileAssignmentReportData(e)), _automanageHciClusterConfigurationProfileAssignmentReportHciReportsClientDiagnostics, Pipeline, "AutomanageHciClusterConfigurationProfileAssignmentReportCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Retrieve a list of reports within a given configuration profile assignment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>HCIReports_ListByConfigurationProfileAssignments</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-05-04</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutomanageHciClusterConfigurationProfileAssignmentReportResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AutomanageHciClusterConfigurationProfileAssignmentReportResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AutomanageHciClusterConfigurationProfileAssignmentReportResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _automanageHciClusterConfigurationProfileAssignmentReportHciReportsRestClient.CreateListByConfigurationProfileAssignmentsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new AutomanageHciClusterConfigurationProfileAssignmentReportResource(Client, AutomanageConfigurationProfileAssignmentReportData.DeserializeAutomanageConfigurationProfileAssignmentReportData(e)), _automanageHciClusterConfigurationProfileAssignmentReportHciReportsClientDiagnostics, Pipeline, "AutomanageHciClusterConfigurationProfileAssignmentReportCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>HCIReports_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-05-04</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutomanageHciClusterConfigurationProfileAssignmentReportResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportName"> The report name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="reportName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="reportName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string reportName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(reportName, nameof(reportName));

            using var scope = _automanageHciClusterConfigurationProfileAssignmentReportHciReportsClientDiagnostics.CreateScope("AutomanageHciClusterConfigurationProfileAssignmentReportCollection.Exists");
            scope.Start();
            try
            {
                var response = await _automanageHciClusterConfigurationProfileAssignmentReportHciReportsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, reportName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>HCIReports_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-05-04</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutomanageHciClusterConfigurationProfileAssignmentReportResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportName"> The report name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="reportName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="reportName"/> is null. </exception>
        public virtual Response<bool> Exists(string reportName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(reportName, nameof(reportName));

            using var scope = _automanageHciClusterConfigurationProfileAssignmentReportHciReportsClientDiagnostics.CreateScope("AutomanageHciClusterConfigurationProfileAssignmentReportCollection.Exists");
            scope.Start();
            try
            {
                var response = _automanageHciClusterConfigurationProfileAssignmentReportHciReportsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, reportName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>HCIReports_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-05-04</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutomanageHciClusterConfigurationProfileAssignmentReportResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportName"> The report name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="reportName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="reportName"/> is null. </exception>
        public virtual async Task<NullableResponse<AutomanageHciClusterConfigurationProfileAssignmentReportResource>> GetIfExistsAsync(string reportName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(reportName, nameof(reportName));

            using var scope = _automanageHciClusterConfigurationProfileAssignmentReportHciReportsClientDiagnostics.CreateScope("AutomanageHciClusterConfigurationProfileAssignmentReportCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _automanageHciClusterConfigurationProfileAssignmentReportHciReportsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, reportName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<AutomanageHciClusterConfigurationProfileAssignmentReportResource>(response.GetRawResponse());
                return Response.FromValue(new AutomanageHciClusterConfigurationProfileAssignmentReportResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>HCIReports_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-05-04</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutomanageHciClusterConfigurationProfileAssignmentReportResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportName"> The report name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="reportName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="reportName"/> is null. </exception>
        public virtual NullableResponse<AutomanageHciClusterConfigurationProfileAssignmentReportResource> GetIfExists(string reportName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(reportName, nameof(reportName));

            using var scope = _automanageHciClusterConfigurationProfileAssignmentReportHciReportsClientDiagnostics.CreateScope("AutomanageHciClusterConfigurationProfileAssignmentReportCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _automanageHciClusterConfigurationProfileAssignmentReportHciReportsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, reportName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<AutomanageHciClusterConfigurationProfileAssignmentReportResource>(response.GetRawResponse());
                return Response.FromValue(new AutomanageHciClusterConfigurationProfileAssignmentReportResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AutomanageHciClusterConfigurationProfileAssignmentReportResource> IEnumerable<AutomanageHciClusterConfigurationProfileAssignmentReportResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AutomanageHciClusterConfigurationProfileAssignmentReportResource> IAsyncEnumerable<AutomanageHciClusterConfigurationProfileAssignmentReportResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
