// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// To escalate Metalama warnings into errors, use the same strategy as for C# or analyzer errors.
    /// </summary>
    [AttributeUsage( AttributeTargets.Assembly, AllowMultiple = true )]
    [PublicAPI]
    public sealed class EscalatePostSharpMessageAttribute : Attribute
    {
        public EscalatePostSharpMessageAttribute( string messageId )
        {
            throw new NotImplementedException();
        }

        public string MessageId { get; }
    }
}