// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Mgmt.Models;
using Azure.Generator.Mgmt.Providers;
using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Mgmt
{
    /// <summary>
    /// The management-plane output library to generate the Azure mgmt client SDK.
    /// </summary>
    public class MgmtOutputLibrary : AzureOutputLibrary
    {
        // TODO: categorize clients into operationSets, which contains operations sharing the same Path
        private Dictionary<string, OperationSet> _pathToOperationSetMap;
        private Dictionary<string, HashSet<OperationSet>> _resourceDataBySpecNameMap;

        /// <summary>
        /// The management-plane output library to generate the Azure mgmt client SDK.
        /// </summary>
        public MgmtOutputLibrary()
        {
            _pathToOperationSetMap = CategorizeClients();
            _resourceDataBySpecNameMap = EnsureResourceDataMap();
        }

        private Dictionary<string, HashSet<OperationSet>> EnsureResourceDataMap()
        {
            var result = new Dictionary<string, HashSet<OperationSet>>();
            foreach (var operationSet in _pathToOperationSetMap.Values)
            {
                if (MgmtClientPlugin.Instance.ResourceDetection.TryGetResourceDataSchema(operationSet, out var resourceSpecName, out var resourceSchema))
                {
                    // if this operation set corresponds to a SDK resource, we add it to the map
                    if (!result.TryGetValue(resourceSpecName!, out HashSet<OperationSet>? value))
                    {
                        value = new HashSet<OperationSet>();
                        result.Add(resourceSpecName!, value);
                    }
                    value.Add(operationSet);
                }
            }

            return result;
        }

        private Dictionary<string, OperationSet> CategorizeClients()
        {
            var result = new Dictionary<string, OperationSet>();
            foreach (var inputClient in MgmtClientPlugin.Instance.InputLibrary.InputNamespace.Clients)
            {
                var requestPathList = new HashSet<string>();
                foreach (var operation in inputClient.Operations)
                {
                    var path = operation.GetHttpPath();
                    requestPathList.Add(path);
                    if (result.TryGetValue(path, out var operationSet))
                    {
                        operationSet.Add(operation);
                    }
                    else
                    {
                        operationSet = new OperationSet(path, inputClient)
                        {
                            operation
                        };
                        result.Add(path, operationSet);
                    }
                }
            }

            // TODO: add operation set for the partial resources here

            return result;
        }

        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            var armOperation = new MgmtLongRunningOperationProvider(false);
            var genericArmOperation = new MgmtLongRunningOperationProvider(true);

            // TODO: remove them once they are referenced in Resource operation implementation
            MgmtClientPlugin.Instance.AddTypeToKeep(armOperation.Name);
            MgmtClientPlugin.Instance.AddTypeToKeep(genericArmOperation.Name);
            return [.. base.BuildTypeProviders(), new RequestContextExtensionsDefinition(), armOperation, genericArmOperation];
        }

        internal bool IsResource(string name) => _resourceDataBySpecNameMap.ContainsKey(name);
    }
}
