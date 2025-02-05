// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;
using PostSharp.Extensibility;
using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use extension methods of the code model.
    /// </summary>
    public interface IAspectRepositoryService : IService
    {
        /// <summary>
        /// Use <see cref="IDeclaration"/>.<see cref="DeclarationExtensions.Enhancements{T}"/>.
        /// </summary>
        IAspectInstance[] GetAspectInstances( object declaration );

        /// <summary>
        /// Use <see cref="IDeclaration"/>.<see cref="DeclarationExtensions.Enhancements{T}"/>.<c>Any()</c>.
        /// </summary>
        bool HasAspect( object declaration, Type aspectType );

        /// <summary>
        /// This event is not exposed, but when you register validators, they get executed
        /// after all aspects have been applied.
        /// </summary>
        /// <seealso href="@aspect-validating"/>
        [Obsolete( "", true )]
        event EventHandler AspectDiscoveryCompleted;
    }
}