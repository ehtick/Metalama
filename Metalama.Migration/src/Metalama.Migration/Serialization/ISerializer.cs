// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;
using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.ISerializer"/>.
    /// </summary>
    [InternalImplement]
    public interface ISerializer
    {
        object Convert( object value, Type targetType );

        object CreateInstance( Type type, IArgumentsReader constructorArguments );

        void DeserializeFields( ref object obj, IArgumentsReader initializationArguments );

        void SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments );

        bool IsTwoPhase { get; }
    }
}