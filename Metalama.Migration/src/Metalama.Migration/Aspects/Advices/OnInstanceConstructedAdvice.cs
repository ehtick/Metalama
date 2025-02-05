// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> method and use <c>builder</c>.<see cref="Advice"/>.<see cref="IAdviceFactory.AddInitializer(Metalama.Framework.Code.INamedType,string,Metalama.Framework.Advising.InitializerKind,object?,object?)"/>.
    /// </summary>
    /// <seealso href="@initializers"/>
    [AttributeUsage( AttributeTargets.Method, Inherited = false )]
    public sealed class OnInstanceConstructedAdvice : Advice { }
}