// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Aspects.Configuration;
using PostSharp.Constraints;
using PostSharp.Reflection;
using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Use <see cref="Metalama.Framework.Aspects.IAspectInstance"/>.
    /// </summary>
    [InternalImplement]
    public interface IAspectInstance
    {
        /// <summary>
        /// There is no aspect configuration in Metalama.
        /// </summary>
        AspectConfiguration AspectConfiguration { get; }

        /// <summary>
        /// Use <see cref="Metalama.Framework.Aspects.IAspectPredecessor.Predecessors"/>/
        /// </summary>
        ObjectConstruction AspectConstruction { get; }

        IAspect Aspect { get; }

        Type AspectType { get; }
    }
}