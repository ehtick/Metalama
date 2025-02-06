// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Aspects are purely build-time in Metalama, so all semantics are build semantics.
    /// The equivalent interface is therefore <see cref="Metalama.Framework.Aspects.IAspect"/>.
    /// </summary>
    public interface IAspectBuildSemantics : IValidableAnnotation
    {
        /// <summary>
        /// Not supported in Metalama.
        /// </summary>
        AspectConfiguration GetAspectConfiguration( object targetElement );
    }
}