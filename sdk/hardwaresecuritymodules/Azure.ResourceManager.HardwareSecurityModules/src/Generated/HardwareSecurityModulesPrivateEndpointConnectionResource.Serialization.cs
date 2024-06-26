// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.HardwareSecurityModules
{
    public partial class HardwareSecurityModulesPrivateEndpointConnectionResource : IJsonModel<HardwareSecurityModulesPrivateEndpointConnectionData>
    {
        void IJsonModel<HardwareSecurityModulesPrivateEndpointConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<HardwareSecurityModulesPrivateEndpointConnectionData>)Data).Write(writer, options);

        HardwareSecurityModulesPrivateEndpointConnectionData IJsonModel<HardwareSecurityModulesPrivateEndpointConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<HardwareSecurityModulesPrivateEndpointConnectionData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<HardwareSecurityModulesPrivateEndpointConnectionData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(Data, options);

        HardwareSecurityModulesPrivateEndpointConnectionData IPersistableModel<HardwareSecurityModulesPrivateEndpointConnectionData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<HardwareSecurityModulesPrivateEndpointConnectionData>(data, options);

        string IPersistableModel<HardwareSecurityModulesPrivateEndpointConnectionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<HardwareSecurityModulesPrivateEndpointConnectionData>)Data).GetFormatFromOptions(options);
    }
}
