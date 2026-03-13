// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    [CodeGenSuppress("DeliveryAttributeMapping")]
    public abstract partial class DeliveryAttributeMapping
    {
        /// <summary> Initializes a new instance of <see cref="DeliveryAttributeMapping"/>. </summary>
        protected DeliveryAttributeMapping() { }
    }
}
