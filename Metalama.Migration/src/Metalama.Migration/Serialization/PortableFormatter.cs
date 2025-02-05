// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using PostSharp.Reflection;
using System;
using System.IO;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    [PublicAPI]
    public class PortableFormatter
    {
        public PortableFormatter() { }

        public static PortableSerializationBinder DefaultBinder { get; set; }

        public PortableFormatter( PortableSerializationBinder binder, ISerializerFactoryProvider serializerProvider )
        {
            throw new NotImplementedException();
        }

        public void Serialize( object obj, Stream stream )
        {
            throw new NotImplementedException();
        }

        public object Deserialize( Stream stream )
        {
            throw new NotImplementedException();
        }

        public IMetadataDispenser MetadataDispenser { get; set; }

        public IMetadataEmitter MetadataEmitter { get; set; }
    }
}