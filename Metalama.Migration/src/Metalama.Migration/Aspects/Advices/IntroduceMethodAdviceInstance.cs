// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using PostSharp.Reflection;
using System;
using System.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, call the <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.<see cref="IAdviceFactory.IntroduceMethod"/> method.
    /// </summary>
    /// <seealso href="@introducing-members"/>
    [PublicAPI]
    public sealed class IntroduceMethodAdviceInstance : IntroduceMemberAdviceInstance
    {
        public IntroduceMethodAdviceInstance( MethodInfo method, Visibility visibility, bool? isVirtual, MemberOverrideAction overrideAction )
        {
            throw new NotImplementedException();
        }

        public override object MasterAspectMember { get; }
    }
}