// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.IArgumentsWriter"/>.
    /// </summary>
    [InternalImplement]
    public interface IArgumentsWriter
    {
        void SetValue( string name, object value, string scope = null );

        IMetadataEmitter MetadataEmitter { get; }
    }
}