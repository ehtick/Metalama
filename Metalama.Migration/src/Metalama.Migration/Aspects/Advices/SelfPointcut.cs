
// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use a <c>foreach</c> loop in the <see cref="Metalama.Framework.Aspects.IAspect{T}.BuildAspect"/> method,use advice using methods of <c>builder</c>.<see cref="IAspectBuilder.Advice"/>
    /// and pass <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Target"/> as the target declaration.
    /// </summary>
    public sealed class SelfPointcut : Pointcut { }
}