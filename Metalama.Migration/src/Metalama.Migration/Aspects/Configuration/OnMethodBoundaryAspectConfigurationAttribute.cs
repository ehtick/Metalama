// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no declarative aspect configuration in Metalama.
    /// </summary>
    public sealed class OnMethodBoundaryAspectConfigurationAttribute : AspectConfigurationAttribute

    {
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}