// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, there is no need for <see cref="FlowBehavior"/> because the template is in full control
    /// of the generated code.
    /// </summary>
    public sealed class FlowBehaviorAttribute : AdviceParameterAttribute { }
}