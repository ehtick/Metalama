// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.ImportSerializerAttribute"/>.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Assembly, AllowMultiple = true )]
    [PublicAPI]
    public sealed class ImportSerializerAttribute : Attribute
    {
        public ImportSerializerAttribute( Type objectType, Type serializerType )
        {
            throw new NotImplementedException();
        }

        public Type ObjectType { get; }

        public Type SerializerType { get; }
    }
}