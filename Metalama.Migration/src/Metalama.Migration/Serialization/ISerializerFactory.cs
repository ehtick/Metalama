// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.ISerializerFactory"/>.
    /// </summary>
    public interface ISerializerFactory
    {
        ISerializer CreateSerializer( Type objectType );
    }
}