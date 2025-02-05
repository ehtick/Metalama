// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using Metalama.Framework.Code.DeclarationBuilders;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="AttributeConstruction"/>.
    /// </summary>
    [PublicAPI]
    public sealed class ObjectConstruction
    {
        public ObjectConstruction( string typeName, params object[] constructorArguments )
        {
            throw new NotImplementedException();
        }

        public ObjectConstruction( Type type, params object[] constructorArguments )
        {
            throw new NotImplementedException();
        }

        public ObjectConstruction( ConstructorInfo constructor, params object[] constructorArguments )
        {
            throw new NotImplementedException();
        }

        public ObjectConstruction( CustomAttributeData customAttributeData )
        {
            throw new NotImplementedException();
        }

        public string TypeName { get; }

        public ConstructorInfo Constructor { get; }

        public IList<object> ConstructorArguments { get; }

        public IDictionary<string, object> NamedArguments { get; }
    }
}