// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.ValueTypeSerializer{T}"/>.
    /// </summary>
    [PublicAPI]
    public abstract class ValueTypeSerializer<T> : ISerializer where T : struct
    {
        bool ISerializer.IsTwoPhase { get; }

        public abstract void SerializeObject( T obj, IArgumentsWriter constructorArguments );

        public abstract T DeserializeObject( IArgumentsReader constructorArguments );

        void ISerializer.SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments )
        {
            throw new NotImplementedException();
        }

        public virtual object Convert( object value, Type targetType )
        {
            throw new NotImplementedException();
        }

        object ISerializer.CreateInstance( Type type, IArgumentsReader constructorArguments )
        {
            throw new NotImplementedException();
        }

        void ISerializer.DeserializeFields( ref object o, IArgumentsReader initializationArguments ) { }
    }
}