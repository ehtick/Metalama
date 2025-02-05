// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Aspects.Internals;
using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In PostSharp, this object exposed the run-time execution context to the advice. However, in Metalama, advice do not execute at run time.
    /// Instead, advice are templates that generate run-time code. This run-time code does not need helper objects to represent the execution context.
    /// </summary>
    public sealed class LocationInitializationArgs : LocationLevelAdviceArgs
    {
        internal LocationInitializationArgs()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, use the <c>value</c> template parameter.
        /// </summary>
        public override object Value { get; set; }
    }
}