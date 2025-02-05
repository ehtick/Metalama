// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// There is no equivalent in Metalama. You need to generate, in the template, code that assigns a local variable to a value that
    /// is unique within the process.
    /// </summary>
    public sealed class AsyncCallIdAttribute : AdviceParameterAttribute { }
}