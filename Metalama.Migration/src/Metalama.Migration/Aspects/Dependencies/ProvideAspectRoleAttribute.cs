// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// Aspect roles are not supported in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true )]
    [PublicAPI]
    public sealed class ProvideAspectRoleAttribute : AspectDependencyAttribute
    {
        public ProvideAspectRoleAttribute( string role ) : base( AspectDependencyAction.None )
        {
            throw new NotImplementedException();
        }

        public string Role { get; }
    }
}