// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects
{
    [Flags]
    public enum SemanticallyAdvisedMethodKinds
    {
        None = 0,

        Async = 1 << 0,

        ReturnsAwaitable = 1 << 1,

        Iterator = 1 << 2,

        ReturnsEnumerable = 1 << 3,

        AsyncIterator = 1 << 4,

        Default = Async | ReturnsAwaitable | Iterator | AsyncIterator,

        All = Default | ReturnsEnumerable
    }
}