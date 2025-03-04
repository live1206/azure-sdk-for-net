// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using System.Linq;
using NUnit.Framework;
using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;

namespace Azure.Generator.Tests.Providers.Abstractions
{
    internal class AzureClientResponseProviderTests
    {
        [Test]
        public void ValidateReturnTypeIsOverridden()
        {
            ClientProvider clientProvider = CreateMockClientProvider();

            var method = clientProvider.Methods.FirstOrDefault(x => !x.Signature.Name.EndsWith("Async"));
            Assert.NotNull(method);
            Assert.NotNull(method!.Signature.ReturnType);
            Assert.IsTrue(method!.Signature.ReturnType!.Equals(typeof(Response)));
        }

        [Test]
        public void ValidateBodyOfClientOperationIsOverridden()
        {
            var clientProvider = CreateMockClientProvider();

            var method = clientProvider.Methods.FirstOrDefault(x => x.Signature.Parameters.Any(p => p.Type.Equals(typeof(RequestContext))) && !x.Signature.Name.EndsWith("Async"));
            Assert.NotNull(method);
            Assert.NotNull(method!.BodyStatements);
            Assert.AreEqual(Helpers.GetExpectedFromFile(), method.BodyStatements!.ToDisplayString());
        }

        [Test]
        public void ValidateClientResponseExceptionTypeIsOverridden()
        {
            MockHelpers.LoadMockPlugin<AzureClientPlugin>();
            var pipelineExtensions =
                AzureClientPlugin.Instance.OutputLibrary.TypeProviders.FirstOrDefault(t => t.Name == "ClientPipelineExtensions");
            Assert.NotNull(pipelineExtensions);
            var method = pipelineExtensions!.Methods.FirstOrDefault(x => x.Signature.Name == "ProcessMessage");
            Assert.NotNull(method);
            Assert.NotNull(method!.BodyStatements);
            Assert.AreEqual(Helpers.GetExpectedFromFile(), method.BodyStatements!.ToDisplayString());
        }

        private static ClientProvider CreateMockClientProvider()
        {
            var client = InputFactory.Client("TestClient", operations: [InputFactory.Operation("foo")]);
            MockHelpers.LoadMockPlugin<AzureClientPlugin>(clientResponseApi: AzureClientResponseProvider.Instance);
            var clientProvider = AzureClientPlugin.Instance.TypeFactory.CreateClient(client)!;
            return clientProvider;
        }
    }
}
