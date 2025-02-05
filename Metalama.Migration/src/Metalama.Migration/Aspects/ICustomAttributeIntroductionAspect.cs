// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no specific aspect class to add a custom attribute in Metalama, but only the advice factory method
    /// <see cref="IntroduceAttribute"/>. Create an aspect class that calls this advice factory method
    /// from <see cref="IAspect{T}.BuildAspect"/>.
    /// </summary>
    public interface ICustomAttributeIntroductionAspect : IAspect { }
}