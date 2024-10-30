// Copyright (c) SharpCrafters s.r.o. See the LICENSE.md file in the root directory of this repository root for details.

using Metalama.Framework.Advising;
using Metalama.Framework.Code;
using Metalama.Framework.Engine.CodeModel;
using Metalama.Framework.Engine.CodeModel.Builders;
using Metalama.Framework.Engine.Services;
using Metalama.Framework.Engine.Transformations;
using System;

namespace Metalama.Framework.Engine.AdviceImpl.Introduction;

internal sealed class IntroduceNamespaceAdvice : IntroduceDeclarationAdvice<INamespace, NamespaceBuilder>
{
    private static readonly char[] _nsSplitChars = ['.'];

    public override AdviceKind AdviceKind => AdviceKind.IntroduceNamespace;

    public IntroduceNamespaceAdvice(
        AdviceConstructorParameters<INamespace> parameters,
        string name ) : base( parameters, null )
    {
        var nameParts = name.Split( _nsSplitChars );

        var parentNamespace = parameters.TargetDeclaration;

        for ( var index = 0; index < nameParts.Length - 1; index++ )
        {
            var childNs = parentNamespace.Namespaces.OfName( nameParts[index] )
                          ?? new NamespaceBuilder( this, parentNamespace, nameParts[index] );

            parentNamespace = childNs;
        }

        this.Builder = new NamespaceBuilder( this, parentNamespace, nameParts[^1] );
    }

    protected override IntroductionAdviceResult<INamespace> Implement(
        ProjectServiceProvider serviceProvider,
        CompilationModel compilation,
        Action<ITransformation> addTransformation )
    {
        void AddTransformationRecursive( NamespaceBuilder ns )
        {
            if ( ns.ContainingNamespace is NamespaceBuilder parentBuilder )
            {
                // Make sure to the add parent namespace before the child one.
                AddTransformationRecursive( parentBuilder );
            }

            addTransformation( ns.ToTransformation() );
        }

        var existingNamespace = this.Builder.ContainingNamespace.TryForCompilation( compilation, out var containingNamespace )
            ? containingNamespace.Namespaces.OfName( this.Builder.Name )
            : null;

        if ( existingNamespace == null )
        {
            // We have a new namespace.
            AddTransformationRecursive( this.Builder );

            return this.CreateSuccessResult( AdviceOutcome.Default, this.Builder );
        }
        else
        {
            return this.CreateSuccessResult( AdviceOutcome.Ignore, existingNamespace );
        }
    }
}