// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MobileNetwork.Models
{
    /// <summary> State of the UE. </summary>
    public readonly partial struct UEState : IEquatable<UEState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="UEState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public UEState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ConnectedValue = "Connected";
        private const string IdleValue = "Idle";
        private const string DetachedValue = "Detached";
        private const string DeregisteredValue = "Deregistered";
        private const string UnknownValue = "Unknown";

        /// <summary> Connected. </summary>
        public static UEState Connected { get; } = new UEState(ConnectedValue);
        /// <summary> Idle. </summary>
        public static UEState Idle { get; } = new UEState(IdleValue);
        /// <summary> Detached. </summary>
        public static UEState Detached { get; } = new UEState(DetachedValue);
        /// <summary> Deregistered. </summary>
        public static UEState Deregistered { get; } = new UEState(DeregisteredValue);
        /// <summary> Unknown. </summary>
        public static UEState Unknown { get; } = new UEState(UnknownValue);
        /// <summary> Determines if two <see cref="UEState"/> values are the same. </summary>
        public static bool operator ==(UEState left, UEState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="UEState"/> values are not the same. </summary>
        public static bool operator !=(UEState left, UEState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="UEState"/>. </summary>
        public static implicit operator UEState(string value) => new UEState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is UEState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(UEState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
