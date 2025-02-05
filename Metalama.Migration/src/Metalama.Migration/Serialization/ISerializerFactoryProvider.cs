// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    public interface ISerializerFactoryProvider
    {
        Type GetSurrogateType( Type objectType );

        ISerializerFactory GetSerializerFactory( Type objectType );

        ISerializerFactoryProvider NextProvider { get; }
    }
}