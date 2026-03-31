// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    // Backward compat: old SDK had [PersistableModelProxy(typeof(UnknownFilter))],
    // but new generator creates UnknownEventGridFilter. Rename back to old name.
    [CodeGenType("UnknownEventGridFilter")]
    internal partial class UnknownFilter : EventGridFilter
    {
    }
}
