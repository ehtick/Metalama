// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Equivalent to <see cref="ContractDirection"/>.
    /// </summary>
    public enum LocationValidationContext
    {
        None = 0,

        Precondition = 1,

        SuccessPostcondition = 2
    }
}