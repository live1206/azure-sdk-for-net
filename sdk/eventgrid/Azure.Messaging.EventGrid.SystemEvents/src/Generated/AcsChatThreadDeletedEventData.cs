// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Schema of the Data property of an EventGridEvent for a Microsoft.Communication.ChatThreadDeleted event. </summary>
    public partial class AcsChatThreadDeletedEventData : AcsChatThreadEventInThreadBaseProperties
    {
        /// <summary> Initializes a new instance of <see cref="AcsChatThreadDeletedEventData"/>. </summary>
        /// <param name="deletedByCommunicationIdentifier"> The communication identifier of the user who deleted the thread. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deletedByCommunicationIdentifier"/> is null. </exception>
        internal AcsChatThreadDeletedEventData(CommunicationIdentifierModel deletedByCommunicationIdentifier)
        {
            Argument.AssertNotNull(deletedByCommunicationIdentifier, nameof(deletedByCommunicationIdentifier));

            DeletedByCommunicationIdentifier = deletedByCommunicationIdentifier;
        }

        /// <summary> Initializes a new instance of <see cref="AcsChatThreadDeletedEventData"/>. </summary>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="createTime"> The original creation time of the thread. </param>
        /// <param name="version"> The version of the thread. </param>
        /// <param name="deletedByCommunicationIdentifier"> The communication identifier of the user who deleted the thread. </param>
        /// <param name="deleteTime"> The deletion time of the thread. </param>
        internal AcsChatThreadDeletedEventData(string transactionId, string threadId, IDictionary<string, BinaryData> serializedAdditionalRawData, DateTimeOffset? createTime, long? version, CommunicationIdentifierModel deletedByCommunicationIdentifier, DateTimeOffset? deleteTime) : base(transactionId, threadId, serializedAdditionalRawData, createTime, version)
        {
            DeletedByCommunicationIdentifier = deletedByCommunicationIdentifier;
            DeleteTime = deleteTime;
        }

        /// <summary> Initializes a new instance of <see cref="AcsChatThreadDeletedEventData"/> for deserialization. </summary>
        internal AcsChatThreadDeletedEventData()
        {
        }

        /// <summary> The communication identifier of the user who deleted the thread. </summary>
        public CommunicationIdentifierModel DeletedByCommunicationIdentifier { get; }
        /// <summary> The deletion time of the thread. </summary>
        public DateTimeOffset? DeleteTime { get; }
    }
}
