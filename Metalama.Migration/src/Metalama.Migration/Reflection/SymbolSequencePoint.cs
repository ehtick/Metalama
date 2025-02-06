// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Reflection
{
    /// <summary>
    /// Not exposed in Metalama.
    /// </summary>
    [PublicAPI]
    public class SymbolSequencePoint :
        IComparable<SymbolSequencePoint>, IEquatable<SymbolSequencePoint>
    {
        public static readonly SymbolSequencePoint Hidden;

        public bool IsHidden { get; }

        public bool IsSpecial { get; }

        public int StartLine { get; }

        public int EndLine { get; }

        public int StartColumn { get; }

        public int EndColumn { get; }

        internal int Offset { get; }

        public ISourceDocument SourceDocument { get; }

        public int CompareTo( SymbolSequencePoint other )
        {
            throw new NotImplementedException();
        }

        #region IEquatable<SymbolSequencePoint> Members

        public bool Equals( SymbolSequencePoint other )
        {
            throw new NotImplementedException();
        }

        public override bool Equals( object obj )
        {
            throw new NotImplementedException();
        }

        public static bool operator ==( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            throw new NotImplementedException();
        }

        public static bool operator !=( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            throw new NotImplementedException();
        }

        public static bool operator <( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            throw new NotImplementedException();
        }

        public static bool operator <=( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            throw new NotImplementedException();
        }

        public static bool operator >( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            throw new NotImplementedException();
        }

        public static bool operator >=( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}