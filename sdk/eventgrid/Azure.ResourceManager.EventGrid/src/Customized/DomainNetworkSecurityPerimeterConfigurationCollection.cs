// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.EventGrid
{
    /// <summary>
    /// A class representing a collection of <see cref="DomainNetworkSecurityPerimeterConfigurationResource"/> and their operations.
    /// Each <see cref="DomainNetworkSecurityPerimeterConfigurationResource"/> in the collection will belong to the same instance of <see cref="EventGridDomainResource"/>.
    /// To get a <see cref="DomainNetworkSecurityPerimeterConfigurationCollection"/> instance call the GetDomainNetworkSecurityPerimeterConfigurations method from an instance of <see cref="EventGridDomainResource"/>.
    /// </summary>
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen dynamic-parent expansion: the new MPG generator emits only the
    // NSP Resource class for Domain/Topic but never the matching per-parent Collection
    // class. We hand-author the Collection against the generator-produced internal
    // NetworkSecurityPerimeterConfigurations REST client and the auto-generated
    // DomainNetworkSecurityPerimeterConfigurationResource + Data + OperationSource.
    // The Reconcile LRO entry point continues to live on the Resource because the
    // generator's BuildOperationSources crashes during regen when keyed on data type;
    // see issue for full root-cause analysis.)
    public partial class DomainNetworkSecurityPerimeterConfigurationCollection : ArmCollection,
        IEnumerable<DomainNetworkSecurityPerimeterConfigurationResource>,
        IAsyncEnumerable<DomainNetworkSecurityPerimeterConfigurationResource>
    {
        private const string DomainResourceTypeSegment = "domains";
        private const string DiagnosticNamespace = "Azure.ResourceManager.EventGrid";
        private const string DefaultApiVersion = "2025-07-15-preview";

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly NetworkSecurityPerimeterConfigurations _restClient;

        /// <summary> Initializes a new instance of the <see cref="DomainNetworkSecurityPerimeterConfigurationCollection"/> class for mocking. </summary>
        protected DomainNetworkSecurityPerimeterConfigurationCollection()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DomainNetworkSecurityPerimeterConfigurationCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DomainNetworkSecurityPerimeterConfigurationCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(DomainNetworkSecurityPerimeterConfigurationResource.ResourceType, out string apiVersion);
            _clientDiagnostics = new ClientDiagnostics(DiagnosticNamespace, DomainNetworkSecurityPerimeterConfigurationResource.ResourceType.Namespace, Diagnostics);
            _restClient = new NetworkSecurityPerimeterConfigurations(_clientDiagnostics, Pipeline, Endpoint, apiVersion ?? DefaultApiVersion);
            ValidateResourceId(id);
        }

        /// <param name="id"></param>
        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != EventGridDomainResource.ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, EventGridDomainResource.ResourceType), nameof(id));
            }
        }

        /// <summary> Get a specific network security perimeter configuration with a domain. </summary>
        /// <param name="networkSecurityPerimeterConfigurationName"> The combined "{perimeterGuid}.{associationName}" singleton key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="networkSecurityPerimeterConfigurationName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="networkSecurityPerimeterConfigurationName"/> is empty or not in "{perimeterGuid}.{associationName}" format. </exception>
        public virtual async Task<Response<DomainNetworkSecurityPerimeterConfigurationResource>> GetAsync(string networkSecurityPerimeterConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkSecurityPerimeterConfigurationName, nameof(networkSecurityPerimeterConfigurationName));
            (string perimeterGuid, string associationName) = SplitName(networkSecurityPerimeterConfigurationName);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DomainNetworkSecurityPerimeterConfigurationCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, DomainResourceTypeSegment, Id.Name, perimeterGuid, associationName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                NetworkSecurityPerimeterConfigurationData data = NetworkSecurityPerimeterConfigurationData.FromResponse(result);
                if (data == null)
                {
                    throw new RequestFailedException(result);
                }
                return Response.FromValue(new DomainNetworkSecurityPerimeterConfigurationResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a specific network security perimeter configuration with a domain. </summary>
        /// <param name="networkSecurityPerimeterConfigurationName"> The combined "{perimeterGuid}.{associationName}" singleton key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="networkSecurityPerimeterConfigurationName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="networkSecurityPerimeterConfigurationName"/> is empty or not in "{perimeterGuid}.{associationName}" format. </exception>
        public virtual Response<DomainNetworkSecurityPerimeterConfigurationResource> Get(string networkSecurityPerimeterConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkSecurityPerimeterConfigurationName, nameof(networkSecurityPerimeterConfigurationName));
            (string perimeterGuid, string associationName) = SplitName(networkSecurityPerimeterConfigurationName);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DomainNetworkSecurityPerimeterConfigurationCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, DomainResourceTypeSegment, Id.Name, perimeterGuid, associationName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                NetworkSecurityPerimeterConfigurationData data = NetworkSecurityPerimeterConfigurationData.FromResponse(result);
                if (data == null)
                {
                    throw new RequestFailedException(result);
                }
                return Response.FromValue(new DomainNetworkSecurityPerimeterConfigurationResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get all network security perimeter configurations associated with a domain. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<DomainNetworkSecurityPerimeterConfigurationResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<NetworkSecurityPerimeterConfigurationData, DomainNetworkSecurityPerimeterConfigurationResource>(
                new NetworkSecurityPerimeterConfigurationsGetAllAsyncCollectionResultOfT(
                    _restClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    DomainResourceTypeSegment,
                    Id.Name,
                    context,
                    "DomainNetworkSecurityPerimeterConfigurationCollection.GetAll"),
                data => new DomainNetworkSecurityPerimeterConfigurationResource(Client, data));
        }

        /// <summary> Get all network security perimeter configurations associated with a domain. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<DomainNetworkSecurityPerimeterConfigurationResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<NetworkSecurityPerimeterConfigurationData, DomainNetworkSecurityPerimeterConfigurationResource>(
                new NetworkSecurityPerimeterConfigurationsGetAllCollectionResultOfT(
                    _restClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    DomainResourceTypeSegment,
                    Id.Name,
                    context,
                    "DomainNetworkSecurityPerimeterConfigurationCollection.GetAll"),
                data => new DomainNetworkSecurityPerimeterConfigurationResource(Client, data));
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="networkSecurityPerimeterConfigurationName"> The combined "{perimeterGuid}.{associationName}" singleton key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(string networkSecurityPerimeterConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkSecurityPerimeterConfigurationName, nameof(networkSecurityPerimeterConfigurationName));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DomainNetworkSecurityPerimeterConfigurationCollection.Exists");
            scope.Start();
            try
            {
                NullableResponse<DomainNetworkSecurityPerimeterConfigurationResource> response = await GetIfExistsAsync(networkSecurityPerimeterConfigurationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.HasValue, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="networkSecurityPerimeterConfigurationName"> The combined "{perimeterGuid}.{associationName}" singleton key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(string networkSecurityPerimeterConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkSecurityPerimeterConfigurationName, nameof(networkSecurityPerimeterConfigurationName));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DomainNetworkSecurityPerimeterConfigurationCollection.Exists");
            scope.Start();
            try
            {
                NullableResponse<DomainNetworkSecurityPerimeterConfigurationResource> response = GetIfExists(networkSecurityPerimeterConfigurationName, cancellationToken: cancellationToken);
                return Response.FromValue(response.HasValue, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="networkSecurityPerimeterConfigurationName"> The combined "{perimeterGuid}.{associationName}" singleton key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<DomainNetworkSecurityPerimeterConfigurationResource>> GetIfExistsAsync(string networkSecurityPerimeterConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkSecurityPerimeterConfigurationName, nameof(networkSecurityPerimeterConfigurationName));
            (string perimeterGuid, string associationName) = SplitName(networkSecurityPerimeterConfigurationName);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DomainNetworkSecurityPerimeterConfigurationCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, DomainResourceTypeSegment, Id.Name, perimeterGuid, associationName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                if (result.Status == 404)
                {
                    return new NoValueResponse<DomainNetworkSecurityPerimeterConfigurationResource>(result);
                }
                NetworkSecurityPerimeterConfigurationData data = NetworkSecurityPerimeterConfigurationData.FromResponse(result);
                return Response.FromValue(new DomainNetworkSecurityPerimeterConfigurationResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="networkSecurityPerimeterConfigurationName"> The combined "{perimeterGuid}.{associationName}" singleton key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<DomainNetworkSecurityPerimeterConfigurationResource> GetIfExists(string networkSecurityPerimeterConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkSecurityPerimeterConfigurationName, nameof(networkSecurityPerimeterConfigurationName));
            (string perimeterGuid, string associationName) = SplitName(networkSecurityPerimeterConfigurationName);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DomainNetworkSecurityPerimeterConfigurationCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, DomainResourceTypeSegment, Id.Name, perimeterGuid, associationName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                if (result.Status == 404)
                {
                    return new NoValueResponse<DomainNetworkSecurityPerimeterConfigurationResource>(result);
                }
                NetworkSecurityPerimeterConfigurationData data = NetworkSecurityPerimeterConfigurationData.FromResponse(result);
                return Response.FromValue(new DomainNetworkSecurityPerimeterConfigurationResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DomainNetworkSecurityPerimeterConfigurationResource> IEnumerable<DomainNetworkSecurityPerimeterConfigurationResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DomainNetworkSecurityPerimeterConfigurationResource> IAsyncEnumerable<DomainNetworkSecurityPerimeterConfigurationResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        private static (string PerimeterGuid, string AssociationName) SplitName(string singletonName)
        {
            int idx = singletonName.IndexOf('.');
            if (idx <= 0 || idx >= singletonName.Length - 1)
            {
                throw new ArgumentException("Expected NSP configuration name in the form '{perimeterGuid}.{associationName}'.", nameof(singletonName));
            }
            return (singletonName.Substring(0, idx), singletonName.Substring(idx + 1));
        }
    }
}
