// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// In Metalama, the only aspect dependency kind is <see cref="Order"/>.
    /// </summary>
    public enum AspectDependencyAction
    {
        None,

        Order,

        Require,

        Conflict,

        Commute
    }
}