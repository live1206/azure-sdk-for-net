﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Mgmt.Models;
using Azure.Generator.Providers;
using Azure.Generator.Utilities;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Providers;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureOutputLibrary : ScmOutputLibrary
    {
        private Dictionary<string, OperationSet> _pathToOperationSetMap;
        private Dictionary<string, HashSet<OperationSet>> _specNameToOperationSetsMap;
        private Dictionary<string, InputModelType> _inputTypeMap;

        /// <inheritdoc/>
        public AzureOutputLibrary()
        {
            _pathToOperationSetMap = CategorizeClients();
            _specNameToOperationSetsMap = EnsureOperationsetMap();
            _inputTypeMap = AzureClientPlugin.Instance.InputLibrary.InputNamespace.Models.OfType<InputModelType>().ToDictionary(model => model.Name);
        }

        private IReadOnlyList<ResourceProvider> BuildResources()
        {
            var result = new List<ResourceProvider>();
            foreach ((var schemaName, var operationSets) in _specNameToOperationSetsMap)
            {
                var model = _inputTypeMap[schemaName];
                var resourceData = (ResourceDataProvider)AzureClientPlugin.Instance.TypeFactory.CreateModel(model)!;
                foreach (var operationSet in operationSets)
                {
                    var requestPath = operationSet.RequestPath;
                    var resourceType = ResourceDetection.GetResourceTypeFromPath(requestPath);
                }
            }
            foreach (var model in AzureClientPlugin.Instance.InputLibrary.InputNamespace.Models)
            {
                if (IsResource(model.Name))
                {
                    // we are sure that the model is a resource, so we can cast it to ResourceDataProvider
                    var resourceDataProvider = (ResourceDataProvider)AzureClientPlugin.Instance.TypeFactory.CreateModel(model)!;

                    var operationSet = _specNameToOperationSetsMap[model.Name].First();
                    var resourceType = ResourceDetection.GetResourceTypeFromPath(operationSet.RequestPath);
                    var resource = new ResourceProvider(operationSet, model.Name, resourceDataProvider, resourceType);
                    AzureClientPlugin.Instance.AddTypeToKeep(resource.Name);
                    result.Add(resource);
                }
            }
            return result;
        }

        private Dictionary<string, HashSet<OperationSet>> EnsureOperationsetMap()
        {
            var result = new Dictionary<string, HashSet<OperationSet>>();
            foreach (var operationSet in _pathToOperationSetMap.Values)
            {
                if (AzureClientPlugin.Instance.ResourceDetection.TryGetResourceDataSchema(operationSet, out var resourceSpecName, out var resourceSchema))
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
            foreach (var inputClient in AzureClientPlugin.Instance.InputLibrary.InputNamespace.Clients)
            {
                foreach (var operation in inputClient.Operations)
                {
                    var path = operation.GetHttpPath();
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
        // TODO: generate resources and collections
        protected override TypeProvider[] BuildTypeProviders() => [.. base.BuildTypeProviders(), new RequestContextExtensionsDefinition(), .. BuildResources()];

        internal bool IsResource(string name) => _specNameToOperationSetsMap.ContainsKey(name);
    }
}
