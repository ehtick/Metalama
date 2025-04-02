// Copyright (c) 2020-2025 SharpCrafters s.r.o. and contributors.
// SharpCrafters s.r.o. licenses this file to you under either the MIT license or a proprietary license, depending on the repository from which it was obtained.
// Refer to LICENSE.md in the repository root for complete details.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Threading;

namespace Metalama.Framework.Engine.Analyzers;

internal sealed class SymbolAnalysisContextAdapter : ISymbolAnalysisContext
{
    private readonly SymbolAnalysisContext _context;

    public SymbolAnalysisContextAdapter( SymbolAnalysisContext context )
    {
        this._context = context;
    }

    public Compilation Compilation => this._context.Compilation;

    public ISymbol Symbol => this._context.Symbol;

    public CancellationToken CancellationToken => this._context.CancellationToken;

    public void ReportDiagnostic( Diagnostic diagnostic ) => this._context.ReportDiagnostic( diagnostic );
}