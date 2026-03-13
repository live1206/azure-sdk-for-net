// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    [CodeGenSuppress("StaticRoutingEnrichment")]
    public abstract partial class StaticRoutingEnrichment
    {
        /// <summary> Initializes a new instance of <see cref="StaticRoutingEnrichment"/>. </summary>
        protected StaticRoutingEnrichment() { }
    }
}
