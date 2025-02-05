// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Project;
using System.Reflection;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use <see cref="MetalamaExecutionContext"/>.
    /// </summary>
    public interface IPostSharpEnvironment
    {
        IProject CurrentProject { get; }

        Assembly LoadAssemblyFromFile( string fileName );
    }
}