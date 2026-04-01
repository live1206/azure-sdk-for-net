// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

/*
#nullable disable

#pragma warning disable CS1591

// Backward compat: the old SDK (1.1.0) had per-parent Collection classes for private link resources.
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
    public partial class EventGridDomainPrivateLinkResourceCollection : ArmCollection,
        IEnumerable<EventGridDomainPrivateLinkResource>,
        IAsyncEnumerable<EventGridDomainPrivateLinkResource>
    {
        private ClientDiagnostics _clientDiagnostics;
        private PrivateLinkResources _restClient;

        protected EventGridDomainPrivateLinkResourceCollection() { }

        internal EventGridDomainPrivateLinkResourceCollection(ArmClient client, ResourceIdentifier id)
            : base(client, id)
        {
        }

        private ClientDiagnostics ClientDiags => _clientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.EventGrid", EventGridDomainPrivateLinkResource.ResourceType.Namespace, Diagnostics);

        private PrivateLinkResources RestClient => _restClient ??= new PrivateLinkResources(ClientDiags, Pipeline, Endpoint, "2025-07-15-preview");

        private string DomainName => Id.Name;

        public virtual async Task<Response<EventGridDomainPrivateLinkResource>> GetAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));

            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridDomainPrivateLinkResourceCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", DomainName, privateLinkResourceName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var model = EventGrid.Models.EventGridPrivateLinkResource.FromResponse(result);
                var data = EventGridPrivateLinkResourceData.FromModel(model);
                return Response.FromValue(new EventGridDomainPrivateLinkResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<EventGridDomainPrivateLinkResource> Get(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));

            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridDomainPrivateLinkResourceCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", DomainName, privateLinkResourceName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                var model = EventGrid.Models.EventGridPrivateLinkResource.FromResponse(result);
                var data = EventGridPrivateLinkResourceData.FromModel(model);
                return Response.FromValue(new EventGridDomainPrivateLinkResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual AsyncPageable<EventGridDomainPrivateLinkResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            var inner = new PrivateLinkResourcesGetByResourceAsyncCollectionResultOfT(
                RestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", DomainName, null, null, context);
            return new CompatAsyncPageable<EventGrid.Models.EventGridPrivateLinkResource, EventGridDomainPrivateLinkResource>(
                inner, m => new EventGridDomainPrivateLinkResource(Client, EventGridPrivateLinkResourceData.FromModel(m)));
        }

        // Backward compat: old SDK had GetAllAsync/GetAll with filter and top parameters.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EventGridDomainPrivateLinkResource> GetAllAsync(string filter, int? top, CancellationToken cancellationToken = default)
            => GetAllAsync(cancellationToken);

        public virtual Pageable<EventGridDomainPrivateLinkResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            var inner = new PrivateLinkResourcesGetByResourceCollectionResultOfT(
                RestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "domains", DomainName, null, null, context);
            return new CompatPageable<EventGrid.Models.EventGridPrivateLinkResource, EventGridDomainPrivateLinkResource>(
                inner, m => new EventGridDomainPrivateLinkResource(Client, EventGridPrivateLinkResourceData.FromModel(m)));
        }

        // Backward compat: old SDK had GetAll with filter and top parameters.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EventGridDomainPrivateLinkResource> GetAll(string filter, int? top, CancellationToken cancellationToken = default)
            => GetAll(cancellationToken);

        public virtual async Task<Response<bool>> ExistsAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            try
            {
                var response = await GetAsync(privateLinkResourceName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return Response.FromValue(false, ex.GetRawResponse());
            }
        }

        public virtual Response<bool> Exists(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            try
            {
                var response = Get(privateLinkResourceName, cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return Response.FromValue(false, ex.GetRawResponse());
            }
        }

        public virtual async Task<NullableResponse<EventGridDomainPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            try
            {
                var response = await GetAsync(privateLinkResourceName, cancellationToken).ConfigureAwait(false);
                return response.Value != null
                    ? Response.FromValue(response.Value, response.GetRawResponse())
                    : new NoValueResponse<EventGridDomainPrivateLinkResource>(response.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return new NoValueResponse<EventGridDomainPrivateLinkResource>(ex.GetRawResponse());
            }
        }

        public virtual NullableResponse<EventGridDomainPrivateLinkResource> GetIfExists(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateLinkResourceName, nameof(privateLinkResourceName));
            try
            {
                var response = Get(privateLinkResourceName, cancellationToken);
                return response.Value != null
                    ? Response.FromValue(response.Value, response.GetRawResponse())
                    : new NoValueResponse<EventGridDomainPrivateLinkResource>(response.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return new NoValueResponse<EventGridDomainPrivateLinkResource>(ex.GetRawResponse());
            }
        }

        IEnumerator<EventGridDomainPrivateLinkResource> IEnumerable<EventGridDomainPrivateLinkResource>.GetEnumerator()
            => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetAll().GetEnumerator();

        IAsyncEnumerator<EventGridDomainPrivateLinkResource> IAsyncEnumerable<EventGridDomainPrivateLinkResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
*/
