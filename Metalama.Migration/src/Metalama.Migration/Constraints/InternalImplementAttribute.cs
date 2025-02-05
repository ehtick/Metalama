// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Extensibility;
using System;
using System.Reflection;

namespace PostSharp.Constraints
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Extensions.Architecture.Aspects.InternalOnlyImplementAttribute"/>.
    /// </summary>
    [AttributeUsage(
        AttributeTargets.All & ~(AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter),
        AllowMultiple = true )]
    [MulticastAttributeUsage( MulticastTargets.Interface, TargetTypeAttributes = MulticastAttributes.Public )]
    public sealed class InternalImplementAttribute : ReferentialConstraint
    {
        public InternalImplementAttribute()
        {
            throw new NotImplementedException();
        }

        public SeverityType Severity { get; set; }

        public override void ValidateCode( object target, Assembly assembly )
        {
            throw new NotImplementedException();
        }
    }
}