// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Assembly )]
    [PublicAPI]
    public sealed class AssemblyIdAttribute : Attribute
    {
        public AssemblyIdAttribute( int id )
        {
            throw new NotImplementedException();
        }

        public int AssemblyId { get; }
    }
}