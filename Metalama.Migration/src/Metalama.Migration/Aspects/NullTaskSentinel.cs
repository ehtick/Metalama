// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;

namespace PostSharp.Aspects
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [PublicAPI]
    public sealed class NullTaskSentinel
    {
        public static NullTaskSentinel Instance { get; }
    }
}