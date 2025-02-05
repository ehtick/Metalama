// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no equivalent in Metalama because <see cref="OnMethodBoundaryAspect"/> is implemented
    /// with <see cref="OverrideMethodAspect"/> as a method template, therefore you have full control
    /// on the control flow.
    /// </summary>
    public enum FlowBehavior
    {
        Default = 0,

        Continue = 1,

        RethrowException = 2,

        Return = 3,

        ThrowException = 4,

        Yield = 5
    }
}