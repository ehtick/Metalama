// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Advices
{
    [AttributeUsage( AttributeTargets.Method, Inherited = false )]
    public abstract class GroupingAdvice : Advice
    {
        public string Master { get; set; }
    }
}