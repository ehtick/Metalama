// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.IArgumentsReader"/>.
    /// </summary>
    [InternalImplement]
    public interface IArgumentsReader
    {
        bool TryGetValue<T>( string name, out T value, string scope = null );

        T GetValue<T>( string name, string scope = null );

        IMetadataDispenser MetadataDispenser { get; }
    }
}