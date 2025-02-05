// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;
using PostSharp.Constraints;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Project.IProject"/>.
    /// </summary>
    [InternalImplement]
    public interface IProject : IServiceLocator
    {
        /// <summary>
        /// There is no equivalent in Metalama. However, storing state in static fields or properties is equally dangerous than in PostSharp.
        /// </summary>
        [Obsolete( "", true )]
        IStateStore StateStore { get; }

        /// <summary>
        /// In Metalama, use <see cref="Metalama.Framework.Project.IProject.TryGetProperty"/>.
        /// </summary>
        string EvaluateExpression( string expression );

        /// <summary>
        /// In Metalama, an assembly is an <see cref="ICompilation"/>, but it is not exposed on the project.
        /// </summary>
        Assembly TargetAssembly { get; }

        /// <summary>
        /// In Metalama, use <see cref="Metalama.Framework.Project.IProject.ServiceProvider"/>.
        /// </summary>
        new T GetService<T>( bool throwing = true ) where T : class, IService;

        /// <summary>
        /// In Metalama, use <see cref="Metalama.Framework.Project.IProject.Extension{T}"/>.
        /// </summary>
        IEnumerable<ProjectExtensionElement> GetExtensionElements( string name, string ns );
    }
}