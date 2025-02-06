// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Reflection
{
    /// <summary>
    /// There is no equivalent in Metalama.
    /// </summary>
    [Flags]
    public enum ReflectionSearchOptions
    {
        None = 0,

        IncludeDerivedTypes = 1,

        IncludeTypeElement = 2
    }
}