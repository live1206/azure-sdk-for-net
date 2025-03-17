// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Projects
{
    /// <summary> A citation within the message that points to a specific URL associated with the message. Generated when the agent uses tools such as 'bing_grounding' to search the Internet. </summary>
    public partial class MessageDeltaTextUrlCitationAnnotation : MessageDeltaTextAnnotation
    {
        /// <summary> Initializes a new instance of <see cref="MessageDeltaTextUrlCitationAnnotation"/>. </summary>
        /// <param name="index"> The index of the annotation within a text content part. </param>
        /// <param name="urlCitation"> The details of the URL citation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="urlCitation"/> is null. </exception>
        internal MessageDeltaTextUrlCitationAnnotation(int index, MessageDeltaTextUrlCitationDetails urlCitation) : base(index)
        {
            Argument.AssertNotNull(urlCitation, nameof(urlCitation));

            Type = "url_citation";
            UrlCitation = urlCitation;
        }

        /// <summary> Initializes a new instance of <see cref="MessageDeltaTextUrlCitationAnnotation"/>. </summary>
        /// <param name="index"> The index of the annotation within a text content part. </param>
        /// <param name="type"> The type of the text content annotation. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="urlCitation"> The details of the URL citation. </param>
        /// <param name="startIndex"> The first text index associated with this text annotation. </param>
        /// <param name="endIndex"> The last text index associated with this text annotation. </param>
        internal MessageDeltaTextUrlCitationAnnotation(int index, string type, IDictionary<string, BinaryData> serializedAdditionalRawData, MessageDeltaTextUrlCitationDetails urlCitation, int? startIndex, int? endIndex) : base(index, type, serializedAdditionalRawData)
        {
            UrlCitation = urlCitation;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        /// <summary> Initializes a new instance of <see cref="MessageDeltaTextUrlCitationAnnotation"/> for deserialization. </summary>
        internal MessageDeltaTextUrlCitationAnnotation()
        {
        }

        /// <summary> The details of the URL citation. </summary>
        public MessageDeltaTextUrlCitationDetails UrlCitation { get; }
        /// <summary> The first text index associated with this text annotation. </summary>
        public int? StartIndex { get; }
        /// <summary> The last text index associated with this text annotation. </summary>
        public int? EndIndex { get; }
    }
}
