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
    /// A class representing a collection of <see cref="TopicNetworkSecurityPerimeterConfigurationResource"/> and their operations.
    /// Each <see cref="TopicNetworkSecurityPerimeterConfigurationResource"/> in the collection will belong to the same instance of <see cref="EventGridTopicResource"/>.
    /// To get a <see cref="TopicNetworkSecurityPerimeterConfigurationCollection"/> instance call the GetTopicNetworkSecurityPerimeterConfigurations method from an instance of <see cref="EventGridTopicResource"/>.
    /// </summary>
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen dynamic-parent expansion: the new MPG generator emits only the
    // NSP Resource class for Domain/Topic but never the matching per-parent Collection
    // class. We hand-author the Collection against the generator-produced internal
    // NetworkSecurityPerimeterConfigurations REST client and the auto-generated
    // TopicNetworkSecurityPerimeterConfigurationResource + Data + OperationSource.
    // The Reconcile LRO entry point continues to live on the Resource because the
    // generator's BuildOperationSources crashes during regen when keyed on data type;
    // see issue for full root-cause analysis.)
    public partial class TopicNetworkSecurityPerimeterConfigurationCollection : ArmCollection,
        IEnumerable<TopicNetworkSecurityPerimeterConfigurationResource>,
        IAsyncEnumerable<TopicNetworkSecurityPerimeterConfigurationResource>
    {
        private const string TopicResourceTypeSegment = "topics";
        private const string DiagnosticNamespace = "Azure.ResourceManager.EventGrid";
        private const string DefaultApiVersion = "2025-07-15-preview";

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly NetworkSecurityPerimeterConfigurations _restClient;

        /// <summary> Initializes a new instance of the <see cref="TopicNetworkSecurityPerimeterConfigurationCollection"/> class for mocking. </summary>
        protected TopicNetworkSecurityPerimeterConfigurationCollection()
        {
        }

        /// <summary> Initializes a new instance of <see cref="TopicNetworkSecurityPerimeterConfigurationCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TopicNetworkSecurityPerimeterConfigurationCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(TopicNetworkSecurityPerimeterConfigurationResource.ResourceType, out string apiVersion);
            _clientDiagnostics = new ClientDiagnostics(DiagnosticNamespace, TopicNetworkSecurityPerimeterConfigurationResource.ResourceType.Namespace, Diagnostics);
            _restClient = new NetworkSecurityPerimeterConfigurations(_clientDiagnostics, Pipeline, Endpoint, apiVersion ?? DefaultApiVersion);
            ValidateResourceId(id);
        }

        /// <param name="id"></param>
        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != EventGridTopicResource.ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, EventGridTopicResource.ResourceType), nameof(id));
            }
        }

        /// <summary> Get a specific network security perimeter configuration with a topic. </summary>
        /// <param name="networkSecurityPerimeterConfigurationName"> The combined "{perimeterGuid}.{associationName}" singleton key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="networkSecurityPerimeterConfigurationName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="networkSecurityPerimeterConfigurationName"/> is empty or not in "{perimeterGuid}.{associationName}" format. </exception>
        public virtual async Task<Response<TopicNetworkSecurityPerimeterConfigurationResource>> GetAsync(string networkSecurityPerimeterConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkSecurityPerimeterConfigurationName, nameof(networkSecurityPerimeterConfigurationName));
            (string perimeterGuid, string associationName) = SplitName(networkSecurityPerimeterConfigurationName);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, TopicResourceTypeSegment, Id.Name, perimeterGuid, associationName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                NetworkSecurityPerimeterConfigurationData data = NetworkSecurityPerimeterConfigurationData.FromResponse(result);
                if (data == null)
                {
                    throw new RequestFailedException(result);
                }
                return Response.FromValue(new TopicNetworkSecurityPerimeterConfigurationResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a specific network security perimeter configuration with a topic. </summary>
        /// <param name="networkSecurityPerimeterConfigurationName"> The combined "{perimeterGuid}.{associationName}" singleton key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="networkSecurityPerimeterConfigurationName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="networkSecurityPerimeterConfigurationName"/> is empty or not in "{perimeterGuid}.{associationName}" format. </exception>
        public virtual Response<TopicNetworkSecurityPerimeterConfigurationResource> Get(string networkSecurityPerimeterConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkSecurityPerimeterConfigurationName, nameof(networkSecurityPerimeterConfigurationName));
            (string perimeterGuid, string associationName) = SplitName(networkSecurityPerimeterConfigurationName);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, TopicResourceTypeSegment, Id.Name, perimeterGuid, associationName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                NetworkSecurityPerimeterConfigurationData data = NetworkSecurityPerimeterConfigurationData.FromResponse(result);
                if (data == null)
                {
                    throw new RequestFailedException(result);
                }
                return Response.FromValue(new TopicNetworkSecurityPerimeterConfigurationResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get all network security perimeter configurations associated with a topic. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<TopicNetworkSecurityPerimeterConfigurationResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<NetworkSecurityPerimeterConfigurationData, TopicNetworkSecurityPerimeterConfigurationResource>(
                new NetworkSecurityPerimeterConfigurationsGetAllAsyncCollectionResultOfT(
                    _restClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    TopicResourceTypeSegment,
                    Id.Name,
                    context,
                    "TopicNetworkSecurityPerimeterConfigurationCollection.GetAll"),
                data => new TopicNetworkSecurityPerimeterConfigurationResource(Client, data));
        }

        /// <summary> Get all network security perimeter configurations associated with a topic. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<TopicNetworkSecurityPerimeterConfigurationResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<NetworkSecurityPerimeterConfigurationData, TopicNetworkSecurityPerimeterConfigurationResource>(
                new NetworkSecurityPerimeterConfigurationsGetAllCollectionResultOfT(
                    _restClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    TopicResourceTypeSegment,
                    Id.Name,
                    context,
                    "TopicNetworkSecurityPerimeterConfigurationCollection.GetAll"),
                data => new TopicNetworkSecurityPerimeterConfigurationResource(Client, data));
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="networkSecurityPerimeterConfigurationName"> The combined "{perimeterGuid}.{associationName}" singleton key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(string networkSecurityPerimeterConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkSecurityPerimeterConfigurationName, nameof(networkSecurityPerimeterConfigurationName));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationCollection.Exists");
            scope.Start();
            try
            {
                NullableResponse<TopicNetworkSecurityPerimeterConfigurationResource> response = await GetIfExistsAsync(networkSecurityPerimeterConfigurationName, cancellationToken: cancellationToken).ConfigureAwait(false);
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationCollection.Exists");
            scope.Start();
            try
            {
                NullableResponse<TopicNetworkSecurityPerimeterConfigurationResource> response = GetIfExists(networkSecurityPerimeterConfigurationName, cancellationToken: cancellationToken);
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
        public virtual async Task<NullableResponse<TopicNetworkSecurityPerimeterConfigurationResource>> GetIfExistsAsync(string networkSecurityPerimeterConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkSecurityPerimeterConfigurationName, nameof(networkSecurityPerimeterConfigurationName));
            (string perimeterGuid, string associationName) = SplitName(networkSecurityPerimeterConfigurationName);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, TopicResourceTypeSegment, Id.Name, perimeterGuid, associationName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                if (result.Status == 404)
                {
                    return new NoValueResponse<TopicNetworkSecurityPerimeterConfigurationResource>(result);
                }
                NetworkSecurityPerimeterConfigurationData data = NetworkSecurityPerimeterConfigurationData.FromResponse(result);
                return Response.FromValue(new TopicNetworkSecurityPerimeterConfigurationResource(Client, data), result);
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
        public virtual NullableResponse<TopicNetworkSecurityPerimeterConfigurationResource> GetIfExists(string networkSecurityPerimeterConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkSecurityPerimeterConfigurationName, nameof(networkSecurityPerimeterConfigurationName));
            (string perimeterGuid, string associationName) = SplitName(networkSecurityPerimeterConfigurationName);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, TopicResourceTypeSegment, Id.Name, perimeterGuid, associationName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                if (result.Status == 404)
                {
                    return new NoValueResponse<TopicNetworkSecurityPerimeterConfigurationResource>(result);
                }
                NetworkSecurityPerimeterConfigurationData data = NetworkSecurityPerimeterConfigurationData.FromResponse(result);
                return Response.FromValue(new TopicNetworkSecurityPerimeterConfigurationResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TopicNetworkSecurityPerimeterConfigurationResource> IEnumerable<TopicNetworkSecurityPerimeterConfigurationResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TopicNetworkSecurityPerimeterConfigurationResource> IAsyncEnumerable<TopicNetworkSecurityPerimeterConfigurationResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
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
