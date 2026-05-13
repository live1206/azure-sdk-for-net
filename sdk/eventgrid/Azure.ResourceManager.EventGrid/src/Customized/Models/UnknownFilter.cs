// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    // Rename the generator-synthesized polymorphic "Unknown" placeholder to match the
    // contract baseline (1.1.0), which internally referenced it as UnknownFilter via the
    // [PersistableModelProxy] attribute on EventGridFilter.
    [CodeGenType("UnknownEventGridFilter")]
    internal partial class UnknownFilter
    {
    }
}
