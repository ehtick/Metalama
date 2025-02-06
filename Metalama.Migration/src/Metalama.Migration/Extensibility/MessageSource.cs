// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;
using System.Reflection;
using System.Resources;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [PublicAPI]
    public class MessageSource :
        MarshalByRefObject,
        IMessageSink
    {
        public MessageSource( string source, ResourceManager resourceManager )

        {
            throw new NotImplementedException();
        }

        public MessageSource( string source, IMessageDispenser messageDispenser )
        {
            throw new NotImplementedException();
        }

        public Message CreateMessage(
            MessageLocation location,
            SeverityType severity,
            string messageId,
            Exception innerException,
            params object[] arguments )
        {
            throw new NotImplementedException();
        }

        public void Write( MessageLocation location, SeverityType severity, string messageId, Exception innerException, params object[] arguments )
        {
            throw new NotImplementedException();
        }

        public void Write( MessageLocation location, SeverityType severity, string messageId, params object[] arguments )
        {
            throw new NotImplementedException();
        }

        public void Write( MemberInfo codeElement, SeverityType severity, string messageId, params object[] arguments )
        {
            throw new NotImplementedException();
        }

        public void Write( ParameterInfo codeElement, SeverityType severity, string messageId, params object[] arguments )
        {
            throw new NotImplementedException();
        }

        public void Write( Assembly codeElement, SeverityType severity, string messageId, params object[] arguments )
        {
            throw new NotImplementedException();
        }

        #region IMessageSink Members

        public void Write( Message message )
        {
            throw new NotImplementedException();
        }

        #endregion

        public static IMessageSink MessageSink { get; }
    }
}