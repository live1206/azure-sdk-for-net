// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

// Backward compat: the old SDK (1.1.0) had per-parent Collection classes for private endpoint connections.
// The new TypeSpec generator uses RoutedOperations with a dynamic parentType parameter, which doesn't
// produce separate Collection classes. This stub restores the old API surface for partner namespaces.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class EventGridPartnerNamespacePrivateEndpointConnectionCollection : ArmCollection,
        IEnumerable<EventGridPartnerNamespacePrivateEndpointConnectionResource>,
        IAsyncEnumerable<EventGridPartnerNamespacePrivateEndpointConnectionResource>
    {
        private ClientDiagnostics _clientDiagnostics;
        private PrivateEndpointConnections _restClient;

        protected EventGridPartnerNamespacePrivateEndpointConnectionCollection() { }

        internal EventGridPartnerNamespacePrivateEndpointConnectionCollection(ArmClient client, ResourceIdentifier id)
            : base(client, id)
        {
        }

        private ClientDiagnostics ClientDiags => _clientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.EventGrid", EventGridPartnerNamespacePrivateEndpointConnectionResource.ResourceType.Namespace, Diagnostics);

        private PrivateEndpointConnections RestClient => _restClient ??= new PrivateEndpointConnections(ClientDiags, Pipeline, Endpoint, "2025-07-15-preview");

        private string ParentName => Id.Name;

        public virtual async Task<ArmOperation<EventGridPartnerNamespacePrivateEndpointConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string privateEndpointConnectionName, EventGridPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridPartnerNamespacePrivateEndpointConnectionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "partnerNamespaces", ParentName, privateEndpointConnectionName, EventGridPrivateEndpointConnectionData.ToRequestContent(data), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var operation = new EventGridArmOperation<EventGridPartnerNamespacePrivateEndpointConnectionResource>(
                    new PartnerNamespacePrivateEndpointConnectionOperationSource(Client),
                    ClientDiags, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual ArmOperation<EventGridPartnerNamespacePrivateEndpointConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string privateEndpointConnectionName, EventGridPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridPartnerNamespacePrivateEndpointConnectionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "partnerNamespaces", ParentName, privateEndpointConnectionName, EventGridPrivateEndpointConnectionData.ToRequestContent(data), context);
                Response response = Pipeline.ProcessMessage(message, context);
                var operation = new EventGridArmOperation<EventGridPartnerNamespacePrivateEndpointConnectionResource>(
                    new PartnerNamespacePrivateEndpointConnectionOperationSource(Client),
                    ClientDiags, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<EventGridPartnerNamespacePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));

            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridPartnerNamespacePrivateEndpointConnectionCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "partnerNamespaces", ParentName, privateEndpointConnectionName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var data = EventGridPrivateEndpointConnectionData.FromResponse(result);
                return Response.FromValue(new EventGridPartnerNamespacePrivateEndpointConnectionResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<EventGridPartnerNamespacePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));

            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridPartnerNamespacePrivateEndpointConnectionCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "partnerNamespaces", ParentName, privateEndpointConnectionName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                var data = EventGridPrivateEndpointConnectionData.FromResponse(result);
                return Response.FromValue(new EventGridPartnerNamespacePrivateEndpointConnectionResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual AsyncPageable<EventGridPartnerNamespacePrivateEndpointConnectionResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            var inner = new PrivateEndpointConnectionsGetByResourceAsyncCollectionResultOfT(
                RestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "partnerNamespaces", ParentName, null, null, context);
            return new CompatAsyncPageable<EventGridPrivateEndpointConnectionData, EventGridPartnerNamespacePrivateEndpointConnectionResource>(
                inner, d => new EventGridPartnerNamespacePrivateEndpointConnectionResource(Client, d));
        }

        // Backward compat: old SDK had GetAllAsync/GetAll with filter and top parameters.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EventGridPartnerNamespacePrivateEndpointConnectionResource> GetAllAsync(string filter, int? top, CancellationToken cancellationToken = default)
            => GetAllAsync(cancellationToken);

        public virtual Pageable<EventGridPartnerNamespacePrivateEndpointConnectionResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            var inner = new PrivateEndpointConnectionsGetByResourceCollectionResultOfT(
                RestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "partnerNamespaces", ParentName, null, null, context);
            return new CompatPageable<EventGridPrivateEndpointConnectionData, EventGridPartnerNamespacePrivateEndpointConnectionResource>(
                inner, d => new EventGridPartnerNamespacePrivateEndpointConnectionResource(Client, d));
        }

        // Backward compat: old SDK had GetAll with filter and top parameters.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EventGridPartnerNamespacePrivateEndpointConnectionResource> GetAll(string filter, int? top, CancellationToken cancellationToken = default)
            => GetAll(cancellationToken);

        public virtual async Task<Response<bool>> ExistsAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));
            try
            {
                var response = await GetAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return Response.FromValue(false, ex.GetRawResponse());
            }
        }

        public virtual Response<bool> Exists(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));
            try
            {
                var response = Get(privateEndpointConnectionName, cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return Response.FromValue(false, ex.GetRawResponse());
            }
        }

        public virtual async Task<NullableResponse<EventGridPartnerNamespacePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));
            try
            {
                var response = await GetAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);
                return response.Value != null
                    ? Response.FromValue(response.Value, response.GetRawResponse())
                    : new NoValueResponse<EventGridPartnerNamespacePrivateEndpointConnectionResource>(response.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return new NoValueResponse<EventGridPartnerNamespacePrivateEndpointConnectionResource>(ex.GetRawResponse());
            }
        }

        public virtual NullableResponse<EventGridPartnerNamespacePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));
            try
            {
                var response = Get(privateEndpointConnectionName, cancellationToken);
                return response.Value != null
                    ? Response.FromValue(response.Value, response.GetRawResponse())
                    : new NoValueResponse<EventGridPartnerNamespacePrivateEndpointConnectionResource>(response.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return new NoValueResponse<EventGridPartnerNamespacePrivateEndpointConnectionResource>(ex.GetRawResponse());
            }
        }

        IEnumerator<EventGridPartnerNamespacePrivateEndpointConnectionResource> IEnumerable<EventGridPartnerNamespacePrivateEndpointConnectionResource>.GetEnumerator()
            => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetAll().GetEnumerator();

        IAsyncEnumerator<EventGridPartnerNamespacePrivateEndpointConnectionResource> IAsyncEnumerable<EventGridPartnerNamespacePrivateEndpointConnectionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
