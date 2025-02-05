// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using Metalama.Framework.Aspects;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, call one of the <c>Introduce</c> methods of
    ///  <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.
    /// </summary>
    /// <seealso href="@introducing-members"/>
    [PublicAPI]
    public abstract class IntroduceMemberAdviceInstance : AdviceInstance
    {
        public Visibility Visibility { get; }

        public bool? IsVirtual { get; }

        public MemberOverrideAction OverrideAction { get; }
    }
}