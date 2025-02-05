// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Reflection
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public interface IMetadataDispenser
    {
        object GetMetadata( int index );
    }
}