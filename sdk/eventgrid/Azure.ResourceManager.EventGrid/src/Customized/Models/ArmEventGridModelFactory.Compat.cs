// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

// Backward compat: the old SDK (1.1.0) had a ModelFactory method for EventGridPrivateLinkResourceData.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EventGrid.Models
{
    public static partial class ArmEventGridModelFactory
    {
        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventGridPrivateLinkResourceData EventGridPrivateLinkResourceData(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            string groupId = default,
            string displayName = default,
            IEnumerable<string> requiredMembers = default,
            IEnumerable<string> requiredZoneNames = default)
        {
            return new EventGridPrivateLinkResourceData(
                id, name, resourceType, systemData,
                groupId, displayName,
                requiredMembers?.ToList(),
                requiredZoneNames?.ToList());
        }
        */
    }
}
