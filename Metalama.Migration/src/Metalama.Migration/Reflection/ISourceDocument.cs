// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;
using System;

namespace PostSharp.Reflection
{
    /// <summary>
    /// This is currently not exposed in Metalama.
    /// </summary>
    [InternalImplement]
    public interface ISourceDocument
    {
        string FileName { get; }

        Guid Language { get; }
    }
}