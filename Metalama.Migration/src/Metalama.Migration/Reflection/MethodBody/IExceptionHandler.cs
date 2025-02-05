// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// The source code of method bodies and expression bodies is not represented in the high-level API of Metalama.
    /// If you need to access source code from an aspect, you must implement a service using Metalama SDK. 
    /// </summary>
    /// <seealso href="@roslyn-api"/>
    public interface IExceptionHandler
    {
        Type ExceptionType { get; }

        IBlockExpression TryBlock { get; }

        IBlockExpression FilterBlock { get; }

        IBlockExpression HandlerBlock { get; }

        ILocalVariable HandlerLocalVariable { get; }

        ILocalVariable FilterLocalVariable { get; }

        ExceptionHandlerKind ExceptionHandlerKind { get; }
    }
}