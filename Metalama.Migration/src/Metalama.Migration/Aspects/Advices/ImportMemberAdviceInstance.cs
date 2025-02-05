// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, members of the target declaration do not need to be imported into the aspect. Instead, the
    /// aspect accesses the target code using dynamic code or invokers.
    /// </summary>
    /// <seealso href="template-dynamic-code"/>
    [PublicAPI]
    public abstract class ImportMemberAdviceInstance : AdviceInstance
    {
        public FieldInfo AspectField { get; }

        public bool IsRequired { get; }

        public abstract object Member { get; }

        public abstract string[] MemberNames { get; }

        public ImportMemberOrder Order { get; }

        public override object MasterAspectMember { get; }
    }
}