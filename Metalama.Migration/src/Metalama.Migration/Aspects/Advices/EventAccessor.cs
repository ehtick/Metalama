// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;

namespace PostSharp.Aspects.Advices
{
    // ReSharper disable once TypeParameterCanBeVariant
    /// <summary>
    /// In PostSharp, this delegate allowed the run-time code of the aspect to access an event in the target code. In Metalama,
    /// no run-time helper is required because the template directly generates run-time code.
    /// Use invokers (e.g. <see cref="IEvent"/>.<see cref="IEvent.Add"/>) to generate run-time code for any event. 
    /// </summary>
    public delegate void EventAccessor<TDelegate>( TDelegate @delegate );
}