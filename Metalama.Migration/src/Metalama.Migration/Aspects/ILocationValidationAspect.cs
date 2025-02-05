// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using PostSharp.Reflection;
using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="ContractAspect"/>.
    /// </summary>
    public interface ILocationValidationAspect : IAspect { }

    /// <summary>
    /// In Metalama, use <see cref="ContractAspect"/>.
    /// </summary>
    public interface ILocationValidationAspect<T> : ILocationValidationAspect
    {
        /// <summary>
        /// In Metalama, implement <see cref="ContractAspect.Validate"/>.
        /// </summary>
        Exception ValidateValue( T value, string locationName, LocationKind locationKind, LocationValidationContext context );
    }
}