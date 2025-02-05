// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> method and call
    ///  <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.<see cref="IAdviceFactory.AddContract(Metalama.Framework.Code.IParameter,string,Metalama.Framework.Aspects.ContractDirection,object?,object?)"/>.
    /// </summary>
    /// <seealso href="@contracts"/>
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public class LocationValidationAdvice : GroupingAdvice
    {
        public int Priority { get; set; } = int.MaxValue;
    }
}