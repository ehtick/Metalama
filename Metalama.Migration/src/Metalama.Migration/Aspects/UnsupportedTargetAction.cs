// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no equivalent in Metalama because Metalama will throw an exception if the target is not supported.
    /// </summary>
    public enum UnsupportedTargetAction
    {
        Default = 0,

        Fail = Default,

        Ignore,

        Fallback
    }
}