// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using Metalama.Framework.Code.Collections;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, do not use a parameter but use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Parameters"/>.<see cref="IParameterList.ToValueArray"/>
    /// from the template implementation.
    /// </summary>
    /// <seealso href="@template-parameters"/>
    public sealed class ArgumentsAttribute : AdviceParameterAttribute { }
}