// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Code.AsyncInfo"/> at compile time. There is no equivalent at run time.
    /// </summary>
    public enum StateMachineKind
    {
        None,

        Iterator,

        Async,

        AsyncIterator
    }
}