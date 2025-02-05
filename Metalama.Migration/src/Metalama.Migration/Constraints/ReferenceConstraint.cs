// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using Metalama.Framework.Validation;
using PostSharp.Extensibility;
using PostSharp.Reflection;
using System;
using System.Reflection;

namespace PostSharp.Constraints
{
    /// <summary>
    /// In Metalama, use an aspect or a fabric, and register a reference validator using the <see cref="IValidatorReceiver{TDeclaration}.ValidateReferences{TValidator}"/>
    /// method. For instance, from the <see cref="IAspect{T}.BuildAspect"/> method of an aspect, call
    /// <c>builder</c>.<see cref="IAspectReceiverSelector{TTarget}.With{TMember}(System.Func{TTarget,System.Collections.Generic.IEnumerable{TMember}})"/><c>(...)</c>.<see cref="IValidatorReceiver{TDeclaration}.ValidateReferences{TValidator}"/>.
    /// </summary>
    /// <seealso href="@aspect-validating"/>
    /// <seealso href="@validating-usage"/>
    [AttributeUsage(
        AttributeTargets.All & ~(AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter),
        AllowMultiple = true )]
    [MulticastAttributeUsage(
        MulticastTargets.AnyType | MulticastTargets.Method | MulticastTargets.InstanceConstructor | MulticastTargets.Field,
        TargetTypeAttributes = MulticastAttributes.Public | MulticastAttributes.Internal | MulticastAttributes.InternalOrProtected
                               | MulticastAttributes.UserGenerated,
        TargetMemberAttributes = MulticastAttributes.AnyVisibility & ~MulticastAttributes.Private )]
    public abstract class ReferenceConstraint : ReferentialConstraint
    {
        protected abstract void ValidateReference( ICodeReference reference );

        public sealed override void ValidateCode( object target, Assembly assembly )
        {
            throw new NotImplementedException();
        }
    }
}