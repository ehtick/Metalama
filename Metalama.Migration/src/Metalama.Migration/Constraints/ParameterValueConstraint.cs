// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Extensibility;
using PostSharp.Reflection.MethodBody;
using System;
using System.Reflection;

namespace PostSharp.Constraints
{
    /// <summary>
    /// Not implemented yet in Metalama, and there is currently no plan to do it.
    /// </summary>
    [AttributeUsage( AttributeTargets.Parameter )]
    [MulticastAttributeUsage( MulticastTargets.Parameter, Inheritance = MulticastInheritance.Strict )]
    [Obsolete( "", true )]
    public abstract class ParameterValueConstraint : ReferentialConstraint
    {
        public sealed override bool ValidateConstraint( object target )
        {
            throw new NotImplementedException();
        }

        protected virtual bool ValidateTargetParameter( ParameterInfo parameter )
        {
            throw new NotImplementedException();
        }

        public sealed override void ValidateCode( object target, Assembly assembly )
        {
            throw new NotImplementedException();
        }

        protected abstract void ValidateParameterValue( ParameterInfo parameter, IExpression expression );
    }
}