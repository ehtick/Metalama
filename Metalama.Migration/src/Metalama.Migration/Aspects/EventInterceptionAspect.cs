// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="OverrideEventAspect"/>. Overriding aspect invocation is not yet implemented in Metalama. There is currently no workaround.
    /// </summary>
    [MulticastAttributeUsage( MulticastTargets.Event, AllowMultiple = true, PersistMetaData = false, TargetMemberAttributes = MulticastAttributes.NonAbstract )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Event | AttributeTargets.Struct,
        AllowMultiple = true )]
    public abstract class EventInterceptionAspect : EventLevelAspect, IEventInterceptionAspect
    {
        /// <summary>
        /// Use <see cref="OverrideEventAspect.OverrideAdd"/>.
        /// </summary>
        public virtual void OnAddHandler( EventInterceptionArgs args )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Use <see cref="OverrideEventAspect.OverrideRemove"/>.
        /// </summary>
        public virtual void OnRemoveHandler( EventInterceptionArgs args )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Overriding aspect invocation is not yet implemented in Metalama. There is currently no workaround.
        /// </summary>
        [Obsolete( "", true )]
        public virtual void OnInvokeHandler( EventInterceptionArgs args )
        {
            throw new NotImplementedException();
        }

        protected override AspectConfiguration CreateAspectConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}