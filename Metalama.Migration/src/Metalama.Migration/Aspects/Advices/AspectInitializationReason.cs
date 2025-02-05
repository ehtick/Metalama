// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// There is no equivalent to this advice in Metalama because there is no concept of run-time aspect initialization.
    /// </summary>
    public enum AspectInitializationReason
    {
        None,

        Manual,

        Constructor,

        Clone,

        Deserialize
    }
}