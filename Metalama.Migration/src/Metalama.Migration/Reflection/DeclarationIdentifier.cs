// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;
using System.Reflection;

namespace PostSharp.Reflection
{
    // ReSharper disable once StructCanBeMadeReadOnly
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [PublicAPI]
    public struct DeclarationIdentifier : IEquatable<DeclarationIdentifier>
    {
        public DeclarationIdentifier( long value )
        {
            throw new NotImplementedException();
        }

        public const int MaxTypeIndex = 0;

        public const int MaxMemberIndex = 0;

        public static DeclarationIdentifier Null { get; }

        public bool IsNull { get; }

        public int MemberIndex { get; }

        public int TypeIndex { get; }

        public int AssemblyId { get; }

        public DeclarationIdentifier GetDeclaringTypeIdentifier()
        {
            throw new NotImplementedException();
        }

        public static DeclarationIdentifier GetDeclarationIdentifier( MemberInfo declaration )
        {
            throw new NotImplementedException();
        }

        public bool Equals( DeclarationIdentifier other )
        {
            throw new NotImplementedException();
        }

        public override bool Equals( object obj )
        {
            if ( ReferenceEquals( null, obj ) )
            {
                return false;
            }

            return obj is DeclarationIdentifier identifier && this.Equals( identifier );
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==( DeclarationIdentifier left, DeclarationIdentifier right )
        {
            throw new NotImplementedException();
        }

        public static bool operator !=( DeclarationIdentifier left, DeclarationIdentifier right )
        {
            throw new NotImplementedException();
        }
    }
}