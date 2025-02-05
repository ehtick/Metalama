// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Collections;
using System.Collections.Generic;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// The source code of method bodies and expression bodies is not represented in the high-level API of Metalama.
    /// If you need to access source code from an aspect, you must implement a service using Metalama SDK. 
    /// </summary>
    /// <seealso href="@roslyn-api"/>
    public interface IBlockExpression : IExpression
    {
        string Label { get; }

        ExceptionHandlerKind ExceptionHandlerKind { get; }

        IExceptionHandler ParentExceptionHandler { get; }

        IReadOnlyLinkedList<IExpression> Items { get; }

        IReadOnlyLinkedList<IExceptionHandler> ExceptionHandlers { get; }

        IList<ILocalVariable> LocalVariables { get; }
    }

    public enum ExceptionHandlerKind
    {
        None,

        Catch,

        Filter,

        Finally
    }
}