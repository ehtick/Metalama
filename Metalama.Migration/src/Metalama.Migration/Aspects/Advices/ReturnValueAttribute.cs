// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, call <c>meta.Proceed</c> in the template and store the value in a local variable.
    /// </summary>
    public sealed class ReturnValueAttribute : AdviceParameterAttribute { }
}