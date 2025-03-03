// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.IO;
using System.Threading;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    /// <summary>
    /// Defines the extension methods for <see cref="RequestContext"/>.
    /// </summary>
    public class RequestContextExtensionsDefinition : TypeProvider
    {
        /// <inheritdoc/>
        protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;

        /// <inheritdoc/>
        protected override string BuildName() => "RequestContextExtensions";

        /// <inheritdoc/>
        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Internal", $"{Name}.cs");

        /// <inheritdoc/>
        protected override MethodProvider[] BuildMethods() => [BuildParse()];

        private MethodProvider BuildParse()
        {
            var requestContextParameter = new ParameterProvider("requestContext", $"", typeof(RequestContext));
            var signature = new MethodSignature(
                "Parse",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                new CSharpType(typeof((CancellationToken, ErrorOptions))),
                null,
                [requestContextParameter]);

            var method = new MethodProvider(signature, new MethodBodyStatement[]
            {
                new IfStatement(requestContextParameter.Equal(Null))
                {
                    Return(new TupleExpression(Static<CancellationToken>().Property(nameof(CancellationToken.None)), Static<ErrorOptions>().Property(nameof(ErrorOptions.Default))))
                },
                Return(new TupleExpression(requestContextParameter.Property(nameof(RequestContext.CancellationToken)), requestContextParameter.Property(nameof(RequestContext.ErrorOptions))))
            }, this);
            return method;
        }
    }
}
