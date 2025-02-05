// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Diagnostics;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, messages are called diagnostics and they must be defined as static fields of aspects or fabrics using the <see cref="DiagnosticDefinition{T}"/> class.
    /// </summary>
    /// <seealso href="@diagnostics"/>
    public interface IMessageDispenser
    {
        string GetMessage( string key );
    }
}