// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Reflection;
using System;
using System.Reflection;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    public static class SerializationServices
    {
        public static PortableSerializationException GetSerializationException( MemberInfo memberInfo )
        {
            throw new NotImplementedException();
        }

        public static PortableSerializationException GetSerializationException( LocationInfo locationInfo )
        {
            throw new NotImplementedException();
        }

        public static PortableSerializationException GetSerializationException( ParameterInfo parameterInfo )
        {
            throw new NotImplementedException();
        }
    }
}