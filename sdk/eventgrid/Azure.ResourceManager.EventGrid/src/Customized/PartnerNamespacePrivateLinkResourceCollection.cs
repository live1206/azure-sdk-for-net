// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen dynamic-parent expansion: naming divergence vs legacy AutoRest).
    // Note: PartnerNamespace PLR variant does NOT have the "EventGrid" prefix on main
    // (a historical naming inconsistency in the legacy AutoRest-generated SDK).
    [CodeGenType("PartnerNamespaceEventGridPrivateLinkResourceCollection")]
    public partial class PartnerNamespacePrivateLinkResourceCollection
    {
    }
}
