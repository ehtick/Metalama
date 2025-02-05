// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using Metalama.Framework.Project;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use <see cref="MetalamaExecutionContext"/>.
    /// </summary>
    [PublicAPI]
    public static class PostSharpEnvironment
    {
        /// <summary>
        /// In Metalama, use <see cref="MetalamaExecutionContext.Current"/>.
        /// </summary>
        public static IPostSharpEnvironment Current { get; }

        public static IProject CurrentProject { get; }

        /// <summary>
        /// No equivalent in Metalama/
        /// </summary>
        public static bool IsPostSharpRunning { get; }
    }
}