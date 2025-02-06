// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="Accessibility"/>.
    /// </summary>
    public enum Visibility
    {
        Public,

        Family,

        Assembly,

        FamilyOrAssembly,

        FamilyAndAssembly,

        Private
    }
}