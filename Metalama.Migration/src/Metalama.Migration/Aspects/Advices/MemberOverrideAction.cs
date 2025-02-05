// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, equivalent to <see cref="OverrideStrategy"/>.
    /// </summary>
    public enum MemberOverrideAction
    {
        Default,

        Fail = Default,

        Ignore = 1,

        OverrideOrFail,

        OverrideOrIgnore
    }
}