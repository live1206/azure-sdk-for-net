// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Moq;
using System.Reflection;

namespace Azure.Generator.Mgmt.Tests.TestHelpers
{
    internal class MgmtMockHelpers
    {
        public static Mock<MgmtClientPlugin> LoadMockPlugin(
            Func<InputType, TypeProvider, IReadOnlyList<TypeProvider>>? createSerializationsCore = null,
            Func<InputType, CSharpType>? createCSharpTypeCore = null,
            Func<InputApiKeyAuth>? apiKeyAuth = null,
            Func<InputOAuth2Auth>? oauth2Auth = null,
            Func<IReadOnlyList<string>>? apiVersions = null,
            Func<IReadOnlyList<InputEnumType>>? inputEnums = null,
            Func<IReadOnlyList<InputModelType>>? inputModels = null,
            Func<IReadOnlyList<InputClient>>? clients = null,
            ClientResponseApi? clientResponseApi = null,
            ClientPipelineApi? clientPipelineApi = null,
            HttpMessageApi? httpMessageApi = null)
        {
            var mgmtInstance = typeof(MgmtClientPlugin).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            var plugin = MockHelpers.LoadMockPlugin<MgmtClientPlugin>(
                createSerializationsCore,
                createCSharpTypeCore,
                apiKeyAuth,
                oauth2Auth,
                apiVersions,
                inputEnums,
                inputModels,
                clients,
                clientResponseApi,
                clientPipelineApi,
                httpMessageApi);
            mgmtInstance!.SetValue(null, plugin.Object);
            return plugin;
        }
    }
}
