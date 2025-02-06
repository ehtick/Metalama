// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> method and use <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.<see cref="IAdviceFactory.OverrideAccessors(Metalama.Framework.Code.IEvent, string?, string?, string?, object?, object?)"/>.
    /// </summary>
    /// <seealso href="@overriding-methods"/>
    public abstract class OnMethodBoundaryAdvice : GroupingAdvice
    {
        /// <summary>
        /// In Metalama, use the different properties of <see cref="MethodTemplateSelector"/>.
        /// </summary>
        public SemanticallyAdvisedMethodKinds SemanticallyAdvisedMethodKinds { get; set; }

        public UnsupportedTargetAction UnsupportedTargetAction { get; set; }
    }
}