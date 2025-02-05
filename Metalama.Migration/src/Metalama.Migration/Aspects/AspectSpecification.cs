// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using PostSharp.Aspects.Configuration;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no equivalent to this class in Metalama.
    /// </summary>
    [PublicAPI]
    public class AspectSpecification
    {
        public AspectConfiguration AspectConfiguration { get; }

        public ObjectConstruction AspectConstruction { get; }

        public IAspect Aspect { get; }

        public string AspectAssemblyQualifiedTypeName { get; }

        public string AspectTypeName { get; }
    }
}