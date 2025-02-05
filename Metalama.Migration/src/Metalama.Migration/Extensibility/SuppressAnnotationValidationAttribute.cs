// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// There is no equivalent in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Interface )]
    public class SuppressAnnotationValidationAttribute : Attribute { }
}