// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

/*
#nullable disable

// Backward compat: the old 1.1.0 GA API exposed EventGridPrivateLinkResourceData as a ResourceData subclass.
// The new TypeSpec generator produces EventGridPrivateLinkResource (a model class in the Models namespace) instead.
// This custom ResourceData wrapper restores the old public API surface.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EventGrid
{
    /// <summary> A private link resource data wrapper for backward compatibility. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class EventGridPrivateLinkResourceData : ResourceData, IJsonModel<EventGridPrivateLinkResourceData>, IPersistableModel<EventGridPrivateLinkResourceData>
    {
        /// <summary> Initializes a new instance of <see cref="EventGridPrivateLinkResourceData"/>. </summary>
        internal EventGridPrivateLinkResourceData()
        {
            RequiredMembers = new ChangeTrackingList<string>();
            RequiredZoneNames = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="EventGridPrivateLinkResourceData"/>. </summary>
        internal EventGridPrivateLinkResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string groupId, string displayName, IReadOnlyList<string> requiredMembers, IReadOnlyList<string> requiredZoneNames)
            : base(id, name, resourceType, systemData)
        {
            GroupId = groupId;
            DisplayName = displayName;
            RequiredMembers = requiredMembers ?? new ChangeTrackingList<string>();
            RequiredZoneNames = requiredZoneNames ?? new ChangeTrackingList<string>();
        }

        /// <summary> Group ID of the private link resource. </summary>
        [WirePath("properties.groupId")]
        public string GroupId { get; }
        /// <summary> Display name of the private link resource. </summary>
        [WirePath("properties.displayName")]
        public string DisplayName { get; }
        /// <summary> Required members of the private link resource. </summary>
        [WirePath("properties.requiredMembers")]
        public IReadOnlyList<string> RequiredMembers { get; }
        /// <summary> Required zone names of the private link resource. </summary>
        [WirePath("properties.requiredZoneNames")]
        public IReadOnlyList<string> RequiredZoneNames { get; }

        /// <summary> Creates an instance from the model class. </summary>
        internal static EventGridPrivateLinkResourceData FromModel(EventGrid.Models.EventGridPrivateLinkResource model)
        {
            if (model == null) return null;
            return new EventGridPrivateLinkResourceData(
                model.Id,
                model.Name,
                model.Type ?? default,
                null,
                model.GroupId,
                model.DisplayName,
                model.RequiredMembers != null ? new List<string>(model.RequiredMembers) : null,
                model.RequiredZoneNames != null ? new List<string>(model.RequiredZoneNames) : null);
        }

        /// <inheritdoc/>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }

        EventGridPrivateLinkResourceData IJsonModel<EventGridPrivateLinkResourceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotImplementedException();
        void IJsonModel<EventGridPrivateLinkResourceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        EventGridPrivateLinkResourceData IPersistableModel<EventGridPrivateLinkResourceData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotImplementedException();
        string IPersistableModel<EventGridPrivateLinkResourceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<EventGridPrivateLinkResourceData>.Write(ModelReaderWriterOptions options) => throw new NotImplementedException();
    }
}
*/
