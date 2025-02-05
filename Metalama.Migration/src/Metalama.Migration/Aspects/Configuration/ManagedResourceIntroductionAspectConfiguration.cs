// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no aspect configuration in Metalama.
    /// </summary>
    [PublicAPI]
    public sealed class ManagedResourceIntroductionAspectConfiguration : AspectConfiguration
    {
        public ManagedResourceIntroductionAspectConfiguration( string name, byte[] data )
        {
            throw new NotImplementedException();
        }

        public ManagedResourceIntroductionAspectConfiguration( string name, Func<byte[]> dataProvider )
        {
            throw new NotImplementedException();
        }

        public string Name { get; }

        public byte[] Data { get; }

        public Func<byte[]> DataProvider { get; }
    }
}