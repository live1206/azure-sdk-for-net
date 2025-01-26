// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Type.Property.Nullable.Models
{
    public partial class BytesProperty : IJsonModel<BytesProperty>
    {
        void IJsonModel<BytesProperty>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw null;

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw null;

        BytesProperty IJsonModel<BytesProperty>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;

        protected virtual BytesProperty JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;

        BinaryData IPersistableModel<BytesProperty>.Write(ModelReaderWriterOptions options) => throw null;

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => throw null;

        BytesProperty IPersistableModel<BytesProperty>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;

        protected virtual BytesProperty PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options) => throw null;

        string IPersistableModel<BytesProperty>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;

        /// <param name="bytesProperty"> The <see cref="BytesProperty"/> to serialize into <see cref="RequestContent"/>. </param>
        public static implicit operator RequestContent(BytesProperty bytesProperty) => throw null;

        public static explicit operator BytesProperty(Response result) => throw null;
    }
}
