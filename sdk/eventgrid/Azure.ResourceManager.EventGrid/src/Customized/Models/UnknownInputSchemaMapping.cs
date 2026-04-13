// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    // Backward compat: old SDK had [PersistableModelProxy(typeof(UnknownInputSchemaMapping))],
    // but new generator creates UnknownEventGridInputSchemaMapping. Rename back to old name.
    [CodeGenType("UnknownEventGridInputSchemaMapping")]
    internal partial class UnknownInputSchemaMapping
    {
    }
}
