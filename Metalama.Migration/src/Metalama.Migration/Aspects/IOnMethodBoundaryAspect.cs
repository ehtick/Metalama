// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Use <see cref="OverrideMethodAspect"/> and implement your own <c>try</c>/<c>catch</c>/<c>finally</c> block.
    /// </summary>
    public interface IOnMethodBoundaryAspect : IMethodLevelAspect
    {
        /// <summary>
        /// Implement <see cref="OverrideMethodAspect.OverrideMethod"/> and add this logic before the call to <see cref="meta"/>.<see cref="meta.Proceed"/>.
        /// </summary>
        void OnEntry( MethodExecutionArgs args );

        /// <summary>
        /// Implement <see cref="OverrideMethodAspect.OverrideMethod"/>, call <see cref="meta"/>.<see cref="meta.Proceed"/> in a <c>try</c>/<c>finally</c> block, and add this logic
        /// to the <c>finally</c> block.
        /// </summary>
        void OnExit( MethodExecutionArgs args );

        /// <summary>
        /// Implement <see cref="OverrideMethodAspect.OverrideMethod"/>, call <see cref="meta"/>.<see cref="meta.Proceed"/> in a <c>try</c>/<c>catch</c> block, and add this logic
        /// to the end of the <c>try</c> block.
        /// </summary>
        void OnSuccess( MethodExecutionArgs args );

        /// <summary>
        /// Implement <see cref="OverrideMethodAspect.OverrideMethod"/>, call <see cref="meta"/>.<see cref="meta.Proceed"/> in a <c>try</c>/<c>catch</c> block, and add this logic
        /// to the <c>catch</c> block.
        /// </summary>
        void OnException( MethodExecutionArgs args );
    }
}