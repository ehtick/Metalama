// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;
using Metalama.Framework.Code.Invokers;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, equivalent functionality can be achieved using <see cref="InvokerOptions"/>.
    /// You can pass an <see cref="InvokerOptions"/> to the <c>With</c> method of the member or invoker (e.g. <see cref="IMethod"/>.<see cref="M:IMethod.With"/>).
    /// </summary>
    public enum ImportMemberOrder
    {
        /// <summary>
        /// Equivalent to <see cref="InvokerOptions.Default"/>.
        /// </summary>
        Default,

        /// <summary>
        /// Equivalent to <see cref="InvokerOptions.Base"/>.
        /// </summary>
        BeforeIntroductions,

        /// <summary>
        /// Equivalent to <see cref="InvokerOptions.Default"/>.
        /// </summary>
        AfterIntroductions = Default
    }
}