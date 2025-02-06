// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Project.ProjectExtension"/>. However, all project extensions are programmatic.
    /// Metalama does not support XML configuration.
    /// </summary>
    [PublicAPI]
    public sealed class ProjectExtensionElement
    {
        public string Name { get; }

        public string Namespace { get; }

        public object XElement { get; }
    }
}