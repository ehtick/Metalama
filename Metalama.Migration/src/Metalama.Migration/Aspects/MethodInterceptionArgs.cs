// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using Metalama.Framework.Code.Invokers;
using System.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In PostSharp, this object exposed the run-time execution context to the advice. However, in Metalama, advice do not execute at run time.
    /// Instead, advice are templates that generate run-time code. This run-time code does not need helper objects to represent the execution context.
    /// </summary>
    public abstract class MethodInterceptionArgs : AdviceArgs
    {
        internal MethodInterceptionArgs() { }

        /// <summary>
        /// Use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Method"/>.
        /// </summary>
        public abstract IMethodBinding Binding { get; }

        /// <summary>
        /// When you call <see cref="meta"/>.<see cref="meta.Proceed"/>, store the return value in a local variable.
        /// </summary>
        public abstract object ReturnValue { get; set; }

        /// <summary>
        /// Use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Method"/>.
        /// </summary>
        public MethodBase Method { get; set; }

        /// <summary>
        /// Use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Parameters"/>.
        /// </summary>
        public Arguments Arguments { get; protected set; }

        /// <summary>
        /// Use <see cref="meta"/>.<see cref="meta.Proceed"/>.
        /// </summary>
        public abstract void Proceed();

        /// <summary>
        /// Use  <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Method"/>.<see cref="IMethodInvoker.Invoke(object[])"/>.
        /// </summary>
        public abstract object Invoke( Arguments arguments );

        /// <summary>
        /// Currently not exposed in the Metalama API.
        /// </summary>
        public abstract bool IsAsync { get; }

        /// <summary>
        /// Use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Method"/>.
        /// </summary>
        public abstract IAsyncMethodBinding AsyncBinding { get; }

        /// <summary>
        /// Use <see cref="meta"/>.<see cref="meta.ProceedAsync"/>.
        /// </summary>
        public abstract MethodInterceptionProceedAwaitable ProceedAsync();

        /// <summary>
        /// Use  <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Method"/>.<see cref="IMethodInvoker.Invoke(object[])"/>.
        /// </summary>
        public abstract MethodBindingInvokeAwaitable InvokeAsync( Arguments arguments );
    }
}