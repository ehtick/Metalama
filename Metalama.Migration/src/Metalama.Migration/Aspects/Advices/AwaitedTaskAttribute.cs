// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// There is no equivalent in Metalama, and there is currently no way to implement this feature differently.
    /// </summary>
    [Obsolete( "", true )]
    public sealed class AwaitedTaskAttribute : AdviceParameterAttribute { }
}