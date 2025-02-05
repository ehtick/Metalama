// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using Metalama.Framework.Aspects;
using PostSharp.Reflection;
using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use the <see cref="IntroduceAttribute"/> custom attribute. 
    /// </summary>
    /// <seealso href="@introducing-members"/>
    [AttributeUsage( AttributeTargets.Event | AttributeTargets.Property | AttributeTargets.Method )]
    [PublicAPI]
    public sealed class IntroduceMemberAttribute : Advice
    {
        public Visibility Visibility { get; set; }

        public bool IsVirtual { get; set; }

        public bool IsIsVirtualSpecified { get; }

        public MemberOverrideAction OverrideAction { get; set; }
    }
}