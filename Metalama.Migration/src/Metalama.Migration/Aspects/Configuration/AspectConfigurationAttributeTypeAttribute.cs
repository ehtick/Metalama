// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no equivalent in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class )]
    public sealed class AspectConfigurationAttributeTypeAttribute : Attribute
    {
        public AspectConfigurationAttributeTypeAttribute( Type type )
        {
            this.AttributeType = type;
        }

        public Type AttributeType { get; }
    }
}