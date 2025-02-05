// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use <see cref="OverrideStrategy"/>.
    /// </summary>
    public enum CustomAttributeOverrideAction
    {
        Default,

        Fail = Default,

        Ignore,

        Add,

        MergeAddProperty,

        MergeReplaceProperty
    }
}