// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Reflection;
using System;
using System.IO;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    /// Aspect are also serializable in Metalama, but the serializer cannot be customized.
    /// </summary>
    public sealed class PortableAspectSerializer : AspectSerializer
    {
        public override void Serialize( IAspect[] aspects, Stream stream, IMetadataEmitter metadataEmitter )
        {
            throw new NotImplementedException();
        }

        protected override IAspect[] Deserialize( Stream stream, IMetadataDispenser metadataDispenser )
        {
            throw new NotImplementedException();
        }
    }
}