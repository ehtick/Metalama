// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Use <see cref="OverrideMethodAspect"/>.
    /// </summary>
    [MulticastAttributeUsage(
        MulticastTargets.Method | MulticastTargets.InstanceConstructor,
        AllowMultiple = true,
        PersistMetaData = false,
        TargetMemberAttributes = MulticastAttributes.NonAbstract )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method |
        AttributeTargets.Property |
        AttributeTargets.Event | AttributeTargets.Struct,
        AllowMultiple = true )]
    public abstract class MethodInterceptionAspect : MethodLevelAspect, IAsyncMethodInterceptionAspect

    {
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

        /// <inheritdoc/>
        public virtual void OnInvoke( MethodInterceptionArgs args )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public virtual Task OnInvokeAsync( MethodInterceptionArgs args )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not supported in Metalama.
        /// </summary>
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration, MethodBase targetMethod )
        {
            throw new NotImplementedException();
        }
    }
}