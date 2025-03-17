﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections.Generic;

namespace Azure.Generator.Tests.Common
{
    internal static class InputResourceData
    {
        public static (InputClient InputClient, IReadOnlyList<InputModelType> InputModels) ClientWithResource()
        {
            const string TestClientName = "TestClient";
            const string ResourceModelName = "ResponseType";
            var responseModel = InputFactory.Model(ResourceModelName,
                        usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                        properties:
                        [
                            InputFactory.Property("id", InputPrimitiveType.String),
                            InputFactory.Property("type", InputPrimitiveType.String),
                            InputFactory.Property("name", InputFactory.Primitive.String()),
                        ],
                        decorators: [new InputDecoratorInfo(KnownDecorators.ArmResourceInternal, null)]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: responseModel);
            var testNameParameter = InputFactory.Parameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "Get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: [new InputDecoratorInfo(KnownDecorators.ArmResourceRead, null)]);
            var resourceMetadataArguments = new Dictionary<string, BinaryData>
            {
                { KnownDecorators.ResourceModel, BinaryData.FromString($"\"{ResourceModelName}\"") },
                { KnownDecorators.ResourceType, BinaryData.FromString("\"a/test\"") }
            };
            var client = InputFactory.Client(TestClientName, operations: [operation], decorators: [new InputDecoratorInfo(KnownDecorators.ResourceMetadata, resourceMetadataArguments), new InputDecoratorInfo(KnownDecorators.ArmProviderNamespace, null)]);
            return (client, [responseModel]);
        }
    }
}
