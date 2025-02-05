// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// Aspect effects are not supported in Metalama.
    /// </summary>
    [PublicAPI]
    public sealed class AspectEffectDependencyAttribute : AspectDependencyAttribute
    {
        public AspectEffectDependencyAttribute(
            AspectDependencyAction action,
            AspectDependencyPosition position,
            string effect )
            : base( action, position )
        {
            throw new NotImplementedException();
        }

        public AspectEffectDependencyAttribute( AspectDependencyAction action, string effect )
            : base( action )
        {
            throw new NotImplementedException();
        }

        public string Effect { get; }
    }
}