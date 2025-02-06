// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="OverrideMethodAspect"/>.
    /// </summary>
    public interface IMethodInterceptionAspect : IMethodLevelAspect
    {
        /// <summary>
        /// In Metalama, implement <see cref="OverrideMethodAspect.OverrideMethod"/>.
        /// </summary>
        void OnInvoke( MethodInterceptionArgs args );
    }
}