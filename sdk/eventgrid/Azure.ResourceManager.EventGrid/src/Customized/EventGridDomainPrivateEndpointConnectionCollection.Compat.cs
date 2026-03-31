// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

// Backward compat: the old SDK (1.1.0) had per-parent Collection classes for private endpoint connections.
// The new TypeSpec generator uses RoutedOperations with a dynamic parentType parameter, which doesn't
// produce separate Collection classes. This stub restores the old API surface for domains.

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
    public partial class EventGridDomainPrivateEndpointConnectionCollection : ArmCollection,
        IEnumerable<EventGridDomainPrivateEndpointConnectionResource>,
        IAsyncEnumerable<EventGridDomainPrivateEndpointConnectionResource>
    {
        private ClientDiagnostics _clientDiagnostics;
        private PrivateEndpointConnections _restClient;

        protected EventGridDomainPrivateEndpointConnectionCollection() { }

        internal EventGridDomainPrivateEndpointConnectionCollection(ArmClient client, ResourceIdentifier id)
            : base(client, id)
        {
        }

        private ClientDiagnostics ClientDiags => _clientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.EventGrid", EventGridDomainPrivateEndpointConnectionResource.ResourceType.Namespace, Diagnostics);

        private PrivateEndpointConnections RestClient => _restClient ??= new PrivateEndpointConnections(ClientDiags, Pipeline, Endpoint, "2025-07-15-preview");

        private string DomainName => Id.Name;

        public virtual async Task<ArmOperation<EventGridDomainPrivateEndpointConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string privateEndpointConnectionName, EventGridPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridDomainPrivateEndpointConnectionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", DomainName, privateEndpointConnectionName, EventGridPrivateEndpointConnectionData.ToRequestContent(data), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var operation = new EventGridArmOperation<EventGridDomainPrivateEndpointConnectionResource>(
                    new DomainPrivateEndpointConnectionOperationSource(Client),
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

        public virtual ArmOperation<EventGridDomainPrivateEndpointConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string privateEndpointConnectionName, EventGridPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridDomainPrivateEndpointConnectionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", DomainName, privateEndpointConnectionName, EventGridPrivateEndpointConnectionData.ToRequestContent(data), context);
                Response response = Pipeline.ProcessMessage(message, context);
                var operation = new EventGridArmOperation<EventGridDomainPrivateEndpointConnectionResource>(
                    new DomainPrivateEndpointConnectionOperationSource(Client),
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

        public virtual async Task<Response<EventGridDomainPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));

            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridDomainPrivateEndpointConnectionCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", DomainName, privateEndpointConnectionName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var data = EventGridPrivateEndpointConnectionData.FromResponse(result);
                return Response.FromValue(new EventGridDomainPrivateEndpointConnectionResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<EventGridDomainPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));

            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridDomainPrivateEndpointConnectionCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", DomainName, privateEndpointConnectionName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                var data = EventGridPrivateEndpointConnectionData.FromResponse(result);
                return Response.FromValue(new EventGridDomainPrivateEndpointConnectionResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual AsyncPageable<EventGridDomainPrivateEndpointConnectionResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            var inner = new PrivateEndpointConnectionsGetByResourceAsyncCollectionResultOfT(
                RestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", DomainName, null, null, context);
            return new CompatAsyncPageable<EventGridPrivateEndpointConnectionData, EventGridDomainPrivateEndpointConnectionResource>(
                inner, d => new EventGridDomainPrivateEndpointConnectionResource(Client, d));
        }

        // Backward compat: old SDK had GetAllAsync/GetAll with filter and top parameters.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EventGridDomainPrivateEndpointConnectionResource> GetAllAsync(string filter, int? top, CancellationToken cancellationToken = default)
            => GetAllAsync(cancellationToken);

        public virtual Pageable<EventGridDomainPrivateEndpointConnectionResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            var inner = new PrivateEndpointConnectionsGetByResourceCollectionResultOfT(
                RestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", DomainName, null, null, context);
            return new CompatPageable<EventGridPrivateEndpointConnectionData, EventGridDomainPrivateEndpointConnectionResource>(
                inner, d => new EventGridDomainPrivateEndpointConnectionResource(Client, d));
        }

        // Backward compat: old SDK had GetAll with filter and top parameters.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EventGridDomainPrivateEndpointConnectionResource> GetAll(string filter, int? top, CancellationToken cancellationToken = default)
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

        public virtual async Task<NullableResponse<EventGridDomainPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));
            try
            {
                var response = await GetAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);
                return response.Value != null
                    ? Response.FromValue(response.Value, response.GetRawResponse())
                    : new NoValueResponse<EventGridDomainPrivateEndpointConnectionResource>(response.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return new NoValueResponse<EventGridDomainPrivateEndpointConnectionResource>(ex.GetRawResponse());
            }
        }

        public virtual NullableResponse<EventGridDomainPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));
            try
            {
                var response = Get(privateEndpointConnectionName, cancellationToken);
                return response.Value != null
                    ? Response.FromValue(response.Value, response.GetRawResponse())
                    : new NoValueResponse<EventGridDomainPrivateEndpointConnectionResource>(response.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return new NoValueResponse<EventGridDomainPrivateEndpointConnectionResource>(ex.GetRawResponse());
            }
        }

        IEnumerator<EventGridDomainPrivateEndpointConnectionResource> IEnumerable<EventGridDomainPrivateEndpointConnectionResource>.GetEnumerator()
            => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetAll().GetEnumerator();

        IAsyncEnumerator<EventGridDomainPrivateEndpointConnectionResource> IAsyncEnumerable<EventGridDomainPrivateEndpointConnectionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
