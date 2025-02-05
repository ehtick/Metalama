// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Reflection;
using System;
using System.IO;
using System.Reflection;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    /// Aspect are also serializable in Metalama, but the serializer cannot be customized.
    /// </summary>
    public abstract class AspectSerializer
    {
        public abstract void Serialize( IAspect[] aspects, Stream stream, IMetadataEmitter metadataEmitter );

        protected abstract IAspect[] Deserialize( Stream stream, IMetadataDispenser metadataDispenser );

        public IAspect[] Deserialize( Assembly assembly, string resourceName, IMetadataDispenser metadataDispenser )
        {
            throw new NotImplementedException();
        }
    }
}