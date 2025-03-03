// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Mgmt.Providers;
using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Mgmt
{
    internal class MgmtOutputLibrary : AzureOutputLibrary
    {
        protected override TypeProvider[] BuildTypeProviders()
        {
            var armOperation = new MgmtLongRunningOperationProvider(false);
            var genericArmOperation = new MgmtLongRunningOperationProvider(true);

            // TODO: remove them once they are referenced in Resource operation implementation
            MgmtClientPlugin.Instance.AddTypeToKeep(armOperation.Name);
            MgmtClientPlugin.Instance.AddTypeToKeep(genericArmOperation.Name);
            return [.. base.BuildTypeProviders(), new RequestContextExtensionsDefinition(), armOperation, genericArmOperation];
        }
    }
}
