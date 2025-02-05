// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// Aspect effects are not supported in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method )]
    [PublicAPI]
    public sealed class WaiveAspectEffectAttribute : Attribute
    {
        public WaiveAspectEffectAttribute() { }

        public WaiveAspectEffectAttribute( params string[] effects )
        {
            throw new NotImplementedException();
        }

        public string[] Effects { get; }
    }
}