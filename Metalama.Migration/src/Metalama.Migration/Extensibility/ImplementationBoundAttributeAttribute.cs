// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// There is no equivalent in Metalama. This logic is currently hard-coded.
    /// </summary>
    [AttributeUsage( AttributeTargets.Assembly, AllowMultiple = true )]
    [PublicAPI]
    public sealed class ImplementationBoundAttributeAttribute : Attribute
    {
        public ImplementationBoundAttributeAttribute( Type attributeType )
        {
            throw new NotImplementedException();
        }

        public Type AttributeType { get; }
    }
}