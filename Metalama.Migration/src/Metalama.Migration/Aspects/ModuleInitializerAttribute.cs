// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using PostSharp.Extensibility;
using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Not supported in Metalama, but it is now supported by C# itself.
    /// </summary>
    [AttributeUsage( AttributeTargets.Method )]
    [RequirePostSharp( null, "ModuleInitializer" )]
    [PublicAPI]
    public sealed class ModuleInitializerAttribute : Attribute
    {
        public ModuleInitializerAttribute( int order )
        {
            throw new NotImplementedException();
        }

        public int Order { get; }
    }
}