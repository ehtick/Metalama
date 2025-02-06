// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Diagnostics;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, the equivalent is <see cref="IDiagnosticSink"/>.
    /// </summary>
    public interface IMessageSink
    {
        void Write( Message message );
    }
}