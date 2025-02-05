// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Bindings do not exist in Metalama. Instead, use invokers (e.g. <see cref="IMethod"/>.<see cref="IMethod.Invoke(object[])"/>) to generate run-time
    /// code that invokes the desired method or accesses the property or event.
    /// </summary>
    public sealed class BindingAttribute : AdviceParameterAttribute { }
}