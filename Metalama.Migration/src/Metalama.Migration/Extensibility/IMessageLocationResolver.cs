// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;
using Metalama.Framework.Diagnostics;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, an <see cref="IDeclaration"/> is also a <see cref="IDiagnosticLocation"/>.
    /// </summary>
    public interface IMessageLocationResolver : IService
    {
        MessageLocation GetMessageLocation( object codeElement );
    }
}