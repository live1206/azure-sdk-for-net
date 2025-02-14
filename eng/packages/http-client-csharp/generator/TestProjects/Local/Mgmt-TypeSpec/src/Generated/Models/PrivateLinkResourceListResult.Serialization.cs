// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using MgmtTypeSpec;

namespace MgmtTypeSpec.Models
{
    /// <summary></summary>
    internal partial class PrivateLinkResourceListResult : IJsonModel<PrivateLinkResourceListResult>
    {
        internal PrivateLinkResourceListResult()
        {
        }

        void IJsonModel<PrivateLinkResourceListResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PrivateLinkResourceListResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PrivateLinkResourceListResult)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("value"u8);
            writer.WriteStartArray();
            foreach (PrivateLinkResource item in Value)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(NextLink))
            {
                writer.WritePropertyName("nextLink"u8);
                writer.WriteStringValue(NextLink.AbsoluteUri);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
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

        PrivateLinkResourceListResult IJsonModel<PrivateLinkResourceListResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual PrivateLinkResourceListResult JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PrivateLinkResourceListResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PrivateLinkResourceListResult)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePrivateLinkResourceListResult(document.RootElement, options);
        }

        internal static PrivateLinkResourceListResult DeserializePrivateLinkResourceListResult(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<PrivateLinkResource> value = default;
            Uri nextLink = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("value"u8))
                {
                    List<PrivateLinkResource> array = new List<PrivateLinkResource>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(PrivateLinkResource.DeserializePrivateLinkResource(item, options));
                    }
                    value = array;
                    continue;
                }
                if (prop.NameEquals("nextLink"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nextLink = new Uri(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new PrivateLinkResourceListResult(value, nextLink, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<PrivateLinkResourceListResult>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PrivateLinkResourceListResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(PrivateLinkResourceListResult)} does not support writing '{options.Format}' format.");
            }
        }

        PrivateLinkResourceListResult IPersistableModel<PrivateLinkResourceListResult>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual PrivateLinkResourceListResult PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PrivateLinkResourceListResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializePrivateLinkResourceListResult(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(PrivateLinkResourceListResult)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<PrivateLinkResourceListResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="privateLinkResourceListResult"> The <see cref="PrivateLinkResourceListResult"/> to serialize into <see cref="RequestContent"/>. </param>
        public static implicit operator RequestContent(PrivateLinkResourceListResult privateLinkResourceListResult)
        {
            if (privateLinkResourceListResult == null)
            {
                return null;
            }
            Utf8JsonBinaryContent content = new Utf8JsonBinaryContent();
            content.JsonWriter.WriteObjectValue(privateLinkResourceListResult, ModelSerializationExtensions.WireOptions);
            return content;
        }

        /// <param name="result"> The <see cref="Response"/> to deserialize the <see cref="PrivateLinkResourceListResult"/> from. </param>
        public static explicit operator PrivateLinkResourceListResult(Response result)
        {
            using Response response = result;
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializePrivateLinkResourceListResult(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
