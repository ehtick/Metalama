// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no equivalent in Metalama.
    /// </summary>
    public interface ILocationInterceptionArgsAction<TPayload>
    {
        void Execute<TValue>( ILocationInterceptionArgs<TValue> args, ref TPayload payload );
    }
}