// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using Metalama.Framework.Code;
using PostSharp.Reflection;
using System;
using System.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, members of the target declaration do not need to be imported into the aspect. Instead, the
    /// aspect accesses the target code using dynamic code or invokers.
    /// To generate code that accesses a field or property, use <see cref="IFieldOrProperty"/>.<see cref="IExpression.Value"/>.
    /// </summary>
    /// <seealso href="template-dynamic-code"/>
    [PublicAPI]
    public sealed class ImportLocationAdviceInstance : ImportMemberAdviceInstance
    {
        public ImportLocationAdviceInstance( FieldInfo aspectField, LocationInfo location )
        {
            throw new NotImplementedException();
        }

        public ImportLocationAdviceInstance(
            FieldInfo aspectField,
            string propertyName,
            bool isRequired = false,
            ImportMemberOrder order = ImportMemberOrder.Default )
        {
            throw new NotImplementedException();
        }

        public ImportLocationAdviceInstance(
            FieldInfo aspectField,
            string[] propertyNames,
            bool isRequired = false,
            ImportMemberOrder order = ImportMemberOrder.Default )
        {
            throw new NotImplementedException();
        }

        public LocationInfo Location { get; }

        public override object Member { get; }

        public override string[] MemberNames { get; }
    }
}