// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Validation;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="DeclarationValidationContext"/> or <see cref="ReferenceValidationContext"/>. 
    /// </summary>
    public interface ICodeReference
    {
        object ReferencingDeclaration { get; }

        object ReferencedDeclaration { get; }

        CodeReferenceKind ReferenceKind { get; }
    }
}