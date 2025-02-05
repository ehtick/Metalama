// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// The source code of method bodies and expression bodies is not represented in the high-level API of Metalama.
    /// If you need to access source code from an aspect, you must implement a service using Metalama SDK. 
    /// </summary>
    /// <seealso href="@roslyn-api"/>
    public interface IMethodCallExpression : IExpression
    {
        IExpression Instance { get; }

        MethodBase Method { get; }

        IList<IExpression> Arguments { get; }

        bool IsVirtual { get; }

        bool IsTail { get; }

        Type ConstrainedType { get; }
    }
}