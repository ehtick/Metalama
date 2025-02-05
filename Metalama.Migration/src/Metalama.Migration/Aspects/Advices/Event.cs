// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using Metalama.Framework.Code;
using Metalama.Framework.Code.Invokers;
using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In PostSharp, this class allowed the run-time code of the aspect to access an event in the target code. In Metalama,
    /// no run-time helper is required because the template directly generates run-time code.
    /// Use invokers (e.g. <see cref="IEvent"/>.<see cref="IEventInvoker.Add"/>) to generate run-time code for any event.
    /// </summary>
    [PublicAPI]
    public sealed class Event<TDelegate>
    {
        public Event( EventAccessor<TDelegate> addDelegate, EventAccessor<TDelegate> removeDelegate )
        {
            throw new NotImplementedException();
        }

        public EventAccessor<TDelegate> Add { get; }

        public EventAccessor<TDelegate> Remove { get; }
    }
}