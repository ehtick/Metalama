// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using Metalama.Framework.Eligibility;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use <see cref="IAspect{T}"/> and implement <see cref="IEligible{T}.BuildEligibility"/> and/or <see cref="IAspect{T}.BuildAspect"/>.
    /// </summary>
    [RequirePostSharp( null, "ValidateAnnotations" )]
    public interface IValidableAnnotation
    {
        /// <summary>
        /// In Metalama, validation is done in <see cref="IEligible{T}.BuildEligibility"/> and <see cref="IAspect{T}.BuildAspect"/>.
        /// The equivalent of returning <c>false</c> is to call <see cref="IAspectBuilder.SkipAspect"/>.
        /// </summary>
        bool CompileTimeValidate( object target );
    }
}