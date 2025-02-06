// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Reflection;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    /// Aspect are also serializable in Metalama, but the serializer cannot be customized.
    /// </summary>
    public class BinaryAspectSerializer : AspectSerializer
    {
        protected override IAspect[] Deserialize( Stream stream, IMetadataDispenser metadataDispenser )
        {
            throw new NotImplementedException();
        }

        public override void Serialize( IAspect[] aspects, Stream stream, IMetadataEmitter metadataEmitter )
        {
            throw new NotImplementedException();
        }

        public static void ChainSurrogateSelector( ISurrogateSelector selector )
        {
            throw new NotImplementedException();
        }
    }
}