
// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// There is no equivalent to this advice in Metalama and it is currently not possible to build the equivalent feature.
    /// </summary>
    [Obsolete( "", true )]
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public sealed class OnMethodResumeAdvice : OnMethodBoundaryAdvice { }
}