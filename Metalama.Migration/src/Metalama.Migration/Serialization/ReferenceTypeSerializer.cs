// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.ReferenceTypeSerializer"/>.
    /// </summary>
    [PublicAPI]
    public abstract class ReferenceTypeSerializer : ISerializer
    {
        bool ISerializer.IsTwoPhase { get; }

        void ISerializer.DeserializeFields( ref object obj, IArgumentsReader initializationArguments )
        {
            throw new NotImplementedException();
        }

        void ISerializer.SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments )
        {
            throw new NotImplementedException();
        }

        public abstract object CreateInstance( Type type, IArgumentsReader constructorArguments );

        public abstract void SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments );

        public abstract void DeserializeFields( object obj, IArgumentsReader initializationArguments );

        public virtual object Convert( object value, Type targetType )
        {
            throw new NotImplementedException();
        }
    }
}