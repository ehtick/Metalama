// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no equivalent to this type in Metalama. The equivalent concept can be built manually.
    /// </summary>
    [PublicAPI]
    public struct AsyncCallId : IEquatable<AsyncCallId>
    {
        public bool IsNull { get; }

        public static AsyncCallId Null => default;

        public bool Equals( AsyncCallId other )
        {
            throw new NotImplementedException();
        }

        public override bool Equals( object obj )
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==( AsyncCallId left, AsyncCallId right )
        {
            throw new NotImplementedException();
        }

        public static bool operator !=( AsyncCallId left, AsyncCallId right )
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}