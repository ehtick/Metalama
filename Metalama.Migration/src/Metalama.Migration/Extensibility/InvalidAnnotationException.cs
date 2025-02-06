// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Runtime.Serialization;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public class InvalidAnnotationException : Exception
    {
        public InvalidAnnotationException() { }

        public InvalidAnnotationException( string message ) : base( message ) { }

        public InvalidAnnotationException( string message, Exception inner ) : base( message, inner ) { }

        protected InvalidAnnotationException(
            SerializationInfo info,
            StreamingContext context ) : base( info, context ) { }
    }
}