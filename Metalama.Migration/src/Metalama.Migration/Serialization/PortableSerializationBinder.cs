// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Serialization
{
    // ReSharper disable ClassWithVirtualMembersNeverInherited.Global
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    public class PortableSerializationBinder
    {
        public PortableSerializationBinder()
        {
            throw new NotImplementedException();
        }

        public virtual Type BindToType( string typeName, string assemblyName )
        {
            throw new NotImplementedException();
        }

        public virtual void BindToName( Type type, out string typeName, out string assemblyName )
        {
            throw new NotImplementedException();
        }
    }
}