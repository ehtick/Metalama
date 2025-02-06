// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Compiler;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace Metalama.Migration.Transformer
{
    [Transformer]
    public class Transformer : ISourceTransformer
    {
        public void Execute( TransformerContext context )
        {
            HashSet<ISymbol> processedPartialTypes = new( SymbolEqualityComparer.Default );

            foreach ( var syntaxTree in context.Compilation.SyntaxTrees )
            {
                var semanticModel = context.Compilation.GetSemanticModel( syntaxTree );

                var rewriter = new Rewriter( semanticModel, processedPartialTypes );
                var newSyntaxRoot = rewriter.Visit( syntaxTree.GetRoot() );
                var newSyntaxTree = syntaxTree.WithRootAndOptions( newSyntaxRoot, syntaxTree.Options );
                context.ReplaceSyntaxTree( syntaxTree, newSyntaxTree );
            }
        }
    }
}