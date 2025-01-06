#pragma warning disable CS8669 // Nullability
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Metalama.Framework.Engine.CompileTime;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Metalama.Framework.Engine.Templating;

internal partial class RoslynVersionSyntaxVerifier
{
	public override void VisitScopedType( ScopedTypeSyntax node )
	{
		this.VisitVersionSpecificNode( node, RoslynApiVersion.V4_4_0 );
	}
	public override void VisitListPattern( ListPatternSyntax node )
	{
		this.VisitVersionSpecificNode( node, RoslynApiVersion.V4_4_0 );
	}
	public override void VisitSlicePattern( SlicePatternSyntax node )
	{
		this.VisitVersionSpecificNode( node, RoslynApiVersion.V4_4_0 );
	}
	public override void VisitBinaryExpression( BinaryExpressionSyntax node )
	{
		switch( node.OperatorToken.Kind() )
		{
			case SyntaxKind.GreaterThanGreaterThanGreaterThanToken:
				this.VisitVersionSpecificFieldKind( node.OperatorToken, RoslynApiVersion.V4_4_0 ); 
				break;
		}
	}
	public override void VisitAssignmentExpression( AssignmentExpressionSyntax node )
	{
		switch( node.OperatorToken.Kind() )
		{
			case SyntaxKind.GreaterThanGreaterThanGreaterThanEqualsToken:
				this.VisitVersionSpecificFieldKind( node.OperatorToken, RoslynApiVersion.V4_4_0 ); 
				break;
		}
	}
	public override void VisitLiteralExpression( LiteralExpressionSyntax node )
	{
		switch( node.Token.Kind() )
		{
			case SyntaxKind.Utf8StringLiteralToken:
				this.VisitVersionSpecificFieldKind( node.Token, RoslynApiVersion.V4_4_0 ); 
				break;
			case SyntaxKind.MultiLineRawStringLiteralToken:
				this.VisitVersionSpecificFieldKind( node.Token, RoslynApiVersion.V4_4_0 ); 
				break;
			case SyntaxKind.Utf8MultiLineRawStringLiteralToken:
				this.VisitVersionSpecificFieldKind( node.Token, RoslynApiVersion.V4_4_0 ); 
				break;
			case SyntaxKind.SingleLineRawStringLiteralToken:
				this.VisitVersionSpecificFieldKind( node.Token, RoslynApiVersion.V4_4_0 ); 
				break;
			case SyntaxKind.Utf8SingleLineRawStringLiteralToken:
				this.VisitVersionSpecificFieldKind( node.Token, RoslynApiVersion.V4_4_0 ); 
				break;
		}
	}
	public override void VisitInterpolatedStringExpression( InterpolatedStringExpressionSyntax node )
	{
		switch( node.StringStartToken.Kind() )
		{
			case SyntaxKind.InterpolatedSingleLineRawStringStartToken:
				this.VisitVersionSpecificFieldKind( node.StringStartToken, RoslynApiVersion.V4_4_0 ); 
				break;
			case SyntaxKind.InterpolatedMultiLineRawStringStartToken:
				this.VisitVersionSpecificFieldKind( node.StringStartToken, RoslynApiVersion.V4_4_0 ); 
				break;
		}
		switch( node.StringEndToken.Kind() )
		{
			case SyntaxKind.InterpolatedRawStringEndToken:
				this.VisitVersionSpecificFieldKind( node.StringEndToken, RoslynApiVersion.V4_4_0 ); 
				break;
		}
	}
	public override void VisitOperatorDeclaration( OperatorDeclarationSyntax node )
	{
		this.VisitVersionSpecificField( node.CheckedKeyword, RoslynApiVersion.V4_4_0 ); 
		switch( node.OperatorToken.Kind() )
		{
			case SyntaxKind.GreaterThanGreaterThanGreaterThanToken:
				this.VisitVersionSpecificFieldKind( node.OperatorToken, RoslynApiVersion.V4_4_0 ); 
				break;
		}
	}
	public override void VisitConversionOperatorDeclaration( ConversionOperatorDeclarationSyntax node )
	{
		this.VisitVersionSpecificField( node.CheckedKeyword, RoslynApiVersion.V4_4_0 ); 
	}
	public override void VisitOperatorMemberCref( OperatorMemberCrefSyntax node )
	{
		this.VisitVersionSpecificField( node.CheckedKeyword, RoslynApiVersion.V4_4_0 ); 
		switch( node.OperatorToken.Kind() )
		{
			case SyntaxKind.GreaterThanGreaterThanGreaterThanToken:
				this.VisitVersionSpecificFieldKind( node.OperatorToken, RoslynApiVersion.V4_4_0 ); 
				break;
		}
	}
	public override void VisitConversionOperatorMemberCref( ConversionOperatorMemberCrefSyntax node )
	{
		this.VisitVersionSpecificField( node.CheckedKeyword, RoslynApiVersion.V4_4_0 ); 
	}
}
