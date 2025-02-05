// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using Metalama.Framework.Aspects;
using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use <see cref="RequireAspectWeaverAttribute"/>.
    /// </summary>
    [AttributeUsage( AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Assembly, AllowMultiple = true )]
    [PublicAPI]
    public sealed class RequirePostSharpAttribute : Attribute
    {
        public RequirePostSharpAttribute( string plugIn, string task )
        {
            throw new NotImplementedException();
        }

        public RequirePostSharpAttribute( string plugIn )
        {
            throw new NotImplementedException();
        }

        public RequirePostSharpAttribute( Type serviceType )
        {
            this.ServiceType = serviceType;
        }

        public string PlugIn { get; }

        public string Task { get; }

        public Type ServiceType { get; }

        public bool AssemblyReferenceOnly { get; set; }

        public bool AnyTypeReference { get; set; }
    }
}