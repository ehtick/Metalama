// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Aspects
{
    [PublicAPI]
    public class TypeIdentity
    {
        public static TypeIdentity FromType( Type type )
        {
            throw new NotImplementedException();
        }

        public static TypeIdentity[] FromTypes( Type[] types )
        {
            throw new NotImplementedException();
        }

        public Type Type { get; }

        public Type ToType()
        {
            throw new NotImplementedException();
        }

        public static TypeIdentity FromTypeName( string typeName )
        {
            throw new NotImplementedException();
        }

        public static TypeIdentity[] FromTypeNames( string[] typeNames )
        {
            throw new NotImplementedException();
        }

        public string TypeName { get; }
    }
}