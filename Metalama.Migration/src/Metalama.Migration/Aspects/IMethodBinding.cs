// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using Metalama.Framework.Code.Invokers;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In PostSharp, a binding was a run-time object that allowed the run-time code of the aspect to call the target code. In Metalama, aspects no longer
    /// have run-time code. Instead, they have templates that are expanded at compile time and generate run-time code. Templates can generate run-time code
    /// that accesses target code using dynamic code or invokers. For methods, use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Method"/>.<see cref="IMethodInvoker.Invoke(object[])"/>.
    /// </summary>
    public interface IMethodBinding
    {
        /// <summary>
        /// In Metalama, use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Method"/>.<see cref="IMethodInvoker.Invoke(object[])"/>.
        /// </summary>
        object Invoke( ref object instance, Arguments arguments );
    }
}