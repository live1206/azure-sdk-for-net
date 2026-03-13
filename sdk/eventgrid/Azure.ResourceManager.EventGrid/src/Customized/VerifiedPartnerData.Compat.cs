// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.EventGrid.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    /// <summary> Backward-compat: public constructor and property setters for VerifiedPartnerData. </summary>
    [CodeGenSuppress("VerifiedPartnerData")]
    [CodeGenSuppress("PartnerRegistrationImmutableId")]
    [CodeGenSuppress("OrganizationName")]
    [CodeGenSuppress("PartnerDisplayName")]
    [CodeGenSuppress("PartnerTopicDetails")]
    [CodeGenSuppress("ProvisioningState")]
    public partial class VerifiedPartnerData
    {
        /// <summary> Initializes a new instance of <see cref="VerifiedPartnerData"/>. </summary>
        public VerifiedPartnerData() : this(default, default, default, default, default, new VerifiedPartnerProperties()) { }

        /// <summary> ImmutableId of the corresponding partner registration. </summary>
        [WirePath("properties.partnerRegistrationImmutableId")]
        public Guid? PartnerRegistrationImmutableId { get => Properties?.PartnerRegistrationImmutableId; set { if (Properties != null) Properties.PartnerRegistrationImmutableId = value; } }

        /// <summary> Official name of the Partner. </summary>
        [WirePath("properties.organizationName")]
        public string OrganizationName { get => Properties?.OrganizationName; set { if (Properties != null) Properties.OrganizationName = value; } }

        /// <summary> Display name of the verified partner. </summary>
        [WirePath("properties.partnerDisplayName")]
        public string PartnerDisplayName { get => Properties?.PartnerDisplayName; set { if (Properties != null) Properties.PartnerDisplayName = value; } }

        /// <summary> Details of the partner topic scenario. </summary>
        [WirePath("properties.partnerTopicDetails")]
        public PartnerDetails PartnerTopicDetails { get => Properties?.PartnerTopicDetails; set { if (Properties != null) Properties.PartnerTopicDetails = value; } }

        /// <summary> Provisioning state of the verified partner. </summary>
        [WirePath("properties.provisioningState")]
        public VerifiedPartnerProvisioningState? ProvisioningState { get => Properties?.ProvisioningState; set { if (Properties != null) Properties.ProvisioningState = value; } }
    }
}
