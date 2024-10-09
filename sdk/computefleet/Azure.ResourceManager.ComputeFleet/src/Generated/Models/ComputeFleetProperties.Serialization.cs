// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ComputeFleet.Models
{
    public partial class ComputeFleetProperties : IUtf8JsonSerializable, IJsonModel<ComputeFleetProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ComputeFleetProperties>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ComputeFleetProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComputeFleetProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ComputeFleetProperties)} does not support writing '{format}' format.");
            }

            if (options.Format != "W" && Optional.IsDefined(ProvisioningState))
            {
                writer.WritePropertyName("provisioningState"u8);
                writer.WriteStringValue(ProvisioningState.Value.ToString());
            }
            if (Optional.IsDefined(SpotPriorityProfile))
            {
                writer.WritePropertyName("spotPriorityProfile"u8);
                writer.WriteObjectValue(SpotPriorityProfile, options);
            }
            if (Optional.IsDefined(RegularPriorityProfile))
            {
                writer.WritePropertyName("regularPriorityProfile"u8);
                writer.WriteObjectValue(RegularPriorityProfile, options);
            }
            writer.WritePropertyName("vmSizesProfile"u8);
            writer.WriteStartArray();
            foreach (var item in VmSizesProfile)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(VmAttributes))
            {
                writer.WritePropertyName("vmAttributes"u8);
                writer.WriteObjectValue(VmAttributes, options);
            }
            if (Optional.IsDefined(AdditionalLocationsProfile))
            {
                writer.WritePropertyName("additionalLocationsProfile"u8);
                writer.WriteObjectValue(AdditionalLocationsProfile, options);
            }
            writer.WritePropertyName("computeProfile"u8);
            writer.WriteObjectValue(ComputeProfile, options);
            if (options.Format != "W" && Optional.IsDefined(CreatedOn))
            {
                writer.WritePropertyName("timeCreated"u8);
                writer.WriteStringValue(CreatedOn.Value, "O");
            }
            if (options.Format != "W" && Optional.IsDefined(UniqueId))
            {
                writer.WritePropertyName("uniqueId"u8);
                writer.WriteStringValue(UniqueId);
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

        ComputeFleetProperties IJsonModel<ComputeFleetProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComputeFleetProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ComputeFleetProperties)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeComputeFleetProperties(document.RootElement, options);
        }

        internal static ComputeFleetProperties DeserializeComputeFleetProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ComputeFleetProvisioningState? provisioningState = default;
            SpotPriorityProfile spotPriorityProfile = default;
            RegularPriorityProfile regularPriorityProfile = default;
            IList<ComputeFleetVmSizeProfile> vmSizesProfile = default;
            VmAttributes vmAttributes = default;
            AdditionalLocationsProfile additionalLocationsProfile = default;
            ComputeFleetComputeProfile computeProfile = default;
            DateTimeOffset? timeCreated = default;
            string uniqueId = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("provisioningState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    provisioningState = new ComputeFleetProvisioningState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("spotPriorityProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    spotPriorityProfile = SpotPriorityProfile.DeserializeSpotPriorityProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("regularPriorityProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    regularPriorityProfile = RegularPriorityProfile.DeserializeRegularPriorityProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("vmSizesProfile"u8))
                {
                    List<ComputeFleetVmSizeProfile> array = new List<ComputeFleetVmSizeProfile>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ComputeFleetVmSizeProfile.DeserializeComputeFleetVmSizeProfile(item, options));
                    }
                    vmSizesProfile = array;
                    continue;
                }
                if (property.NameEquals("vmAttributes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vmAttributes = VmAttributes.DeserializeVmAttributes(property.Value, options);
                    continue;
                }
                if (property.NameEquals("additionalLocationsProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    additionalLocationsProfile = AdditionalLocationsProfile.DeserializeAdditionalLocationsProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("computeProfile"u8))
                {
                    computeProfile = ComputeFleetComputeProfile.DeserializeComputeFleetComputeProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("timeCreated"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    timeCreated = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("uniqueId"u8))
                {
                    uniqueId = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ComputeFleetProperties(
                provisioningState,
                spotPriorityProfile,
                regularPriorityProfile,
                vmSizesProfile,
                vmAttributes,
                additionalLocationsProfile,
                computeProfile,
                timeCreated,
                uniqueId,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ComputeFleetProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComputeFleetProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ComputeFleetProperties)} does not support writing '{options.Format}' format.");
            }
        }

        ComputeFleetProperties IPersistableModel<ComputeFleetProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComputeFleetProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeComputeFleetProperties(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ComputeFleetProperties)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ComputeFleetProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
