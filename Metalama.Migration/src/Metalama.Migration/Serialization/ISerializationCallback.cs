// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.ICompileTimeSerializationCallback"/>.
    /// </summary>
    public interface ISerializationCallback
    {
        void OnDeserialized();

        void OnSerializing();
    }
}