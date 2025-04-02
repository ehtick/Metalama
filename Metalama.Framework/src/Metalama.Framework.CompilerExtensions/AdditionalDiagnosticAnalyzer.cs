// Copyright (c) 2020-2025 SharpCrafters s.r.o. and contributors.
// SharpCrafters s.r.o. licenses this file to you under either the MIT license or a proprietary license, depending on the repository from which it was obtained.
// Refer to LICENSE.md in the repository root for complete details.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

#pragma warning disable RS1026 // Enable concurrent execution
#pragma warning disable RS1025 // Configure generated code analysis

namespace Metalama.Framework.CompilerExtensions;

[DiagnosticAnalyzer( LanguageNames.CSharp )]
public sealed class AdditionalDiagnosticAnalyzer : DiagnosticAnalyzer
{
    private readonly DiagnosticAnalyzer _impl = (DiagnosticAnalyzer) ResourceExtractor.CreateInstance(
        "Metalama.Framework.Engine",
        "Metalama.Framework.Engine.Analyzers.AdditionalDiagnosticAnalyzer" );

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => this._impl.SupportedDiagnostics;

    public override void Initialize( AnalysisContext context ) => this._impl.Initialize( context );
}