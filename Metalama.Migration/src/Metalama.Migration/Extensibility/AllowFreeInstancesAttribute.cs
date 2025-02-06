// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Assembly )]
    [PublicAPI]
    public sealed class AllowFreeInstancesAttribute : Attribute
    {
        public AllowFreeInstancesAttribute( string featureName )
        {
            throw new NotImplementedException();
        }

        public AllowFreeInstancesAttribute( string featureName, int count )
        {
            throw new NotImplementedException();
        }

        public string FeatureName { get; }

        public int? FreeInstanceCount { get; }

        public bool ApplyToType { get; set; }
    }
}