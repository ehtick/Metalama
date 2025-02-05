// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Runtime.Serialization;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    /// Aspect are also serializable in Metalama, but the serializer cannot be customized.
    /// </summary>
    public class BinaryAspectSerializationBinder : SerializationBinder
    {
        public override Type BindToType( string assemblyName, string typeName )
        {
            throw new NotImplementedException();
        }
    }
}