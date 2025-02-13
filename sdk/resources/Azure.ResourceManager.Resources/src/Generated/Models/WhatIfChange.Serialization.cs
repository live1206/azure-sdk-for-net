// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class WhatIfChange : IUtf8JsonSerializable, IJsonModel<WhatIfChange>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<WhatIfChange>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<WhatIfChange>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<WhatIfChange>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(WhatIfChange)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("resourceId"u8);
            writer.WriteStringValue(ResourceId);
            if (Optional.IsDefined(DeploymentId))
            {
                writer.WritePropertyName("deploymentId"u8);
                writer.WriteStringValue(DeploymentId);
            }
            if (Optional.IsDefined(SymbolicName))
            {
                writer.WritePropertyName("symbolicName"u8);
                writer.WriteStringValue(SymbolicName);
            }
            if (Optional.IsDefined(Identifiers))
            {
                writer.WritePropertyName("identifiers"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Identifiers);
#else
                using (JsonDocument document = JsonDocument.Parse(Identifiers))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            writer.WritePropertyName("changeType"u8);
            writer.WriteStringValue(ChangeType.ToSerialString());
            if (Optional.IsDefined(UnsupportedReason))
            {
                writer.WritePropertyName("unsupportedReason"u8);
                writer.WriteStringValue(UnsupportedReason);
            }
            if (Optional.IsDefined(Before))
            {
                writer.WritePropertyName("before"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Before);
#else
                using (JsonDocument document = JsonDocument.Parse(Before))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (Optional.IsDefined(After))
            {
                writer.WritePropertyName("after"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(After);
#else
                using (JsonDocument document = JsonDocument.Parse(After))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (Optional.IsCollectionDefined(Delta))
            {
                writer.WritePropertyName("delta"u8);
                writer.WriteStartArray();
                foreach (var item in Delta)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
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

        WhatIfChange IJsonModel<WhatIfChange>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<WhatIfChange>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(WhatIfChange)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeWhatIfChange(document.RootElement, options);
        }

        internal static WhatIfChange DeserializeWhatIfChange(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string resourceId = default;
            string deploymentId = default;
            string symbolicName = default;
            BinaryData identifiers = default;
            WhatIfChangeType changeType = default;
            string unsupportedReason = default;
            BinaryData before = default;
            BinaryData after = default;
            IReadOnlyList<WhatIfPropertyChange> delta = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resourceId"u8))
                {
                    resourceId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("deploymentId"u8))
                {
                    deploymentId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("symbolicName"u8))
                {
                    symbolicName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("identifiers"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    identifiers = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("changeType"u8))
                {
                    changeType = property.Value.GetString().ToWhatIfChangeType();
                    continue;
                }
                if (property.NameEquals("unsupportedReason"u8))
                {
                    unsupportedReason = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("before"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    before = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("after"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    after = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("delta"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<WhatIfPropertyChange> array = new List<WhatIfPropertyChange>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(WhatIfPropertyChange.DeserializeWhatIfPropertyChange(item, options));
                    }
                    delta = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new WhatIfChange(
                resourceId,
                deploymentId,
                symbolicName,
                identifiers,
                changeType,
                unsupportedReason,
                before,
                after,
                delta ?? new ChangeTrackingList<WhatIfPropertyChange>(),
                serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.PropertyOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ResourceId), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  resourceId: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(ResourceId))
                {
                    builder.Append("  resourceId: ");
                    if (ResourceId.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{ResourceId}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{ResourceId}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(DeploymentId), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  deploymentId: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(DeploymentId))
                {
                    builder.Append("  deploymentId: ");
                    if (DeploymentId.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{DeploymentId}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{DeploymentId}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SymbolicName), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  symbolicName: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(SymbolicName))
                {
                    builder.Append("  symbolicName: ");
                    if (SymbolicName.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{SymbolicName}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{SymbolicName}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Identifiers), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  identifiers: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Identifiers))
                {
                    builder.Append("  identifiers: ");
                    builder.AppendLine($"'{Identifiers.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ChangeType), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  changeType: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                builder.Append("  changeType: ");
                builder.AppendLine($"'{ChangeType.ToSerialString()}'");
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(UnsupportedReason), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  unsupportedReason: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(UnsupportedReason))
                {
                    builder.Append("  unsupportedReason: ");
                    if (UnsupportedReason.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{UnsupportedReason}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{UnsupportedReason}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Before), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  before: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Before))
                {
                    builder.Append("  before: ");
                    builder.AppendLine($"'{Before.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(After), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  after: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(After))
                {
                    builder.Append("  after: ");
                    builder.AppendLine($"'{After.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Delta), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  delta: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsCollectionDefined(Delta))
                {
                    if (Delta.Any())
                    {
                        builder.Append("  delta: ");
                        builder.AppendLine("[");
                        foreach (var item in Delta)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  delta: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<WhatIfChange>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<WhatIfChange>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(WhatIfChange)} does not support writing '{options.Format}' format.");
            }
        }

        WhatIfChange IPersistableModel<WhatIfChange>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<WhatIfChange>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeWhatIfChange(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(WhatIfChange)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<WhatIfChange>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
