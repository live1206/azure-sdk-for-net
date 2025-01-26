// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.IotOperations.Models
{
    public partial class BrokerClientConfig : IUtf8JsonSerializable, IJsonModel<BrokerClientConfig>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BrokerClientConfig>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<BrokerClientConfig>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BrokerClientConfig>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BrokerClientConfig)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(MaxSessionExpirySeconds))
            {
                writer.WritePropertyName("maxSessionExpirySeconds"u8);
                writer.WriteNumberValue(MaxSessionExpirySeconds.Value);
            }
            if (Optional.IsDefined(MaxMessageExpirySeconds))
            {
                writer.WritePropertyName("maxMessageExpirySeconds"u8);
                writer.WriteNumberValue(MaxMessageExpirySeconds.Value);
            }
            if (Optional.IsDefined(MaxPacketSizeBytes))
            {
                writer.WritePropertyName("maxPacketSizeBytes"u8);
                writer.WriteNumberValue(MaxPacketSizeBytes.Value);
            }
            if (Optional.IsDefined(SubscriberQueueLimit))
            {
                writer.WritePropertyName("subscriberQueueLimit"u8);
                writer.WriteObjectValue(SubscriberQueueLimit, options);
            }
            if (Optional.IsDefined(MaxReceiveMaximum))
            {
                writer.WritePropertyName("maxReceiveMaximum"u8);
                writer.WriteNumberValue(MaxReceiveMaximum.Value);
            }
            if (Optional.IsDefined(MaxKeepAliveSeconds))
            {
                writer.WritePropertyName("maxKeepAliveSeconds"u8);
                writer.WriteNumberValue(MaxKeepAliveSeconds.Value);
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

        BrokerClientConfig IJsonModel<BrokerClientConfig>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BrokerClientConfig>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BrokerClientConfig)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBrokerClientConfig(document.RootElement, options);
        }

        internal static BrokerClientConfig DeserializeBrokerClientConfig(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? maxSessionExpirySeconds = default;
            int? maxMessageExpirySeconds = default;
            int? maxPacketSizeBytes = default;
            SubscriberQueueLimit subscriberQueueLimit = default;
            int? maxReceiveMaximum = default;
            int? maxKeepAliveSeconds = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxSessionExpirySeconds"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxSessionExpirySeconds = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxMessageExpirySeconds"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxMessageExpirySeconds = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxPacketSizeBytes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxPacketSizeBytes = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("subscriberQueueLimit"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    subscriberQueueLimit = SubscriberQueueLimit.DeserializeSubscriberQueueLimit(property.Value, options);
                    continue;
                }
                if (property.NameEquals("maxReceiveMaximum"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxReceiveMaximum = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxKeepAliveSeconds"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxKeepAliveSeconds = property.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new BrokerClientConfig(
                maxSessionExpirySeconds,
                maxMessageExpirySeconds,
                maxPacketSizeBytes,
                subscriberQueueLimit,
                maxReceiveMaximum,
                maxKeepAliveSeconds,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<BrokerClientConfig>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BrokerClientConfig>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(BrokerClientConfig)} does not support writing '{options.Format}' format.");
            }
        }

        BrokerClientConfig IPersistableModel<BrokerClientConfig>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BrokerClientConfig>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeBrokerClientConfig(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(BrokerClientConfig)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<BrokerClientConfig>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
