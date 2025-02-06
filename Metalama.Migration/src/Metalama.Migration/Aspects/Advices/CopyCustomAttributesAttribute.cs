// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, all custom attributes except Metalama ones are copied from the template to the introduced declaration.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Event | AttributeTargets.Property | AttributeTargets.Method )]
    [PublicAPI]
    public sealed class CopyCustomAttributesAttribute : Advice
    {
        public CopyCustomAttributesAttribute( Type type )
        {
            throw new NotImplementedException();
        }

        public CopyCustomAttributesAttribute( params Type[] types )
        {
            throw new NotImplementedException();
        }

        public CustomAttributeOverrideAction OverrideAction { get; set; }

        public Type[] Types { get; }
    }
}