// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen dynamic-parent expansion: the new MPG generator does not emit
    // child-collection getters on EventGridDomainResource for the NSP per-parent
    // collection because the dynamic-parent expansion chain is incomplete. Provide
    // the back-compat surface here.)
    public partial class EventGridDomainResource
    {
        /// <summary> Gets a collection of <see cref="DomainNetworkSecurityPerimeterConfigurationResource"/> in the <see cref="EventGridDomainResource"/>. </summary>
        /// <returns> An object representing collection of <see cref="DomainNetworkSecurityPerimeterConfigurationResource"/> and their operations over a <see cref="DomainNetworkSecurityPerimeterConfigurationResource"/>. </returns>
        public virtual DomainNetworkSecurityPerimeterConfigurationCollection GetDomainNetworkSecurityPerimeterConfigurations()
        {
            return GetCachedClient(client => new DomainNetworkSecurityPerimeterConfigurationCollection(client, Id));
        }
    }
}
