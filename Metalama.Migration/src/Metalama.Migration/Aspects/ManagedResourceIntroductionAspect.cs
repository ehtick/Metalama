// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Not implemented in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    [PublicAPI]
    public sealed class ManagedResourceIntroductionAspect : IManagedResourceIntroductionAspect, IAspectBuildSemantics
    {
        public ManagedResourceIntroductionAspect( string name, byte[] data )
        {
            throw new NotImplementedException();
        }

        public ManagedResourceIntroductionAspect( string name, Func<byte[]> dataProvider )
        {
            throw new NotImplementedException();
        }

        public string Name { get; }

        public byte[] Data { get; }

        public Func<byte[]> DataProvider { get; }

        /// <inheritdoc/>
        bool IValidableAnnotation.CompileTimeValidate( object target ) => true;

        AspectConfiguration IAspectBuildSemantics.GetAspectConfiguration( object targetElement )
        {
            throw new NotImplementedException();
        }
    }
}