// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.AgriculturePlatform.Models
{
    public partial class DataManagerForAgricultureSolution : IUtf8JsonSerializable, IJsonModel<DataManagerForAgricultureSolution>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DataManagerForAgricultureSolution>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<DataManagerForAgricultureSolution>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataManagerForAgricultureSolution>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataManagerForAgricultureSolution)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("partnerId"u8);
            writer.WriteStringValue(PartnerId);
            writer.WritePropertyName("solutionId"u8);
            writer.WriteStringValue(SolutionId);
            writer.WritePropertyName("partnerTenantId"u8);
            writer.WriteStringValue(PartnerTenantId);
            writer.WritePropertyName("dataAccessScopes"u8);
            writer.WriteStartArray();
            foreach (var item in DataAccessScopes)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("marketPlaceOfferDetails"u8);
            writer.WriteObjectValue(MarketPlaceOfferDetails, options);
            writer.WritePropertyName("saasApplicationId"u8);
            writer.WriteStringValue(SaasApplicationId);
            writer.WritePropertyName("accessAzureDataManagerForAgricultureApplicationId"u8);
            writer.WriteStringValue(AccessAzureDataManagerForAgricultureApplicationId);
            writer.WritePropertyName("accessAzureDataManagerForAgricultureApplicationName"u8);
            writer.WriteStringValue(AccessAzureDataManagerForAgricultureApplicationName);
            writer.WritePropertyName("isValidateInput"u8);
            writer.WriteBooleanValue(IsValidateInput);
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

        DataManagerForAgricultureSolution IJsonModel<DataManagerForAgricultureSolution>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataManagerForAgricultureSolution>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataManagerForAgricultureSolution)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDataManagerForAgricultureSolution(document.RootElement, options);
        }

        internal static DataManagerForAgricultureSolution DeserializeDataManagerForAgricultureSolution(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string partnerId = default;
            string solutionId = default;
            string partnerTenantId = default;
            IReadOnlyList<string> dataAccessScopes = default;
            MarketPlaceOfferDetails marketPlaceOfferDetails = default;
            string saasApplicationId = default;
            string accessAzureDataManagerForAgricultureApplicationId = default;
            string accessAzureDataManagerForAgricultureApplicationName = default;
            bool isValidateInput = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("partnerId"u8))
                {
                    partnerId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("solutionId"u8))
                {
                    solutionId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("partnerTenantId"u8))
                {
                    partnerTenantId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("dataAccessScopes"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    dataAccessScopes = array;
                    continue;
                }
                if (property.NameEquals("marketPlaceOfferDetails"u8))
                {
                    marketPlaceOfferDetails = MarketPlaceOfferDetails.DeserializeMarketPlaceOfferDetails(property.Value, options);
                    continue;
                }
                if (property.NameEquals("saasApplicationId"u8))
                {
                    saasApplicationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("accessAzureDataManagerForAgricultureApplicationId"u8))
                {
                    accessAzureDataManagerForAgricultureApplicationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("accessAzureDataManagerForAgricultureApplicationName"u8))
                {
                    accessAzureDataManagerForAgricultureApplicationName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("isValidateInput"u8))
                {
                    isValidateInput = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new DataManagerForAgricultureSolution(
                partnerId,
                solutionId,
                partnerTenantId,
                dataAccessScopes,
                marketPlaceOfferDetails,
                saasApplicationId,
                accessAzureDataManagerForAgricultureApplicationId,
                accessAzureDataManagerForAgricultureApplicationName,
                isValidateInput,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DataManagerForAgricultureSolution>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataManagerForAgricultureSolution>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DataManagerForAgricultureSolution)} does not support writing '{options.Format}' format.");
            }
        }

        DataManagerForAgricultureSolution IPersistableModel<DataManagerForAgricultureSolution>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataManagerForAgricultureSolution>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeDataManagerForAgricultureSolution(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DataManagerForAgricultureSolution)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DataManagerForAgricultureSolution>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
