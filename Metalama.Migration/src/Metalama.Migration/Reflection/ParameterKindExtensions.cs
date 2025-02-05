// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;
using System;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="RefKindExtensions"/>.
    /// </summary>
    public static class ParameterKindExtensions
    {
        public static bool IsInputParameter( this ParameterKind parameterKind )
        {
            throw new NotImplementedException();
        }

        public static bool IsOutputParameter( this ParameterKind parameterKind )
        {
            throw new NotImplementedException();
        }

        public static bool IsReturn( this ParameterKind parameterKind )
        {
            throw new NotImplementedException();
        }

        public static bool IsByRefParameter( this ParameterKind parameterKind )
        {
            throw new NotImplementedException();
        }

        public static bool IsParameter( this ParameterKind parameterKind )
        {
            throw new NotImplementedException();
        }
    }
}