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
    public partial class AcsChatParticipantRemovedFromThreadWithUserEventData : IUtf8JsonSerializable, IJsonModel<AcsChatParticipantRemovedFromThreadWithUserEventData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AcsChatParticipantRemovedFromThreadWithUserEventData>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<AcsChatParticipantRemovedFromThreadWithUserEventData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AcsChatParticipantRemovedFromThreadWithUserEventData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AcsChatParticipantRemovedFromThreadWithUserEventData)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Time))
            {
                writer.WritePropertyName("time"u8);
                writer.WriteStringValue(Time.Value, "O");
            }
            writer.WritePropertyName("removedByCommunicationIdentifier"u8);
            writer.WriteObjectValue(RemovedByCommunicationIdentifier, options);
            writer.WritePropertyName("participantRemoved"u8);
            writer.WriteObjectValue(ParticipantRemoved, options);
        }

        AcsChatParticipantRemovedFromThreadWithUserEventData IJsonModel<AcsChatParticipantRemovedFromThreadWithUserEventData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AcsChatParticipantRemovedFromThreadWithUserEventData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AcsChatParticipantRemovedFromThreadWithUserEventData)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAcsChatParticipantRemovedFromThreadWithUserEventData(document.RootElement, options);
        }

        internal static AcsChatParticipantRemovedFromThreadWithUserEventData DeserializeAcsChatParticipantRemovedFromThreadWithUserEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DateTimeOffset? time = default;
            CommunicationIdentifierModel removedByCommunicationIdentifier = default;
            AcsChatThreadParticipantProperties participantRemoved = default;
            DateTimeOffset? createTime = default;
            long? version = default;
            CommunicationIdentifierModel recipientCommunicationIdentifier = default;
            string transactionId = default;
            string threadId = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("time"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    time = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("removedByCommunicationIdentifier"u8))
                {
                    removedByCommunicationIdentifier = CommunicationIdentifierModel.DeserializeCommunicationIdentifierModel(property.Value, options);
                    continue;
                }
                if (property.NameEquals("participantRemoved"u8))
                {
                    participantRemoved = AcsChatThreadParticipantProperties.DeserializeAcsChatThreadParticipantProperties(property.Value, options);
                    continue;
                }
                if (property.NameEquals("createTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    createTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("version"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    version = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("recipientCommunicationIdentifier"u8))
                {
                    recipientCommunicationIdentifier = CommunicationIdentifierModel.DeserializeCommunicationIdentifierModel(property.Value, options);
                    continue;
                }
                if (property.NameEquals("transactionId"u8))
                {
                    transactionId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("threadId"u8))
                {
                    threadId = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new AcsChatParticipantRemovedFromThreadWithUserEventData(
                recipientCommunicationIdentifier,
                transactionId,
                threadId,
                serializedAdditionalRawData,
                createTime,
                version,
                time,
                removedByCommunicationIdentifier,
                participantRemoved);
        }

        BinaryData IPersistableModel<AcsChatParticipantRemovedFromThreadWithUserEventData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AcsChatParticipantRemovedFromThreadWithUserEventData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(AcsChatParticipantRemovedFromThreadWithUserEventData)} does not support writing '{options.Format}' format.");
            }
        }

        AcsChatParticipantRemovedFromThreadWithUserEventData IPersistableModel<AcsChatParticipantRemovedFromThreadWithUserEventData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AcsChatParticipantRemovedFromThreadWithUserEventData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeAcsChatParticipantRemovedFromThreadWithUserEventData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AcsChatParticipantRemovedFromThreadWithUserEventData)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AcsChatParticipantRemovedFromThreadWithUserEventData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new AcsChatParticipantRemovedFromThreadWithUserEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAcsChatParticipantRemovedFromThreadWithUserEventData(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
