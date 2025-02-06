// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use the <see cref="IMember"/>.<see cref="INamedDeclaration.Name"/> property.
    /// </summary>
    public sealed class DeclarationNameAttribute : AdviceParameterAttribute
    {
        public bool IncludeTypeName { get; set; }
    }
}