// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class ServiceBusDeadletterMessagesAvailableWithNoListenersEventData : IUtf8JsonSerializable, IJsonModel<ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ServiceBusDeadletterMessagesAvailableWithNoListenersEventData)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("namespaceName"u8);
            writer.WriteStringValue(NamespaceName);
            writer.WritePropertyName("requestUri"u8);
            writer.WriteStringValue(RequestUri);
            writer.WritePropertyName("entityType"u8);
            writer.WriteStringValue(EntityType);
            if (QueueName != null)
            {
                writer.WritePropertyName("queueName"u8);
                writer.WriteStringValue(QueueName);
            }
            else
            {
                writer.WriteNull("queueName");
            }
            if (TopicName != null)
            {
                writer.WritePropertyName("topicName"u8);
                writer.WriteStringValue(TopicName);
            }
            else
            {
                writer.WriteNull("topicName");
            }
            if (SubscriptionName != null)
            {
                writer.WritePropertyName("subscriptionName"u8);
                writer.WriteStringValue(SubscriptionName);
            }
            else
            {
                writer.WriteNull("subscriptionName");
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        ServiceBusDeadletterMessagesAvailableWithNoListenersEventData IJsonModel<ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ServiceBusDeadletterMessagesAvailableWithNoListenersEventData)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeServiceBusDeadletterMessagesAvailableWithNoListenersEventData(document.RootElement, options);
        }

        internal static ServiceBusDeadletterMessagesAvailableWithNoListenersEventData DeserializeServiceBusDeadletterMessagesAvailableWithNoListenersEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string namespaceName = default;
            string requestUri = default;
            string entityType = default;
            string queueName = default;
            string topicName = default;
            string subscriptionName = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("namespaceName"u8))
                {
                    namespaceName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requestUri"u8))
                {
                    requestUri = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("entityType"u8))
                {
                    entityType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("queueName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        queueName = null;
                        continue;
                    }
                    queueName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("topicName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        topicName = null;
                        continue;
                    }
                    topicName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("subscriptionName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        subscriptionName = null;
                        continue;
                    }
                    subscriptionName = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ServiceBusDeadletterMessagesAvailableWithNoListenersEventData(
                namespaceName,
                requestUri,
                entityType,
                queueName,
                topicName,
                subscriptionName,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ServiceBusDeadletterMessagesAvailableWithNoListenersEventData)} does not support writing '{options.Format}' format.");
            }
        }

        ServiceBusDeadletterMessagesAvailableWithNoListenersEventData IPersistableModel<ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeServiceBusDeadletterMessagesAvailableWithNoListenersEventData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ServiceBusDeadletterMessagesAvailableWithNoListenersEventData)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ServiceBusDeadletterMessagesAvailableWithNoListenersEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeServiceBusDeadletterMessagesAvailableWithNoListenersEventData(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
