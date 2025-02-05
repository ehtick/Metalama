// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Runtime.Serialization;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    public class PortableSerializationException : Exception
    {
        public PortableSerializationException() { }

        public PortableSerializationException( string message ) : base( message ) { }

        public PortableSerializationException( string message, Exception inner ) : base( message, inner ) { }

        protected PortableSerializationException(
            SerializationInfo info,
            StreamingContext context ) : base( info, context ) { }
    }
}