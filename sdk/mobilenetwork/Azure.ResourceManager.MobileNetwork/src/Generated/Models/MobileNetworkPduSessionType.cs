// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MobileNetwork.Models
{
    /// <summary> PDU session type (IPv4/IPv6). </summary>
    public readonly partial struct MobileNetworkPduSessionType : IEquatable<MobileNetworkPduSessionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MobileNetworkPduSessionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MobileNetworkPduSessionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string IPv4Value = "IPv4";
        private const string IPv6Value = "IPv6";

        /// <summary> IPv4. </summary>
        public static MobileNetworkPduSessionType IPv4 { get; } = new MobileNetworkPduSessionType(IPv4Value);
        /// <summary> IPv6. </summary>
        public static MobileNetworkPduSessionType IPv6 { get; } = new MobileNetworkPduSessionType(IPv6Value);
        /// <summary> Determines if two <see cref="MobileNetworkPduSessionType"/> values are the same. </summary>
        public static bool operator ==(MobileNetworkPduSessionType left, MobileNetworkPduSessionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MobileNetworkPduSessionType"/> values are not the same. </summary>
        public static bool operator !=(MobileNetworkPduSessionType left, MobileNetworkPduSessionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MobileNetworkPduSessionType"/>. </summary>
        public static implicit operator MobileNetworkPduSessionType(string value) => new MobileNetworkPduSessionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MobileNetworkPduSessionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MobileNetworkPduSessionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
