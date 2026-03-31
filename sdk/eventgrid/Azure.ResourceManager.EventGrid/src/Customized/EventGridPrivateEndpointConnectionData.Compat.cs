// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EventGrid
{
    // Backward compat: add public parameterless constructor (old API had it public).
    public partial class EventGridPrivateEndpointConnectionData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="EventGridPrivateEndpointConnectionData"/>. </summary>
        public EventGridPrivateEndpointConnectionData() { }
    }
}
