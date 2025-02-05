// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no declarative aspect configuration in Metalama.
    /// </summary>
    public sealed class OnExceptionAspectConfigurationAttribute : AspectConfigurationAttribute
    {
        public Type ExceptionType { get; set; }

        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new OnExceptionAspectConfiguration();
        }

        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration )
        {
            throw new NotImplementedException();
        }
    }
}