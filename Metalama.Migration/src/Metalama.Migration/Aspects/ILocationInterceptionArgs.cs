// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In PostSharp, this interface exposed the run-time execution context to a location interception advice. However, in Metalama, advice do not execute at run time.
    /// Instead, advice are templates that generate run-time code. This run-time code does not need helper objects to represent the execution context.
    /// </summary>
    public interface ILocationInterceptionArgs
    {
        /// <summary>
        /// Use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.FieldOrProperty"/>.
        /// </summary>
        ILocationBinding Binding { get; }

        /// <summary>
        /// Use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Parameters"/>.
        /// </summary>
        Arguments Index { get; }

        /// <summary>
        /// In the get override advice, get <see cref="meta"/>.<see cref="meta.Proceed"/>. Otherwise, use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.FieldOrProperty"/>.<see cref="IExpression.Value"/>.
        /// </summary>
        void ProceedGetValue();

        /// <summary>
        /// In the set override advice, set <see cref="meta"/>.<see cref="meta.Proceed"/>. Otherwise, use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.FieldOrProperty"/>.<see cref="IExpression.Value"/>.
        /// </summary>
        void ProceedSetValue();

        /// <summary>
        /// In the get override advice, call <see cref="meta"/>.<see cref="meta.Proceed"/>. Otherwise, grt <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.FieldOrProperty"/>.<see cref="IExpression.Value"/>.
        /// </summary>
        object GetCurrentValue();

        /// <summary>
        /// In the set override advice, call <see cref="meta"/>.<see cref="meta.Proceed"/>. Otherwise, set <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.FieldOrProperty"/>.<see cref="IExpression.Value"/>.
        /// </summary>
        void SetNewValue( object value );

        /// <summary>
        /// No equivalent in Metalama.
        /// </summary>
        void Execute<TPayload>( ILocationInterceptionArgsAction<TPayload> action, ref TPayload payload );

        /// <summary>
        /// In PostSharp, this property is set when <see cref="ProceedGetValue"/> is called. It is not necessary on Metalama.
        /// </summary>
        object Value { get; set; }

        /// <summary>
        /// Use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.FieldOrProperty"/>.
        /// </summary>
        LocationInfo Location { get; set; }

        /// <summary>
        /// Use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.FieldOrProperty"/>.<see cref="INamedDeclaration.Name"/>.
        /// </summary>
        string LocationName { get; set; }

        /// <summary>
        /// Not implemented in Metalama.
        /// </summary>
        string LocationFullName { get; set; }

        /// <summary>
        /// Use <see cref="meta"/>.<see cref="meta.This"/>.
        /// </summary>
        object Instance { get; }
    }

    /// <summary>
    /// In PostSharp, this interface exposed the run-time execution context to a location interception advice. However, in Metalama, advice do not execute at run time.
    /// Instead, advice are templates that generate run-time code. This run-time code does not need helper objects to represent the execution context.
    /// </summary>
    public interface ILocationInterceptionArgs<T> : ILocationInterceptionArgs
    {
        /// <summary>
        /// Use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.FieldOrProperty"/>.
        /// </summary>
        new ILocationBinding<T> Binding { get; }

        /// <summary>
        /// In PostSharp, this property is set when <see cref="ILocationInterceptionArgs.ProceedGetValue"/> is called. It is not necessary on Metalama.
        /// </summary>
        new T Value { get; set; }

        /// <summary>
        /// In the get override advice, call <see cref="meta"/>.<see cref="meta.Proceed"/>. Otherwise, get <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.FieldOrProperty"/>.<see cref="IExpression.Value"/>.
        /// </summary>
        new T GetCurrentValue();

        /// <summary>
        /// In the set override advice, call <see cref="meta"/>.<see cref="meta.Proceed"/>. Otherwise, set <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.FieldOrProperty"/>.<see cref="IExpression.Value"/>.
        /// </summary>
        void SetNewValue( T value );
    }
}