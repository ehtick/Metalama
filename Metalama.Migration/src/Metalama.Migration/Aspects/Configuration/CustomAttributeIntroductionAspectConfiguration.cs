// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Reflection;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no aspect configuration in Metalama.
    /// </summary>
    public sealed class CustomAttributeIntroductionAspectConfiguration : AspectConfiguration
    {
        public ObjectConstruction ObjectConstruction { get; set; }
    }
}