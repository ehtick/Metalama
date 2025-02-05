// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use <see cref="meta"/>.<see cref="meta.This"/> in the template.
    /// </summary>
    public sealed class ThisAttribute : AdviceParameterAttribute { }
}