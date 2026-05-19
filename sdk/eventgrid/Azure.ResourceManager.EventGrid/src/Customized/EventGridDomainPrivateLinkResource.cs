// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    // Rename per-parent Private Link resource/collection classes to match
    // the back-compat names. The new MPG generator prefixes the parent singular ("Domain",
    // "Topic", "PartnerNamespace") to "EventGridPrivateLinkResource*"; main shipped
    // these as "EventGrid<Parent>PrivateLinkResource*" (with PartnerNamespace as the
    // exception lacking the "EventGrid" prefix). Use [CodeGenType] to swap.
    [CodeGenType("DomainEventGridPrivateLinkResource")]
    public partial class EventGridDomainPrivateLinkResource
    {
    }
}
