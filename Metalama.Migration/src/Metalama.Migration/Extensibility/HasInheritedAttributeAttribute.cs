// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.ReturnValue )]
    [PublicAPI]
    public sealed class HasInheritedAttributeAttribute : Attribute
    {
        public HasInheritedAttributeAttribute() { }

        [Obsolete( "Do not use this custom attribute in user code.", false )]
        public HasInheritedAttributeAttribute( long[] ids ) { }
    }
}