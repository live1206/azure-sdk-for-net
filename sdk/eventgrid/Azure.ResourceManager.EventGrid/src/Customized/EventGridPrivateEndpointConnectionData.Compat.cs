// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EventGrid
{
    // Backward-compat: the generator creates ModelFactory compat methods that reference
    // EventGridPrivateEndpointConnectionData in the root namespace, but the actual generated
    // class is EventGridPrivateEndpointConnection in the Models namespace (no Data suffix).
    // These compat methods don't use this parameter (pass defaults), so an empty shell suffices.
    /// <summary> Backward-compat shell for EventGridPrivateEndpointConnection (renamed from Data suffix). </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EventGridPrivateEndpointConnectionData : ResourceData
    {
        internal EventGridPrivateEndpointConnectionData() { }
    }
}
