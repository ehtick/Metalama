// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects
{
    public interface IEventInterceptionAspect : IEventLevelAspect
    {
        void OnAddHandler( EventInterceptionArgs args );

        void OnRemoveHandler( EventInterceptionArgs args );

        void OnInvokeHandler( EventInterceptionArgs args );
    }
}