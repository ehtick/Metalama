// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using System;
using System.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="OverrideMethodAspect"/>.
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Constructor |
        AttributeTargets.Event | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Interface |
        AttributeTargets.Struct,
        AllowMultiple = true,
        Inherited = false )]
    [MulticastAttributeUsage(
        MulticastTargets.Method | MulticastTargets.StaticConstructor | MulticastTargets.InstanceConstructor,
        AllowMultiple = true,
        TargetMemberAttributes = MulticastAttributes.NonAbstract )]
    public abstract class OnMethodBoundaryAspect : MethodLevelAspect, IOnStateMachineBoundaryAspect
    {
        /// <inheritdoc/>
        public virtual void OnEntry( MethodExecutionArgs args ) { }

        /// <inheritdoc/>
        public virtual void OnExit( MethodExecutionArgs args ) { }

        /// <inheritdoc/>
        public virtual void OnSuccess( MethodExecutionArgs args ) { }

        /// <inheritdoc/>
        public virtual void OnException( MethodExecutionArgs args ) { }

        /// <summary>
        /// In Metalama, implement different methods <see cref="OverrideMethodAspect.OverrideMethod"/>, <see cref="OverrideMethodAspect.OverrideAsyncMethod"/>,
        /// <see cref="OverrideMethodAspect.OverrideEnumerableMethod"/> or <see cref="OverrideMethodAspect.OverrideEnumeratorMethod"/>, and
        /// set the properties <see cref="OverrideMethodAspect.UseAsyncTemplateForAnyAwaitable"/> or <see cref="OverrideMethodAspect.UseEnumerableTemplateForAnyEnumerable"/>.
        /// </summary>
        protected SemanticallyAdvisedMethodKinds SemanticallyAdvisedMethodKinds { get; set; }

        /// <summary>
        /// There is no equivalent in Metalama. Unsupported targets will throw an exception.
        /// </summary>
        public new UnsupportedTargetAction UnsupportedTargetAction
        {
            get => base.UnsupportedTargetAction;
            set => base.UnsupportedTargetAction = value;
        }

        /// <summary>
        /// Not supported in Metalama.
        /// </summary>
        protected sealed override AspectConfiguration CreateAspectConfiguration()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration, MethodBase targetMethod )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [Obsolete( "", true )]
        public virtual void OnResume( MethodExecutionArgs args ) { }

        /// <inheritdoc/>
        [Obsolete( "", true )]
        public virtual void OnYield( MethodExecutionArgs args ) { }
    }
}