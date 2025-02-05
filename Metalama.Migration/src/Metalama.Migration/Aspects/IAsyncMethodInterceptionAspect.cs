// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using System.Threading.Tasks;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="OverrideMethodAspect"/>.
    /// </summary>
    public interface IAsyncMethodInterceptionAspect : IMethodInterceptionAspect
    {
        /// <summary>
        /// In Metalama, implement <see cref="OverrideMethodAspect.OverrideAsyncMethod"/>.
        /// </summary>
        Task OnInvokeAsync( MethodInterceptionArgs args );
    }
}