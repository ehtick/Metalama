// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Reflection;
using System;
using System.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no specific aspect class to add a custom attribute in Metalama, but only the advice factory method
    /// <see cref="IAdviceFactory.IntroduceAttribute"/>. Create an aspect class that calls this advice factory method
    /// from <see cref="IAspect{T}.BuildAspect"/>.
    /// </summary>
    [LinesOfCodeAvoided( 1 )]
    [PublicAPI]
    public sealed class CustomAttributeIntroductionAspect : ICustomAttributeIntroductionAspect, IAspectBuildSemantics
    {
        public CustomAttributeIntroductionAspect( ObjectConstruction attribute )
        {
            throw new NotImplementedException();
        }

        public CustomAttributeIntroductionAspect( CustomAttributeData customAttributeData )
        {
            throw new NotImplementedException();
        }

        public ObjectConstruction CustomAttribute { get; }

        /// <inheritdoc/>
        bool IValidableAnnotation.CompileTimeValidate( object target )
        {
            throw new NotImplementedException();
        }

        AspectConfiguration IAspectBuildSemantics.GetAspectConfiguration( object targetElement )
        {
            throw new NotImplementedException();
        }
    }
}