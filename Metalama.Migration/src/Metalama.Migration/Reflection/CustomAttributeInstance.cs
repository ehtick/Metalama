// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using Metalama.Framework.Code;
using System;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="IAttributeData"/>.
    /// </summary>
    [PublicAPI]
    public sealed class CustomAttributeInstance
    {
        public ObjectConstruction Construction { get; }

        public Attribute Attribute { get; }

        public object Target;

        internal object Annotation { get; }
    }
}