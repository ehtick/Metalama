// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Extensibility;
using System;
using System.Reflection;

namespace PostSharp.Constraints
{
    /// <summary>
    /// Not implemented yet in Metalama, but it will be.
    /// </summary>
    [AttributeUsage(
        AttributeTargets.All & ~(AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter),
        AllowMultiple = true )]
    [MulticastAttributeUsage(
        MulticastTargets.AnyType | MulticastTargets.Method | MulticastTargets.InstanceConstructor | MulticastTargets.Field,
        TargetTypeAttributes = MulticastAttributes.Public | MulticastAttributes.Internal | MulticastAttributes.UserGenerated,
        TargetMemberAttributes = MulticastAttributes.Public | MulticastAttributes.Internal )]
    public sealed class ProtectedAttribute : ReferentialConstraint
    {
        public ProtectedAttribute()
        {
            throw new NotImplementedException();
        }

        public SeverityType Severity { get; set; }

        public override bool ValidateConstraint( object target )
        {
            throw new NotImplementedException();
        }

        public override void ValidateCode( object target, Assembly assembly )
        {
            throw new NotImplementedException();
        }
    }
}