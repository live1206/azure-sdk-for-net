// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using MgmtTypeSpec;

namespace MgmtTypeSpec.Models
{
    /// <summary> The intended executor of the operation; as in Resource Based Access Control (RBAC) and audit logs UX. Default value is "user,system". </summary>
    public readonly partial struct Origin : IEquatable<Origin>
    {
        private readonly string _value;
        /// <summary> Indicates the operation is initiated by a user. </summary>
        private const string UserValue = "user";
        /// <summary> Indicates the operation is initiated by a system. </summary>
        private const string SystemValue = "system";
        /// <summary> Indicates the operation is initiated by a user or system. </summary>
        private const string UserSystemValue = "user,system";

        /// <summary> Initializes a new instance of <see cref="Origin"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Origin(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        /// <summary> Indicates the operation is initiated by a user. </summary>
        public static Origin User { get; } = new Origin(UserValue);

        /// <summary> Indicates the operation is initiated by a system. </summary>
        public static Origin System { get; } = new Origin(SystemValue);

        /// <summary> Indicates the operation is initiated by a user or system. </summary>
        public static Origin UserSystem { get; } = new Origin(UserSystemValue);

        /// <summary> Determines if two <see cref="Origin"/> values are the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator ==(Origin left, Origin right) => left.Equals(right);

        /// <summary> Determines if two <see cref="Origin"/> values are not the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator !=(Origin left, Origin right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="Origin"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator Origin(string value) => new Origin(value);

        /// <param name="obj"> The object to compare. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Origin other && Equals(other);

        /// <param name="other"> The instance to compare. </param>
        public bool Equals(Origin other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
