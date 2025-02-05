// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> method and call
    ///  <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.<see cref="IAdviceFactory.ImplementInterface(Metalama.Framework.Code.INamedType,Metalama.Framework.Code.INamedType,Metalama.Framework.Aspects.OverrideStrategy,object?)"/>.
    /// </summary>
    /// <seealso href="@implementing-interfaces"/>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = true )]
    [PublicAPI]
    public sealed class IntroduceInterfaceAttribute : Advice
    {
        public IntroduceInterfaceAttribute( Type interfaceType )
        {
            throw new NotImplementedException();
        }

        public InterfaceOverrideAction OverrideAction { get; set; }

        public InterfaceOverrideAction AncestorOverrideAction { get; set; }
    }
}