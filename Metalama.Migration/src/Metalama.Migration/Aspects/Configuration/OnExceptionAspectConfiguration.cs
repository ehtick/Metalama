// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Configuration
{
    public sealed class OnExceptionAspectConfiguration : AspectConfiguration
    {
        public TypeIdentity ExceptionType { get; set; }

        public SemanticallyAdvisedMethodKinds? SemanticallyAdvisedMethodKinds { get; set; }
    }
}