// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In PostSharp, this delegate allowed the run-time code of the aspect to access a property in the target code. In Metalama,
    /// no run-time helper is required because the template directly generates run-time code.
    /// Use <see cref="Metalama.Framework.Code.IProperty"/>.<see cref="IExpression.Value"/> to generate run-time code for any property.
    /// </summary>
    public delegate void PropertySetter<TValue>( TValue value );
}