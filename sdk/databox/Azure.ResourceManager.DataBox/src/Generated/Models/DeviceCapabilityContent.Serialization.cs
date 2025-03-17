// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DataBox.Models
{
    public partial class DeviceCapabilityContent : IUtf8JsonSerializable, IJsonModel<DeviceCapabilityContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DeviceCapabilityContent>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<DeviceCapabilityContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeviceCapabilityContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeviceCapabilityContent)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(SkuName))
            {
                writer.WritePropertyName("skuName"u8);
                writer.WriteStringValue(SkuName.Value.ToSerialString());
            }
            if (Optional.IsDefined(Model))
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(Model.Value.ToSerialString());
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        DeviceCapabilityContent IJsonModel<DeviceCapabilityContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeviceCapabilityContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeviceCapabilityContent)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeviceCapabilityContent(document.RootElement, options);
        }

        internal static DeviceCapabilityContent DeserializeDeviceCapabilityContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DataBoxSkuName? skuName = default;
            DeviceModelName? model = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("skuName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    skuName = property.Value.GetString().ToDataBoxSkuName();
                    continue;
                }
                if (property.NameEquals("model"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    model = property.Value.GetString().ToDeviceModelName();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new DeviceCapabilityContent(skuName, model, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DeviceCapabilityContent>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeviceCapabilityContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DeviceCapabilityContent)} does not support writing '{options.Format}' format.");
            }
        }

        DeviceCapabilityContent IPersistableModel<DeviceCapabilityContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeviceCapabilityContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeDeviceCapabilityContent(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DeviceCapabilityContent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DeviceCapabilityContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
