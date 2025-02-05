// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// Aspect roles are not supported in Metalama.
    /// </summary>
    [PublicAPI]
    public sealed class AspectRoleDependencyAttribute : AspectDependencyAttribute
    {
        public AspectRoleDependencyAttribute(
            AspectDependencyAction action,
            AspectDependencyPosition position,
            string role )
            : base( action, position )
        {
            throw new NotImplementedException();
        }

        public AspectRoleDependencyAttribute( AspectDependencyAction action, string role )
            : base( action )
        {
            throw new NotImplementedException();
        }

        public string Role { get; }
    }
}