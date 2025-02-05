// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no built-in support for cloning in Metalama at the moment.
    /// </summary>
    public interface ICloneAwareAspect : IInstanceScopedAspect
    {
        /// <summary>
        /// There is no built-in support for cloning in Metalama at the moment.
        /// </summary>
        [Obsolete( "", true )]
        void OnCloned( ICloneAwareAspect source );
    }
}