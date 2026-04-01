// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

/*
#nullable disable

#pragma warning disable CS1591

// Backward compat: the old SDK (1.1.0) had per-parent Resource classes for private link resources.
// The new TypeSpec generator uses RoutedOperations with a dynamic parentType parameter, which doesn't
// produce separate Resource classes. This stub restores the old API surface for partner namespaces.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PartnerNamespacePrivateLinkResource : ArmResource,
        IJsonModel<EventGridPrivateLinkResourceData>,
        IPersistableModel<EventGridPrivateLinkResourceData>
    {
        public static readonly ResourceType ResourceType = "Microsoft.EventGrid/partnerNamespaces/privateLinkResources";

        private EventGridPrivateLinkResourceData _data;
        private ClientDiagnostics _clientDiagnostics;
        private PrivateLinkResources _restClient;

        protected PartnerNamespacePrivateLinkResource() { }

        internal PartnerNamespacePrivateLinkResource(ArmClient client, EventGridPrivateLinkResourceData data)
            : base(client, data.Id)
        {
            _data = data;
            HasData = true;
        }

        internal PartnerNamespacePrivateLinkResource(ArmClient client, ResourceIdentifier id)
            : base(client, id)
        {
        }

        private ClientDiagnostics ClientDiags => _clientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.EventGrid", ResourceType.Namespace, Diagnostics);

        private PrivateLinkResources RestClient => _restClient ??= new PrivateLinkResources(ClientDiags, Pipeline, Endpoint, "2025-07-15-preview");

        public virtual bool HasData { get; }

        public virtual EventGridPrivateLinkResourceData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateLinkResourceName)
        {
            return new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/partnerNamespaces/{parentName}/privateLinkResources/{privateLinkResourceName}");
        }

        public virtual async Task<Response<PartnerNamespacePrivateLinkResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiags.CreateScope("PartnerNamespacePrivateLinkResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "partnerNamespaces", Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var model = EventGrid.Models.EventGridPrivateLinkResource.FromResponse(result);
                var data = EventGridPrivateLinkResourceData.FromModel(model);
                return Response.FromValue(new PartnerNamespacePrivateLinkResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<PartnerNamespacePrivateLinkResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiags.CreateScope("PartnerNamespacePrivateLinkResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "partnerNamespaces", Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                var model = EventGrid.Models.EventGridPrivateLinkResource.FromResponse(result);
                var data = EventGridPrivateLinkResourceData.FromModel(model);
                return Response.FromValue(new PartnerNamespacePrivateLinkResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // IJsonModel / IPersistableModel stubs for backward compat.
        EventGridPrivateLinkResourceData IJsonModel<EventGridPrivateLinkResourceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotImplementedException();
        void IJsonModel<EventGridPrivateLinkResourceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        EventGridPrivateLinkResourceData IPersistableModel<EventGridPrivateLinkResourceData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotImplementedException();
        string IPersistableModel<EventGridPrivateLinkResourceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<EventGridPrivateLinkResourceData>.Write(ModelReaderWriterOptions options) => throw new NotImplementedException();
    }
}
*/
