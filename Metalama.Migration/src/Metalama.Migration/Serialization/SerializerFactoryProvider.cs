// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    [PublicAPI]
    public class SerializerFactoryProvider : ISerializerFactoryProvider
    {
        public static readonly SerializerFactoryProvider BuiltIn;

        public void MakeReadOnly()
        {
            throw new NotImplementedException();
        }

        public ISerializerFactoryProvider NextProvider { get; }

        // ReSharper disable UnusedTypeParameter
        public void AddSerializer<TObject, TSerializer>() where TSerializer : ISerializer, new()
        {
            throw new NotImplementedException();
        }

        public void AddSerializer( Type objectType, Type serializerType )
        {
            throw new NotImplementedException();
        }

        public virtual Type GetSurrogateType( Type objectType )
        {
            throw new NotImplementedException();
        }

        public virtual ISerializerFactory GetSerializerFactory( Type objectType )
        {
            throw new NotImplementedException();
        }
    }
}