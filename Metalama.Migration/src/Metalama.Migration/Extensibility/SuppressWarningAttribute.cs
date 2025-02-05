// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use the same mechanism as for suppressing C# or analyzer warnings.
    /// </summary>
    [AttributeUsage( AttributeTargets.All, AllowMultiple = true, Inherited = false )]
    public class SuppressWarningAttribute : Attribute
    {
        public SuppressWarningAttribute( string messageId )
        {
            this.MessageId = messageId;
        }

        public string MessageId { get; }

        public string Reason { get; set; }
    }
}