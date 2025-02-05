// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Serialization;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, make the type implement the <see cref="ICompileTimeSerializable"/> interface.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Assembly )]
    [MulticastAttributeUsage( MulticastTargets.Class | MulticastTargets.Struct )]
    [RequirePostSharp( null, "PortableSerializer" )]
    [LinesOfCodeAvoided( 0 )]
    public sealed class PSerializableAttribute : MulticastAttribute, IAspect { }
}