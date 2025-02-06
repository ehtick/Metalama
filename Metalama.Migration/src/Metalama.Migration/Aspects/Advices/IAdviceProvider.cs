// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using System.Collections.Generic;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> and use the methods of the
    /// <see cref="IAdviceFactory"/> interface exposed on <see cref="IAspectBuilder{TAspectTarget}"/>.<see cref="IAspectBuilder.Advice"/>.
    /// </summary>
    /// <seealso href="@advising-concepts"/>
    public interface IAdviceProvider : IAspect
    {
        IEnumerable<AdviceInstance> ProvideAdvices( object targetElement );
    }
}