// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    internal partial class InternalAzureContentFilterResultForChoiceError
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalAzureContentFilterResultForChoiceError(int code, string message)
        {
            Code = code;
            Message = message;
        }

        internal InternalAzureContentFilterResultForChoiceError(int code, string message, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Code = code;
            Message = message;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> A distinct, machine-readable code associated with the error. </summary>
        public int Code { get; set; }

        /// <summary> A human-readable message associated with the error. </summary>
        public string Message { get; set; }

        /// <summary></summary>
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
