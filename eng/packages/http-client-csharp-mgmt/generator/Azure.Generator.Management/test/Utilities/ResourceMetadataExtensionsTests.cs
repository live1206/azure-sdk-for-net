// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Tests.Utilities
{
    internal class ResourceMetadataExtensionsTests
    {
        /// <summary>
        /// Reproduces issue #56703: When multiple interfaces operate on the same resource type
        /// at different scopes (e.g., RG-scoped and subscription-scoped Read operations),
        /// the generator produces duplicate methods on the resource class.
        ///
        /// This test demonstrates the bug by creating a resource with Read/Update/Delete
        /// operations at two different scopes and verifying that operations at the non-primary
        /// scope are correctly routed to extensions (not duplicated on the resource).
        /// </summary>
        [Test]
        public void CategorizeMethods_MultiScopeReadOperations_ShouldNotDuplicate()
        {
            // Arrange: ConfigurationAssignment-like pattern
            // RG-scoped resource ID pattern (primary scope)
            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}";
            var parentResourceId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";

            // Read at the primary (RG) scope — should go to resource + collection
            var rgReadMethod = CreateResourceMethod(
                ResourceOperationKind.Read,
                resourceIdPattern,
                resourceIdPattern);

            // Read at subscription scope — currently ALSO goes to resource (BUG: should go to extension)
            var subReadMethod = CreateResourceMethod(
                ResourceOperationKind.Read,
                "/subscriptions/{subscriptionId}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}",
                resourceIdPattern);

            // Update at primary scope — should go to resource
            var rgUpdateMethod = CreateResourceMethod(
                ResourceOperationKind.Update,
                resourceIdPattern,
                resourceIdPattern);

            // Update at subscription scope — currently ALSO goes to resource (BUG: should go to extension)
            var subUpdateMethod = CreateResourceMethod(
                ResourceOperationKind.Update,
                "/subscriptions/{subscriptionId}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}",
                resourceIdPattern);

            // Delete at primary scope — should go to resource
            var rgDeleteMethod = CreateResourceMethod(
                ResourceOperationKind.Delete,
                resourceIdPattern,
                resourceIdPattern);

            // Delete at subscription scope — currently ALSO goes to resource (BUG: should go to extension)
            var subDeleteMethod = CreateResourceMethod(
                ResourceOperationKind.Delete,
                "/subscriptions/{subscriptionId}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}",
                resourceIdPattern);

            var metadata = CreateResourceMetadata(
                resourceIdPattern,
                parentResourceId,
                [rgReadMethod, subReadMethod, rgUpdateMethod, subUpdateMethod, rgDeleteMethod, subDeleteMethod]);

            // Act
            var result = metadata.CategorizeMethods();

            // Assert: The expected behavior after the fix
            // Resource should have only the primary scope operations (3 methods)
            // Extension should have the different-scope operations (3 methods)
            var resourceReadCount = result.MethodsInResource.Count(m => m.Kind == ResourceOperationKind.Read);
            var resourceUpdateCount = result.MethodsInResource.Count(m => m.Kind == ResourceOperationKind.Update);
            var resourceDeleteCount = result.MethodsInResource.Count(m => m.Kind == ResourceOperationKind.Delete);

            // Print actual distribution for diagnosis
            TestContext.Out.WriteLine($"Methods in Resource: {result.MethodsInResource.Count}");
            TestContext.Out.WriteLine($"  Read: {resourceReadCount}, Update: {resourceUpdateCount}, Delete: {resourceDeleteCount}");
            TestContext.Out.WriteLine($"Methods in Collection: {result.MethodsInCollection.Count}");
            TestContext.Out.WriteLine($"Methods in Extension: {result.MethodsInExtension.Count}");

            // These assertions demonstrate the BUG on main:
            // Without the fix, ALL Read/Update/Delete go to resource regardless of scope
            // With the fix, only primary-scope operations go to resource

            // EXPECTED (after fix): Resource has 3 (one Read, one Update, one Delete at primary scope)
            // ACTUAL (bug): Resource has 6 (two Read, two Update, two Delete — both scopes)
            Assert.AreEqual(1, resourceReadCount,
                $"Resource should have exactly 1 Read method (primary scope only), but has {resourceReadCount}");
            Assert.AreEqual(1, resourceUpdateCount,
                $"Resource should have exactly 1 Update method (primary scope only), but has {resourceUpdateCount}");
            Assert.AreEqual(1, resourceDeleteCount,
                $"Resource should have exactly 1 Delete method (primary scope only), but has {resourceDeleteCount}");

            // Extension should have the different-scope operations
            Assert.AreEqual(3, result.MethodsInExtension.Count,
                $"Extension should have 3 methods (different-scope Read, Update, Delete), but has {result.MethodsInExtension.Count}");
        }

        private static ResourceMethod CreateResourceMethod(
            ResourceOperationKind kind,
            string operationPath,
            string? resourceScope)
        {
            return new ResourceMethod(
                kind,
                InputMethod: null!,
                operationPath,
                ResourceScope.ResourceGroup,
                resourceScope,
                InputClient: null!);
        }

        private static ResourceMetadata CreateResourceMetadata(
            string resourceIdPattern,
            string? parentResourceId,
            IReadOnlyList<ResourceMethod> methods)
        {
            return new ResourceMetadata(
                resourceIdPattern,
                "ConfigurationAssignment",
                "Microsoft.Maintenance/configurationAssignments",
                null!,
                ResourceScope.ResourceGroup,
                methods,
                null,
                parentResourceId,
                []);
        }
    }
}
