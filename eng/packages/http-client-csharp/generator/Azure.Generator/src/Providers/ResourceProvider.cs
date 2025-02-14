﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Mgmt.Models;
using Azure.Generator.Primitives;
using Azure.Generator.Utilities;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal class ResourceProvider : TypeProvider
    {
        private OperationSet _operationSet;
        private ResourceDataProvider _resourceData;
        private ClientProvider _clientProvider;
        private string _specCleanName;
        private readonly IReadOnlyList<string> _contextualParameters;

        private FieldProvider _dataField;
        private FieldProvider _clientDiagonosticsField;
        private FieldProvider _restClientField;
        private FieldProvider _resourcetypeField;

        public ResourceProvider(OperationSet operationSet, string specCleanName, ResourceDataProvider resourceData, string resrouceType)
        {
            _operationSet = operationSet;
            _specCleanName = specCleanName;
            _resourceData = resourceData;
            _clientProvider = AzureClientPlugin.Instance.TypeFactory.CreateClient(operationSet.InputClient)!;
            _contextualParameters = GetContextualParameters(operationSet.RequestPath);

            _dataField = new FieldProvider(FieldModifiers.Private, resourceData.Type, "_data", this);
            _clientDiagonosticsField = new FieldProvider(FieldModifiers.Private, typeof(ClientDiagnostics), $"_{specCleanName.ToLower()}ClientDiagnostics", this);
            _restClientField = new FieldProvider(FieldModifiers.Private, _clientProvider.Type, $"_{specCleanName.ToLower()}RestClient", this);
            _resourcetypeField = new FieldProvider(FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly, typeof(ResourceType), "ResourceType", this, description: $"Gets the resource type for the operations.", initializationValue: Literal(resrouceType));
        }

        private IReadOnlyList<string> GetContextualParameters(string contextualRequestPath)
        {
            var contextualParameters = new List<string>();
            var contextualSegments = new RequestPath(contextualRequestPath);
            foreach (var segment in contextualSegments)
            {
                if (segment.StartsWith("{"))
                {
                    contextualParameters.Add(segment.TrimStart('{').TrimEnd('}'));
                }
            }
            return contextualParameters;
        }

        protected override string BuildName() => $"{_specCleanName}Resource";

        private OperationSourceProvider? _source;
        internal OperationSourceProvider Source => _source ??= new OperationSourceProvider(_specCleanName, this, _resourceData);

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override FieldProvider[] BuildFields() => [_dataField, _clientDiagonosticsField, _restClientField, _resourcetypeField];

        protected override PropertyProvider[] BuildProperties()
        {
            var hasDataProperty = new PropertyProvider(
                $"Gets whether or not the current instance has data.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                typeof(bool),
                "HasData",
                new AutoPropertyBody(false),
                this);

            var dataProperty = new PropertyProvider(
                $"Gets the data representing this Feature.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                _resourceData.Type,
                "Data",
                new MethodPropertyBody(new MethodBodyStatement[]
                {
                    new IfStatement(Not(hasDataProperty))
                    {
                        Throw(New.Instance(typeof(InvalidOperationException), Literal("The current instance does not have data, you must call Get first.")))
                    },
                    Return(_dataField)
                }),
                this);

            return [hasDataProperty, dataProperty];
        }

        protected override ConstructorProvider[] BuildConstructors()
            => [ConstructorProviderHelper.BuildMockingConstructor(this), BuildPrimaryConstructor(), BuildInitializationConstructor(),];

        private ConstructorProvider BuildPrimaryConstructor()
        {
            var clientParameter = new ParameterProvider("client", $"The client parameters to use in these operations.", typeof(ArmClient));
            var dataParameter = new ParameterProvider("data", $"The resource that is the target of operations.", _resourceData.Type);

            var initializer = new ConstructorInitializer(false, [clientParameter, dataParameter.Property("Id")]);
            var signature = new ConstructorSignature(
                Type,
                $"Initializes a new instance of {Type:C} class.",
                MethodSignatureModifiers.Internal,
                [clientParameter, dataParameter],
                null,
                initializer);

            var bodyStatements = new MethodBodyStatement[]
            {
                This.Property("HasData").Assign(Literal(true)).Terminate(),
                _dataField.Assign(dataParameter).Terminate(),
            };

            return new ConstructorProvider(signature, bodyStatements, this);
        }

        private ConstructorProvider BuildInitializationConstructor()
        {
            var idParameter = new ParameterProvider("id", $"The identifier of the resource that is the target of operations.", typeof(ResourceIdentifier));
            var parameters = new List<ParameterProvider>
            {
                new("client", $"The client parameters to use in these operations.", typeof(ArmClient)),
                idParameter
            };

            var initializer = new ConstructorInitializer(true, parameters);
            var signature = new ConstructorSignature(
                Type,
                $"Initializes a new instance of {Type:C} class.",
                MethodSignatureModifiers.Internal,
                parameters,
                null,
                initializer);

            var bodyStatements = new MethodBodyStatement[]
            {
                _clientDiagonosticsField.Assign(New.Instance(typeof(ClientDiagnostics), Literal(Type.Namespace), _resourcetypeField.Property(nameof(ResourceType.Namespace)), This.Property("Diagnostics"))).Terminate(),
                TryGetApiVersion(out var apiVersion).Terminate(),
                _restClientField.Assign(New.Instance(_clientProvider.Type, This.Property("Pipeline"), This.Property("Endpoint"), apiVersion)).Terminate(),
                new IfElsePreprocessorStatement("DEBUG", Static(Type).Invoke(ValidateResourceIdMethodName, idParameter).Terminate(), null)
            };

            return new ConstructorProvider(signature, bodyStatements, this);
        }

        private const string ValidateResourceIdMethodName = "ValidateResourceId";
        private MethodProvider BuildValidateResourceIdMethod()
        {
            var idParameter = new ParameterProvider("id", $"", typeof(ResourceIdentifier));
            var signature = new MethodSignature(
                ValidateResourceIdMethodName,
                null,
                MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
                null,
                null,
                [
                    idParameter
                ]);
            var bodyStatements = new IfStatement(idParameter.NotEqual(_resourcetypeField))
            {
                Throw(New.ArgumentException(idParameter, StringSnippets.Format(Literal("Invalid resource type {0} expected {1}"), idParameter.Property(nameof(ResourceIdentifier.ResourceType)), _resourcetypeField), false))
            };
            return new MethodProvider(signature, bodyStatements, this);
        }

        protected override CSharpType[] BuildImplements() => [typeof(ArmResource)];

        protected override MethodProvider[] BuildMethods()
        {
            var operationMethods = new List<MethodProvider>();
            foreach (var operation in _operationSet)
            {
                var convenienceMethod = GetCorrespondingConvenienceMethod(operation, false);
                // exclude the List operations for resource, they will be in ResourceCollection
                if (convenienceMethod.IsListMethod(out var itemType) && itemType.AreNamesEqual(_resourceData.Type))
                {
                    continue;
                }

                // only update for non-singleton resource
                var isUpdateOnly = operation.HttpMethod == HttpMethod.Put.ToString() && !AzureClientPlugin.Instance.SingletonDetection.IsSingletonResource(_operationSet);
                operationMethods.Add(BuildOperationMethod(operation, convenienceMethod, false, isUpdateOnly));
                var asyncConvenienceMethod = GetCorrespondingConvenienceMethod(operation, true);
                operationMethods.Add(BuildOperationMethod(operation, asyncConvenienceMethod, true, isUpdateOnly));
            }

            return [BuildValidateResourceIdMethod(), .. operationMethods];
        }

        private MethodProvider BuildOperationMethod(InputOperation operation, MethodProvider convenienceMethod, bool isAsync, bool isUpdateOnly = false)
        {
            var isLongRunning = operation.LongRunning != null;
            var signature = new MethodSignature(
                isUpdateOnly ? (isAsync ? "UpdateAsync" : "Update") : convenienceMethod.Signature.Name,
                isUpdateOnly ? $"Update a {_specCleanName}" : convenienceMethod.Signature.Description,
                convenienceMethod.Signature.Modifiers,
                GetOperationMethodReturnType(isAsync, isLongRunning, operation.Responses, out var isGeneric),
                convenienceMethod.Signature.ReturnDescription,
                GetOperationMethodParameters(convenienceMethod, isLongRunning),
                convenienceMethod.Signature.Attributes,
                convenienceMethod.Signature.GenericArguments,
                convenienceMethod.Signature.GenericParameterConstraints,
                convenienceMethod.Signature.ExplicitInterface,
                convenienceMethod.Signature.NonDocumentComment);

            var bodyStatements = new MethodBodyStatement[]
                {
                    UsingDeclare("scope", typeof(DiagnosticScope), _clientDiagonosticsField.Invoke(nameof(ClientDiagnostics.CreateScope), [Literal($"{Type.Namespace}.{operation.Name}")]), out var scopeVariable),
                    scopeVariable.Invoke(nameof(DiagnosticScope.Start)).Terminate(),
                    new TryCatchFinallyStatement
                    (BuildOperationMethodTryStatement(convenienceMethod, isAsync, isLongRunning, operation, isGeneric), Catch(Declare<Exception>("e", out var exceptionVarialble), [scopeVariable.Invoke(nameof(DiagnosticScope.Failed), exceptionVarialble).Terminate(), Throw()]))
                };

            return new MethodProvider(signature, bodyStatements, this);
        }

        private IReadOnlyList<ParameterProvider> GetOperationMethodParameters(MethodProvider convenienceMethod, bool isLongRunning)
        {
            var result = new List<ParameterProvider>();
            if (isLongRunning)
            {
                result.Add(KnownAzureParameters.WaitUntil);
            }
            foreach (var parameter in convenienceMethod.Signature.Parameters)
            {
                if (!_contextualParameters.Contains(parameter.Name))
                {
                    result.Add(parameter);
                }
            }
            return result;
        }

        private CSharpType GetOperationMethodReturnType(bool isAsync, bool isLongRunningOperation, IReadOnlyList<OperationResponse> operationResponses, out bool isGeneric)
        {
            isGeneric = false;
            if (isLongRunningOperation)
            {
                var response = operationResponses.FirstOrDefault(r => !r.IsErrorResponse);
                var responseBodyType = response?.BodyType is null ? null : AzureClientPlugin.Instance.TypeFactory.CreateCSharpType(response.BodyType);
                if (responseBodyType is null)
                {
                    return isAsync ? new CSharpType(typeof(Task<>), typeof(ArmOperation)) : typeof(ArmOperation);
                }
                else
                {
                    isGeneric = true;
                    return isAsync ? new CSharpType(typeof(Task<>), new CSharpType(typeof(ArmOperation<>), Type)) : new CSharpType(typeof(ArmOperation<>), Type);
                }
            }
            return isAsync ? new CSharpType(typeof(Task<>), new CSharpType(typeof(Response<>), Type)) : new CSharpType(typeof(Response<>), Type);
        }

        private TryStatement BuildOperationMethodTryStatement(MethodProvider convenienceMethod, bool isAsync, bool isLongRunning, InputOperation operation, bool isGeneric)
        {
            var cancellationToken = convenienceMethod.Signature.Parameters.Single(p => p.Type.Equals(typeof(CancellationToken)));
            var tryStatement = new TryStatement();
            var responseDeclaration = Declare("response", GetResponseType(convenienceMethod, isAsync), ((MemberExpression)_restClientField).Invoke(convenienceMethod.Signature.Name, PopulateArguments(convenienceMethod.Signature.Parameters, convenienceMethod), null, callAsAsync: isAsync, addConfigureAwaitFalse: isAsync), out var responseVariable);
            tryStatement.Add(responseDeclaration);
            if (isLongRunning)
            {
                var armOperationType = !isGeneric ? AzureClientPlugin.Instance.OutputLibrary.ArmOperation.Type : new CSharpType(AzureClientPlugin.Instance.OutputLibrary.GenericArmOperation, AzureClientPlugin.Instance.TypeFactory.RootNamespace , [Type], null);
                var requestMethod = GetCorrespondingRequestMethod(operation);
                VariableExpression operationVariable;
                ValueExpression[] armOperationArguments = [_clientDiagonosticsField, This.Property("Pipeline"), _restClientField.Invoke(requestMethod.Signature.Name, PopulateArguments(requestMethod.Signature.Parameters, convenienceMethod)).Property("Request"), isGeneric ? responseVariable.Invoke("GetRawResponse") : responseVariable, Static(typeof(OperationFinalStateVia)).Property(((OperationFinalStateVia)operation.LongRunning!.FinalStateVia).ToString())];
                var operationDeclaration = Declare("operation", armOperationType, New.Instance(armOperationType, isGeneric ? [New.Instance(Source.Type, This.Property("Client")), .. armOperationArguments] : armOperationArguments), out operationVariable);
                tryStatement.Add(operationDeclaration);
                tryStatement.Add(new IfStatement(KnownAzureParameters.WaitUntil.Equal(Static(typeof(WaitUntil)).Property(nameof(WaitUntil.Completed))))
                {
                    isAsync
                    ? operationVariable.Invoke(isGeneric ? "WaitForCompletionAsync" : "WaitForCompletionResponseAsync", [cancellationToken], null, isAsync).Terminate()
                    : operationVariable.Invoke(isGeneric ? "WaitForCompletion" : "WaitForCompletionResponse", cancellationToken).Terminate()
                });
                tryStatement.Add(Return(operationVariable));
            }
            else
            {
                tryStatement.Add(new IfStatement(responseVariable.Property("Value").Equal(Null))
            {
                ((KeywordExpression)ThrowExpression(New.Instance(typeof(RequestFailedException), responseVariable.Invoke("GetRawResponse")))).Terminate()
            });
                tryStatement.Add(Return(Static(typeof(Response)).Invoke(nameof(Response.FromValue), New.Instance(Type, This.Property("Client"), responseVariable.Property("Value")), responseVariable.Invoke("GetRawResponse"))));
            }
            return tryStatement;
        }

        private static CSharpType GetResponseType(MethodProvider convenienceMethod, bool isAsync) => isAsync ? convenienceMethod.Signature.ReturnType?.Arguments[0]! : convenienceMethod.Signature.ReturnType!;

        private ValueExpression[] PopulateArguments(IReadOnlyList<ParameterProvider> parameters, MethodProvider convenienceMethod)
        {
            var arguments = new List<ValueExpression>();
            foreach (var parameter in parameters)
            {
                if (parameter.Name.Equals("subscriptionId", StringComparison.InvariantCultureIgnoreCase))
                {
                    arguments.Add(Static(typeof(Guid)).Invoke(nameof(Guid.Parse), This.Property(nameof(ArmResource.Id)).Property(nameof(ResourceIdentifier.SubscriptionId))));
                }
                else if (parameter.Name.Equals("resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                {
                    arguments.Add(This.Property(nameof(ArmResource.Id)).Property(nameof(ResourceIdentifier.ResourceGroupName)));
                }
                // TODO: handle parents
                else if (parameter.Name.Equals(_contextualParameters.Last(), StringComparison.InvariantCultureIgnoreCase))
                {
                    arguments.Add(This.Property(nameof(ArmResource.Id)).Property(nameof(ResourceIdentifier.Name)));
                }
                else if (parameter.Type.Equals(typeof(RequestContent)))
                {
                    var resource = convenienceMethod.Signature.Parameters.Single(p => p.Type.Equals(_resourceData.Type));
                    arguments.Add(resource);
                }
                else if (parameter.Type.Equals(typeof(RequestContext)))
                {
                    var cancellationToken = convenienceMethod.Signature.Parameters.Single(p => p.Type.Equals(typeof(CancellationToken)));
                    arguments.Add(New.Instance(typeof(RequestContext), new Dictionary<ValueExpression, ValueExpression> { { Identifier(nameof(RequestContext.CancellationToken)), cancellationToken } }));
                }
                else
                {
                    arguments.Add(parameter);
                }
            }
            return arguments.ToArray();
        }

        // TODO: get clean name of operation Name
        private MethodProvider GetCorrespondingConvenienceMethod(InputOperation operation, bool isAsync)
        {
            // TODO: use _clientProvider.CanonicalView instead when it implements BuildMethods
            MethodProvider[] methods = [.. _clientProvider.Methods, .. _clientProvider.CustomCodeView?.Methods ?? []];
            return methods.Single(m => m.Signature.Name.Equals(isAsync ? $"{operation.Name}Async" : operation.Name, StringComparison.OrdinalIgnoreCase) && m.Signature.Parameters.Any(p => p.Type.Equals(typeof(CancellationToken))));
        }

        private MethodProvider GetCorrespondingRequestMethod(InputOperation operation)
            => _clientProvider.RestClient.Methods.Single(m => m.Signature.Name.Equals($"Create{operation.Name}Request", StringComparison.OrdinalIgnoreCase));

        public ScopedApi<bool> TryGetApiVersion(out ScopedApi<string> apiVersion)
        {
            var apiVersionDeclaration = new VariableExpression(typeof(string), $"{_specCleanName.ToLower()}ApiVersion");
            apiVersion = apiVersionDeclaration.As<string>();
            var invocation = new InvokeMethodExpression(This, "TryGetApiVersion", [_resourcetypeField, new DeclarationExpression(apiVersionDeclaration, true)]);
            return invocation.As<bool>();
        }
    }
}
