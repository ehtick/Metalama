// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;
using System.ComponentModel;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="DescriptionAttribute"/>.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class )]
    [PublicAPI]
    public sealed class AspectDescriptionAttribute : Attribute
    {
        public AspectDescriptionAttribute( string description )
        {
            throw new NotImplementedException();
        }

        public string Description { get; }
    }
}