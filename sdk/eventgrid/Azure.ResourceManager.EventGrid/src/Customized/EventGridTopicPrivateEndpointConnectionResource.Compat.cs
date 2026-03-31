// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

// Backward compat: the old SDK (1.1.0) had per-parent Resource classes for private endpoint connections.
// The new TypeSpec generator uses RoutedOperations with a dynamic parentType parameter, which doesn't
// produce separate Resource classes. This stub restores the old API surface for topics.

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
    public partial class EventGridTopicPrivateEndpointConnectionResource : ArmResource,
        IJsonModel<EventGridPrivateEndpointConnectionData>,
        IPersistableModel<EventGridPrivateEndpointConnectionData>
    {
        public static readonly ResourceType ResourceType = "Microsoft.EventGrid/topics/privateEndpointConnections";

        private EventGridPrivateEndpointConnectionData _data;
        private ClientDiagnostics _clientDiagnostics;
        private PrivateEndpointConnections _restClient;

        protected EventGridTopicPrivateEndpointConnectionResource() { }

        internal EventGridTopicPrivateEndpointConnectionResource(ArmClient client, EventGridPrivateEndpointConnectionData data)
            : base(client, data.Id)
        {
            _data = data;
            HasData = true;
        }

        internal EventGridTopicPrivateEndpointConnectionResource(ArmClient client, ResourceIdentifier id)
            : base(client, id)
        {
        }

        private ClientDiagnostics ClientDiags => _clientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.EventGrid", ResourceType.Namespace, Diagnostics);

        private PrivateEndpointConnections RestClient => _restClient ??= new PrivateEndpointConnections(ClientDiags, Pipeline, Endpoint, "2025-07-15-preview");

        public virtual bool HasData { get; }

        public virtual EventGridPrivateEndpointConnectionData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateEndpointConnectionName)
        {
            return new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}");
        }

        public virtual async Task<Response<EventGridTopicPrivateEndpointConnectionResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridTopicPrivateEndpointConnectionResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "topics", Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var data = EventGridPrivateEndpointConnectionData.FromResponse(result);
                return Response.FromValue(new EventGridTopicPrivateEndpointConnectionResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<EventGridTopicPrivateEndpointConnectionResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridTopicPrivateEndpointConnectionResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "topics", Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                var data = EventGridPrivateEndpointConnectionData.FromResponse(result);
                return Response.FromValue(new EventGridTopicPrivateEndpointConnectionResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<ArmOperation<EventGridTopicPrivateEndpointConnectionResource>> UpdateAsync(WaitUntil waitUntil, EventGridPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridTopicPrivateEndpointConnectionResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "topics", Id.Parent.Name, Id.Name, EventGridPrivateEndpointConnectionData.ToRequestContent(data), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var operation = new EventGridArmOperation<EventGridTopicPrivateEndpointConnectionResource>(
                    new TopicPrivateEndpointConnectionOperationSource(Client),
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

        public virtual ArmOperation<EventGridTopicPrivateEndpointConnectionResource> Update(WaitUntil waitUntil, EventGridPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridTopicPrivateEndpointConnectionResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "topics", Id.Parent.Name, Id.Name, EventGridPrivateEndpointConnectionData.ToRequestContent(data), context);
                Response response = Pipeline.ProcessMessage(message, context);
                var operation = new EventGridArmOperation<EventGridTopicPrivateEndpointConnectionResource>(
                    new TopicPrivateEndpointConnectionOperationSource(Client),
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

        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridTopicPrivateEndpointConnectionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "topics", Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var operation = new EventGridArmOperation(ClientDiags, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiags.CreateScope("EventGridTopicPrivateEndpointConnectionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = RestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, "topics", Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                var operation = new EventGridArmOperation(ClientDiags, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // IJsonModel / IPersistableModel stubs – the resource type is not directly serialized by callers.
        EventGridPrivateEndpointConnectionData IJsonModel<EventGridPrivateEndpointConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotImplementedException();
        void IJsonModel<EventGridPrivateEndpointConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        EventGridPrivateEndpointConnectionData IPersistableModel<EventGridPrivateEndpointConnectionData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotImplementedException();
        string IPersistableModel<EventGridPrivateEndpointConnectionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<EventGridPrivateEndpointConnectionData>.Write(ModelReaderWriterOptions options) => throw new NotImplementedException();
    }
}
