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
using K4os.Hash.xxHash;

namespace Metalama.Framework.DesignTime.Pipeline.Diff
{
	public class CompileTimeCodeHasher : BaseCodeHasher
	{
		public CompileTimeCodeHasher(XXH64 hasher) : base(hasher) {}

		[ExcludeFromCodeCoverage]
		public override void VisitIdentifierName( IdentifierNameSyntax node )
		{
			this.VisitNonTrivialToken( node.Identifier );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitQualifiedName( QualifiedNameSyntax node )
		{
			this.Visit( node.Left );
			this.VisitTrivialToken( node.DotToken );
			this.Visit( node.Right );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitGenericName( GenericNameSyntax node )
		{
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.TypeArgumentList );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitTypeArgumentList( TypeArgumentListSyntax node )
		{
			this.VisitTrivialToken( node.LessThanToken );
			this.Visit( node.Arguments );
			this.VisitTrivialToken( node.GreaterThanToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitAliasQualifiedName( AliasQualifiedNameSyntax node )
		{
			this.Visit( node.Alias );
			this.VisitTrivialToken( node.ColonColonToken );
			this.Visit( node.Name );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitPredefinedType( PredefinedTypeSyntax node )
		{
			this.VisitTrivialToken( node.Keyword );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitArrayType( ArrayTypeSyntax node )
		{
			this.Visit( node.ElementType );
			this.Visit( node.RankSpecifiers );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitArrayRankSpecifier( ArrayRankSpecifierSyntax node )
		{
			this.VisitTrivialToken( node.OpenBracketToken );
			this.Visit( node.Sizes );
			this.VisitTrivialToken( node.CloseBracketToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitPointerType( PointerTypeSyntax node )
		{
			this.Visit( node.ElementType );
			this.VisitTrivialToken( node.AsteriskToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitFunctionPointerType( FunctionPointerTypeSyntax node )
		{
			this.VisitTrivialToken( node.DelegateKeyword );
			this.VisitTrivialToken( node.AsteriskToken );
			this.Visit( node.CallingConvention );
			this.Visit( node.ParameterList );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitFunctionPointerParameterList( FunctionPointerParameterListSyntax node )
		{
			this.VisitTrivialToken( node.LessThanToken );
			this.Visit( node.Parameters );
			this.VisitTrivialToken( node.GreaterThanToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitFunctionPointerCallingConvention( FunctionPointerCallingConventionSyntax node )
		{
			this.VisitTrivialToken( node.ManagedOrUnmanagedKeyword );
			this.Visit( node.UnmanagedCallingConventionList );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitFunctionPointerUnmanagedCallingConventionList( FunctionPointerUnmanagedCallingConventionListSyntax node )
		{
			this.VisitTrivialToken( node.OpenBracketToken );
			this.Visit( node.CallingConventions );
			this.VisitTrivialToken( node.CloseBracketToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitFunctionPointerUnmanagedCallingConvention( FunctionPointerUnmanagedCallingConventionSyntax node )
		{
			this.VisitNonTrivialToken( node.Name );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitNullableType( NullableTypeSyntax node )
		{
			this.Visit( node.ElementType );
			this.VisitTrivialToken( node.QuestionToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitTupleType( TupleTypeSyntax node )
		{
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Elements );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitTupleElement( TupleElementSyntax node )
		{
			this.Visit( node.Type );
			this.VisitNonTrivialToken( node.Identifier );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitOmittedTypeArgument( OmittedTypeArgumentSyntax node )
		{
			this.VisitTrivialToken( node.OmittedTypeArgumentToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitRefType( RefTypeSyntax node )
		{
			this.VisitTrivialToken( node.RefKeyword );
			this.VisitTrivialToken( node.ReadOnlyKeyword );
			this.Visit( node.Type );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitScopedType( ScopedTypeSyntax node )
		{
			this.VisitTrivialToken( node.ScopedKeyword );
			this.Visit( node.Type );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitParenthesizedExpression( ParenthesizedExpressionSyntax node )
		{
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitTupleExpression( TupleExpressionSyntax node )
		{
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Arguments );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitPrefixUnaryExpression( PrefixUnaryExpressionSyntax node )
		{
			this.VisitTrivialToken( node.OperatorToken );
			this.Visit( node.Operand );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitAwaitExpression( AwaitExpressionSyntax node )
		{
			this.VisitTrivialToken( node.AwaitKeyword );
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitPostfixUnaryExpression( PostfixUnaryExpressionSyntax node )
		{
			this.Visit( node.Operand );
			this.VisitTrivialToken( node.OperatorToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitMemberAccessExpression( MemberAccessExpressionSyntax node )
		{
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.OperatorToken );
			this.Visit( node.Name );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitConditionalAccessExpression( ConditionalAccessExpressionSyntax node )
		{
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.OperatorToken );
			this.Visit( node.WhenNotNull );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitMemberBindingExpression( MemberBindingExpressionSyntax node )
		{
			this.VisitTrivialToken( node.OperatorToken );
			this.Visit( node.Name );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitElementBindingExpression( ElementBindingExpressionSyntax node )
		{
			this.Visit( node.ArgumentList );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitRangeExpression( RangeExpressionSyntax node )
		{
			this.Visit( node.LeftOperand );
			this.VisitTrivialToken( node.OperatorToken );
			this.Visit( node.RightOperand );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitImplicitElementAccess( ImplicitElementAccessSyntax node )
		{
			this.Visit( node.ArgumentList );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitBinaryExpression( BinaryExpressionSyntax node )
		{
			this.Visit( node.Left );
			this.VisitTrivialToken( node.OperatorToken );
			this.Visit( node.Right );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitAssignmentExpression( AssignmentExpressionSyntax node )
		{
			this.Visit( node.Left );
			this.VisitTrivialToken( node.OperatorToken );
			this.Visit( node.Right );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitConditionalExpression( ConditionalExpressionSyntax node )
		{
			this.Visit( node.Condition );
			this.VisitTrivialToken( node.QuestionToken );
			this.Visit( node.WhenTrue );
			this.VisitTrivialToken( node.ColonToken );
			this.Visit( node.WhenFalse );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitThisExpression( ThisExpressionSyntax node )
		{
			this.VisitTrivialToken( node.Token );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitBaseExpression( BaseExpressionSyntax node )
		{
			this.VisitTrivialToken( node.Token );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitLiteralExpression( LiteralExpressionSyntax node )
		{
			this.VisitNonTrivialToken( node.Token );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitMakeRefExpression( MakeRefExpressionSyntax node )
		{
			this.VisitTrivialToken( node.Keyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitRefTypeExpression( RefTypeExpressionSyntax node )
		{
			this.VisitTrivialToken( node.Keyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitRefValueExpression( RefValueExpressionSyntax node )
		{
			this.VisitTrivialToken( node.Keyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.Comma );
			this.Visit( node.Type );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitCheckedExpression( CheckedExpressionSyntax node )
		{
			this.VisitTrivialToken( node.Keyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitDefaultExpression( DefaultExpressionSyntax node )
		{
			this.VisitTrivialToken( node.Keyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Type );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitTypeOfExpression( TypeOfExpressionSyntax node )
		{
			this.VisitTrivialToken( node.Keyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Type );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitSizeOfExpression( SizeOfExpressionSyntax node )
		{
			this.VisitTrivialToken( node.Keyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Type );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitInvocationExpression( InvocationExpressionSyntax node )
		{
			this.Visit( node.Expression );
			this.Visit( node.ArgumentList );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitElementAccessExpression( ElementAccessExpressionSyntax node )
		{
			this.Visit( node.Expression );
			this.Visit( node.ArgumentList );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitArgumentList( ArgumentListSyntax node )
		{
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Arguments );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitBracketedArgumentList( BracketedArgumentListSyntax node )
		{
			this.VisitTrivialToken( node.OpenBracketToken );
			this.Visit( node.Arguments );
			this.VisitTrivialToken( node.CloseBracketToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitArgument( ArgumentSyntax node )
		{
			this.Visit( node.NameColon );
			this.VisitTrivialToken( node.RefKindKeyword );
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitExpressionColon( ExpressionColonSyntax node )
		{
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.ColonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitNameColon( NameColonSyntax node )
		{
			this.Visit( node.Name );
			this.VisitTrivialToken( node.ColonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitDeclarationExpression( DeclarationExpressionSyntax node )
		{
			this.Visit( node.Type );
			this.Visit( node.Designation );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitCastExpression( CastExpressionSyntax node )
		{
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Type );
			this.VisitTrivialToken( node.CloseParenToken );
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitAnonymousMethodExpression( AnonymousMethodExpressionSyntax node )
		{
			this.Visit( node.Modifiers );
			this.VisitTrivialToken( node.DelegateKeyword );
			this.Visit( node.ParameterList );
			this.Visit( node.Block );
			this.Visit( node.ExpressionBody );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitSimpleLambdaExpression( SimpleLambdaExpressionSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.Visit( node.Parameter );
			this.VisitTrivialToken( node.ArrowToken );
			this.Visit( node.Block );
			this.Visit( node.ExpressionBody );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitRefExpression( RefExpressionSyntax node )
		{
			this.VisitTrivialToken( node.RefKeyword );
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitParenthesizedLambdaExpression( ParenthesizedLambdaExpressionSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.Visit( node.ReturnType );
			this.Visit( node.ParameterList );
			this.VisitTrivialToken( node.ArrowToken );
			this.Visit( node.Block );
			this.Visit( node.ExpressionBody );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitInitializerExpression( InitializerExpressionSyntax node )
		{
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Expressions );
			this.VisitTrivialToken( node.CloseBraceToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitImplicitObjectCreationExpression( ImplicitObjectCreationExpressionSyntax node )
		{
			this.VisitTrivialToken( node.NewKeyword );
			this.Visit( node.ArgumentList );
			this.Visit( node.Initializer );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitObjectCreationExpression( ObjectCreationExpressionSyntax node )
		{
			this.VisitTrivialToken( node.NewKeyword );
			this.Visit( node.Type );
			this.Visit( node.ArgumentList );
			this.Visit( node.Initializer );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitWithExpression( WithExpressionSyntax node )
		{
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.WithKeyword );
			this.Visit( node.Initializer );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitAnonymousObjectMemberDeclarator( AnonymousObjectMemberDeclaratorSyntax node )
		{
			this.Visit( node.NameEquals );
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitAnonymousObjectCreationExpression( AnonymousObjectCreationExpressionSyntax node )
		{
			this.VisitTrivialToken( node.NewKeyword );
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Initializers );
			this.VisitTrivialToken( node.CloseBraceToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitArrayCreationExpression( ArrayCreationExpressionSyntax node )
		{
			this.VisitTrivialToken( node.NewKeyword );
			this.Visit( node.Type );
			this.Visit( node.Initializer );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitImplicitArrayCreationExpression( ImplicitArrayCreationExpressionSyntax node )
		{
			this.VisitTrivialToken( node.NewKeyword );
			this.VisitTrivialToken( node.OpenBracketToken );
			this.Visit( node.Commas );
			this.VisitTrivialToken( node.CloseBracketToken );
			this.Visit( node.Initializer );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitStackAllocArrayCreationExpression( StackAllocArrayCreationExpressionSyntax node )
		{
			this.VisitTrivialToken( node.StackAllocKeyword );
			this.Visit( node.Type );
			this.Visit( node.Initializer );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitImplicitStackAllocArrayCreationExpression( ImplicitStackAllocArrayCreationExpressionSyntax node )
		{
			this.VisitTrivialToken( node.StackAllocKeyword );
			this.VisitTrivialToken( node.OpenBracketToken );
			this.VisitTrivialToken( node.CloseBracketToken );
			this.Visit( node.Initializer );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitQueryExpression( QueryExpressionSyntax node )
		{
			this.Visit( node.FromClause );
			this.Visit( node.Body );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitQueryBody( QueryBodySyntax node )
		{
			this.Visit( node.Clauses );
			this.Visit( node.SelectOrGroup );
			this.Visit( node.Continuation );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitFromClause( FromClauseSyntax node )
		{
			this.VisitTrivialToken( node.FromKeyword );
			this.Visit( node.Type );
			this.VisitNonTrivialToken( node.Identifier );
			this.VisitTrivialToken( node.InKeyword );
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitLetClause( LetClauseSyntax node )
		{
			this.VisitTrivialToken( node.LetKeyword );
			this.VisitNonTrivialToken( node.Identifier );
			this.VisitTrivialToken( node.EqualsToken );
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitJoinClause( JoinClauseSyntax node )
		{
			this.VisitTrivialToken( node.JoinKeyword );
			this.Visit( node.Type );
			this.VisitNonTrivialToken( node.Identifier );
			this.VisitTrivialToken( node.InKeyword );
			this.Visit( node.InExpression );
			this.VisitTrivialToken( node.OnKeyword );
			this.Visit( node.LeftExpression );
			this.VisitTrivialToken( node.EqualsKeyword );
			this.Visit( node.RightExpression );
			this.Visit( node.Into );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitJoinIntoClause( JoinIntoClauseSyntax node )
		{
			this.VisitTrivialToken( node.IntoKeyword );
			this.VisitNonTrivialToken( node.Identifier );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitWhereClause( WhereClauseSyntax node )
		{
			this.VisitTrivialToken( node.WhereKeyword );
			this.Visit( node.Condition );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitOrderByClause( OrderByClauseSyntax node )
		{
			this.VisitTrivialToken( node.OrderByKeyword );
			this.Visit( node.Orderings );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitOrdering( OrderingSyntax node )
		{
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.AscendingOrDescendingKeyword );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitSelectClause( SelectClauseSyntax node )
		{
			this.VisitTrivialToken( node.SelectKeyword );
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitGroupClause( GroupClauseSyntax node )
		{
			this.VisitTrivialToken( node.GroupKeyword );
			this.Visit( node.GroupExpression );
			this.VisitTrivialToken( node.ByKeyword );
			this.Visit( node.ByExpression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitQueryContinuation( QueryContinuationSyntax node )
		{
			this.VisitTrivialToken( node.IntoKeyword );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.Body );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitOmittedArraySizeExpression( OmittedArraySizeExpressionSyntax node )
		{
			this.VisitTrivialToken( node.OmittedArraySizeExpressionToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitInterpolatedStringExpression( InterpolatedStringExpressionSyntax node )
		{
			this.VisitTrivialToken( node.StringStartToken );
			this.Visit( node.Contents );
			this.VisitTrivialToken( node.StringEndToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitIsPatternExpression( IsPatternExpressionSyntax node )
		{
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.IsKeyword );
			this.Visit( node.Pattern );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitThrowExpression( ThrowExpressionSyntax node )
		{
			this.VisitTrivialToken( node.ThrowKeyword );
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitWhenClause( WhenClauseSyntax node )
		{
			this.VisitTrivialToken( node.WhenKeyword );
			this.Visit( node.Condition );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitDiscardPattern( DiscardPatternSyntax node )
		{
			this.VisitTrivialToken( node.UnderscoreToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitDeclarationPattern( DeclarationPatternSyntax node )
		{
			this.Visit( node.Type );
			this.Visit( node.Designation );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitVarPattern( VarPatternSyntax node )
		{
			this.VisitTrivialToken( node.VarKeyword );
			this.Visit( node.Designation );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitRecursivePattern( RecursivePatternSyntax node )
		{
			this.Visit( node.Type );
			this.Visit( node.PositionalPatternClause );
			this.Visit( node.PropertyPatternClause );
			this.Visit( node.Designation );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitPositionalPatternClause( PositionalPatternClauseSyntax node )
		{
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Subpatterns );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitPropertyPatternClause( PropertyPatternClauseSyntax node )
		{
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Subpatterns );
			this.VisitTrivialToken( node.CloseBraceToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitSubpattern( SubpatternSyntax node )
		{
			this.Visit( node.ExpressionColon );
			this.Visit( node.Pattern );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitConstantPattern( ConstantPatternSyntax node )
		{
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitParenthesizedPattern( ParenthesizedPatternSyntax node )
		{
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Pattern );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitRelationalPattern( RelationalPatternSyntax node )
		{
			this.VisitTrivialToken( node.OperatorToken );
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitTypePattern( TypePatternSyntax node )
		{
			this.Visit( node.Type );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitBinaryPattern( BinaryPatternSyntax node )
		{
			this.Visit( node.Left );
			this.VisitTrivialToken( node.OperatorToken );
			this.Visit( node.Right );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitUnaryPattern( UnaryPatternSyntax node )
		{
			this.VisitTrivialToken( node.OperatorToken );
			this.Visit( node.Pattern );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitListPattern( ListPatternSyntax node )
		{
			this.VisitTrivialToken( node.OpenBracketToken );
			this.Visit( node.Patterns );
			this.VisitTrivialToken( node.CloseBracketToken );
			this.Visit( node.Designation );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitSlicePattern( SlicePatternSyntax node )
		{
			this.VisitTrivialToken( node.DotDotToken );
			this.Visit( node.Pattern );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitInterpolatedStringText( InterpolatedStringTextSyntax node )
		{
			this.VisitTrivialToken( node.TextToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitInterpolation( InterpolationSyntax node )
		{
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Expression );
			this.Visit( node.AlignmentClause );
			this.Visit( node.FormatClause );
			this.VisitTrivialToken( node.CloseBraceToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitInterpolationAlignmentClause( InterpolationAlignmentClauseSyntax node )
		{
			this.VisitTrivialToken( node.CommaToken );
			this.Visit( node.Value );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitInterpolationFormatClause( InterpolationFormatClauseSyntax node )
		{
			this.VisitTrivialToken( node.ColonToken );
			this.VisitTrivialToken( node.FormatStringToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitGlobalStatement( GlobalStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.Visit( node.Statement );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitBlock( BlockSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Statements );
			this.VisitTrivialToken( node.CloseBraceToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitLocalFunctionStatement( LocalFunctionStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.Visit( node.ReturnType );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.TypeParameterList );
			this.Visit( node.ParameterList );
			this.Visit( node.ConstraintClauses );
			this.Visit( node.Body );
			this.Visit( node.ExpressionBody );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitLocalDeclarationStatement( LocalDeclarationStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.AwaitKeyword );
			this.VisitTrivialToken( node.UsingKeyword );
			this.Visit( node.Modifiers );
			this.Visit( node.Declaration );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitVariableDeclaration( VariableDeclarationSyntax node )
		{
			this.Visit( node.Type );
			this.Visit( node.Variables );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitVariableDeclarator( VariableDeclaratorSyntax node )
		{
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.ArgumentList );
			this.Visit( node.Initializer );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitEqualsValueClause( EqualsValueClauseSyntax node )
		{
			this.VisitTrivialToken( node.EqualsToken );
			this.Visit( node.Value );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitSingleVariableDesignation( SingleVariableDesignationSyntax node )
		{
			this.VisitNonTrivialToken( node.Identifier );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitDiscardDesignation( DiscardDesignationSyntax node )
		{
			this.VisitTrivialToken( node.UnderscoreToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitParenthesizedVariableDesignation( ParenthesizedVariableDesignationSyntax node )
		{
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Variables );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitExpressionStatement( ExpressionStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitEmptyStatement( EmptyStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitLabeledStatement( LabeledStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitNonTrivialToken( node.Identifier );
			this.VisitTrivialToken( node.ColonToken );
			this.Visit( node.Statement );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitGotoStatement( GotoStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.GotoKeyword );
			this.VisitTrivialToken( node.CaseOrDefaultKeyword );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitBreakStatement( BreakStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.BreakKeyword );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitContinueStatement( ContinueStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.ContinueKeyword );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitReturnStatement( ReturnStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.ReturnKeyword );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitThrowStatement( ThrowStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.ThrowKeyword );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitYieldStatement( YieldStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.YieldKeyword );
			this.VisitTrivialToken( node.ReturnOrBreakKeyword );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitWhileStatement( WhileStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.WhileKeyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Condition );
			this.VisitTrivialToken( node.CloseParenToken );
			this.Visit( node.Statement );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitDoStatement( DoStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.DoKeyword );
			this.Visit( node.Statement );
			this.VisitTrivialToken( node.WhileKeyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Condition );
			this.VisitTrivialToken( node.CloseParenToken );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitForStatement( ForStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.ForKeyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.VisitTrivialToken( node.FirstSemicolonToken );
			this.Visit( node.Condition );
			this.VisitTrivialToken( node.SecondSemicolonToken );
			this.Visit( node.Incrementors );
			this.VisitTrivialToken( node.CloseParenToken );
			this.Visit( node.Statement );
			this.Visit( node.Declaration );
			this.Visit( node.Initializers );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitForEachStatement( ForEachStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.AwaitKeyword );
			this.VisitTrivialToken( node.ForEachKeyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Type );
			this.VisitNonTrivialToken( node.Identifier );
			this.VisitTrivialToken( node.InKeyword );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.CloseParenToken );
			this.Visit( node.Statement );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitForEachVariableStatement( ForEachVariableStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.AwaitKeyword );
			this.VisitTrivialToken( node.ForEachKeyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Variable );
			this.VisitTrivialToken( node.InKeyword );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.CloseParenToken );
			this.Visit( node.Statement );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitUsingStatement( UsingStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.AwaitKeyword );
			this.VisitTrivialToken( node.UsingKeyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.VisitTrivialToken( node.CloseParenToken );
			this.Visit( node.Statement );
			this.Visit( node.Declaration );
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitFixedStatement( FixedStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.FixedKeyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Declaration );
			this.VisitTrivialToken( node.CloseParenToken );
			this.Visit( node.Statement );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitCheckedStatement( CheckedStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.Keyword );
			this.Visit( node.Block );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitUnsafeStatement( UnsafeStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.UnsafeKeyword );
			this.Visit( node.Block );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitLockStatement( LockStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.LockKeyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.CloseParenToken );
			this.Visit( node.Statement );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitIfStatement( IfStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.IfKeyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Condition );
			this.VisitTrivialToken( node.CloseParenToken );
			this.Visit( node.Statement );
			this.Visit( node.Else );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitElseClause( ElseClauseSyntax node )
		{
			this.VisitTrivialToken( node.ElseKeyword );
			this.Visit( node.Statement );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitSwitchStatement( SwitchStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.SwitchKeyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Expression );
			this.VisitTrivialToken( node.CloseParenToken );
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Sections );
			this.VisitTrivialToken( node.CloseBraceToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitSwitchSection( SwitchSectionSyntax node )
		{
			this.Visit( node.Labels );
			this.Visit( node.Statements );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitCasePatternSwitchLabel( CasePatternSwitchLabelSyntax node )
		{
			this.VisitTrivialToken( node.Keyword );
			this.Visit( node.Pattern );
			this.Visit( node.WhenClause );
			this.VisitTrivialToken( node.ColonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitCaseSwitchLabel( CaseSwitchLabelSyntax node )
		{
			this.VisitTrivialToken( node.Keyword );
			this.Visit( node.Value );
			this.VisitTrivialToken( node.ColonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitDefaultSwitchLabel( DefaultSwitchLabelSyntax node )
		{
			this.VisitTrivialToken( node.Keyword );
			this.VisitTrivialToken( node.ColonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitSwitchExpression( SwitchExpressionSyntax node )
		{
			this.Visit( node.GoverningExpression );
			this.VisitTrivialToken( node.SwitchKeyword );
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Arms );
			this.VisitTrivialToken( node.CloseBraceToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitSwitchExpressionArm( SwitchExpressionArmSyntax node )
		{
			this.Visit( node.Pattern );
			this.Visit( node.WhenClause );
			this.VisitTrivialToken( node.EqualsGreaterThanToken );
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitTryStatement( TryStatementSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.TryKeyword );
			this.Visit( node.Block );
			this.Visit( node.Catches );
			this.Visit( node.Finally );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitCatchClause( CatchClauseSyntax node )
		{
			this.VisitTrivialToken( node.CatchKeyword );
			this.Visit( node.Declaration );
			this.Visit( node.Filter );
			this.Visit( node.Block );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitCatchDeclaration( CatchDeclarationSyntax node )
		{
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Type );
			this.VisitNonTrivialToken( node.Identifier );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitCatchFilterClause( CatchFilterClauseSyntax node )
		{
			this.VisitTrivialToken( node.WhenKeyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.FilterExpression );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitFinallyClause( FinallyClauseSyntax node )
		{
			this.VisitTrivialToken( node.FinallyKeyword );
			this.Visit( node.Block );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitCompilationUnit( CompilationUnitSyntax node )
		{
			this.Visit( node.Externs );
			this.Visit( node.Usings );
			this.Visit( node.AttributeLists );
			this.Visit( node.Members );
			this.VisitTrivialToken( node.EndOfFileToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitExternAliasDirective( ExternAliasDirectiveSyntax node )
		{
			this.VisitTrivialToken( node.ExternKeyword );
			this.VisitTrivialToken( node.AliasKeyword );
			this.VisitNonTrivialToken( node.Identifier );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitUsingDirective( UsingDirectiveSyntax node )
		{
			this.VisitTrivialToken( node.GlobalKeyword );
			this.VisitTrivialToken( node.UsingKeyword );
			this.Visit( node.Name );
			this.VisitTrivialToken( node.SemicolonToken );
			this.VisitTrivialToken( node.StaticKeyword );
			this.Visit( node.Alias );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitNamespaceDeclaration( NamespaceDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitTrivialToken( node.NamespaceKeyword );
			this.Visit( node.Name );
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Externs );
			this.Visit( node.Usings );
			this.Visit( node.Members );
			this.VisitTrivialToken( node.CloseBraceToken );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitFileScopedNamespaceDeclaration( FileScopedNamespaceDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitTrivialToken( node.NamespaceKeyword );
			this.Visit( node.Name );
			this.VisitTrivialToken( node.SemicolonToken );
			this.Visit( node.Externs );
			this.Visit( node.Usings );
			this.Visit( node.Members );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitAttributeList( AttributeListSyntax node )
		{
			this.VisitTrivialToken( node.OpenBracketToken );
			this.Visit( node.Target );
			this.Visit( node.Attributes );
			this.VisitTrivialToken( node.CloseBracketToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitAttributeTargetSpecifier( AttributeTargetSpecifierSyntax node )
		{
			this.VisitTrivialToken( node.Identifier );
			this.VisitTrivialToken( node.ColonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitAttribute( AttributeSyntax node )
		{
			this.Visit( node.Name );
			this.Visit( node.ArgumentList );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitAttributeArgumentList( AttributeArgumentListSyntax node )
		{
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Arguments );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitAttributeArgument( AttributeArgumentSyntax node )
		{
			this.Visit( node.Expression );
			this.Visit( node.NameEquals );
			this.Visit( node.NameColon );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitNameEquals( NameEqualsSyntax node )
		{
			this.Visit( node.Name );
			this.VisitTrivialToken( node.EqualsToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitTypeParameterList( TypeParameterListSyntax node )
		{
			this.VisitTrivialToken( node.LessThanToken );
			this.Visit( node.Parameters );
			this.VisitTrivialToken( node.GreaterThanToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitTypeParameter( TypeParameterSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.VisitTrivialToken( node.VarianceKeyword );
			this.VisitNonTrivialToken( node.Identifier );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitClassDeclaration( ClassDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitTrivialToken( node.Keyword );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.TypeParameterList );
			this.Visit( node.BaseList );
			this.Visit( node.ConstraintClauses );
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Members );
			this.VisitTrivialToken( node.CloseBraceToken );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitStructDeclaration( StructDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitTrivialToken( node.Keyword );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.TypeParameterList );
			this.Visit( node.BaseList );
			this.Visit( node.ConstraintClauses );
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Members );
			this.VisitTrivialToken( node.CloseBraceToken );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitInterfaceDeclaration( InterfaceDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitTrivialToken( node.Keyword );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.TypeParameterList );
			this.Visit( node.BaseList );
			this.Visit( node.ConstraintClauses );
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Members );
			this.VisitTrivialToken( node.CloseBraceToken );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitRecordDeclaration( RecordDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitTrivialToken( node.Keyword );
			this.VisitTrivialToken( node.ClassOrStructKeyword );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.TypeParameterList );
			this.Visit( node.ParameterList );
			this.Visit( node.BaseList );
			this.Visit( node.ConstraintClauses );
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Members );
			this.VisitTrivialToken( node.CloseBraceToken );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitEnumDeclaration( EnumDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitTrivialToken( node.EnumKeyword );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.BaseList );
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Members );
			this.VisitTrivialToken( node.CloseBraceToken );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitDelegateDeclaration( DelegateDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitTrivialToken( node.DelegateKeyword );
			this.Visit( node.ReturnType );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.TypeParameterList );
			this.Visit( node.ParameterList );
			this.Visit( node.ConstraintClauses );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitEnumMemberDeclaration( EnumMemberDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.EqualsValue );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitBaseList( BaseListSyntax node )
		{
			this.VisitTrivialToken( node.ColonToken );
			this.Visit( node.Types );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitSimpleBaseType( SimpleBaseTypeSyntax node )
		{
			this.Visit( node.Type );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitPrimaryConstructorBaseType( PrimaryConstructorBaseTypeSyntax node )
		{
			this.Visit( node.Type );
			this.Visit( node.ArgumentList );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitTypeParameterConstraintClause( TypeParameterConstraintClauseSyntax node )
		{
			this.VisitTrivialToken( node.WhereKeyword );
			this.Visit( node.Name );
			this.VisitTrivialToken( node.ColonToken );
			this.Visit( node.Constraints );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitConstructorConstraint( ConstructorConstraintSyntax node )
		{
			this.VisitTrivialToken( node.NewKeyword );
			this.VisitTrivialToken( node.OpenParenToken );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitClassOrStructConstraint( ClassOrStructConstraintSyntax node )
		{
			this.VisitTrivialToken( node.ClassOrStructKeyword );
			this.VisitTrivialToken( node.QuestionToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitTypeConstraint( TypeConstraintSyntax node )
		{
			this.Visit( node.Type );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitDefaultConstraint( DefaultConstraintSyntax node )
		{
			this.VisitTrivialToken( node.DefaultKeyword );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitFieldDeclaration( FieldDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.Visit( node.Declaration );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitEventFieldDeclaration( EventFieldDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitTrivialToken( node.EventKeyword );
			this.Visit( node.Declaration );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitExplicitInterfaceSpecifier( ExplicitInterfaceSpecifierSyntax node )
		{
			this.Visit( node.Name );
			this.VisitTrivialToken( node.DotToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitMethodDeclaration( MethodDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.Visit( node.ReturnType );
			this.Visit( node.ExplicitInterfaceSpecifier );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.TypeParameterList );
			this.Visit( node.ParameterList );
			this.Visit( node.ConstraintClauses );
			this.Visit( node.Body );
			this.Visit( node.ExpressionBody );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitOperatorDeclaration( OperatorDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.Visit( node.ReturnType );
			this.Visit( node.ExplicitInterfaceSpecifier );
			this.VisitTrivialToken( node.OperatorKeyword );
			this.VisitTrivialToken( node.CheckedKeyword );
			this.VisitTrivialToken( node.OperatorToken );
			this.Visit( node.ParameterList );
			this.Visit( node.Body );
			this.Visit( node.ExpressionBody );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitConversionOperatorDeclaration( ConversionOperatorDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitTrivialToken( node.ImplicitOrExplicitKeyword );
			this.Visit( node.ExplicitInterfaceSpecifier );
			this.VisitTrivialToken( node.OperatorKeyword );
			this.VisitTrivialToken( node.CheckedKeyword );
			this.Visit( node.Type );
			this.Visit( node.ParameterList );
			this.Visit( node.Body );
			this.Visit( node.ExpressionBody );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitConstructorDeclaration( ConstructorDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.ParameterList );
			this.Visit( node.Initializer );
			this.Visit( node.Body );
			this.Visit( node.ExpressionBody );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitConstructorInitializer( ConstructorInitializerSyntax node )
		{
			this.VisitTrivialToken( node.ColonToken );
			this.VisitTrivialToken( node.ThisOrBaseKeyword );
			this.Visit( node.ArgumentList );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitDestructorDeclaration( DestructorDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitTrivialToken( node.TildeToken );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.ParameterList );
			this.Visit( node.Body );
			this.Visit( node.ExpressionBody );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitPropertyDeclaration( PropertyDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.Visit( node.Type );
			this.Visit( node.ExplicitInterfaceSpecifier );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.AccessorList );
			this.VisitTrivialToken( node.SemicolonToken );
			this.Visit( node.ExpressionBody );
			this.Visit( node.Initializer );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitArrowExpressionClause( ArrowExpressionClauseSyntax node )
		{
			this.VisitTrivialToken( node.ArrowToken );
			this.Visit( node.Expression );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitEventDeclaration( EventDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitTrivialToken( node.EventKeyword );
			this.Visit( node.Type );
			this.Visit( node.ExplicitInterfaceSpecifier );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.AccessorList );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitIndexerDeclaration( IndexerDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.Visit( node.Type );
			this.Visit( node.ExplicitInterfaceSpecifier );
			this.VisitTrivialToken( node.ThisKeyword );
			this.Visit( node.ParameterList );
			this.Visit( node.AccessorList );
			this.Visit( node.ExpressionBody );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitAccessorList( AccessorListSyntax node )
		{
			this.VisitTrivialToken( node.OpenBraceToken );
			this.Visit( node.Accessors );
			this.VisitTrivialToken( node.CloseBraceToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitAccessorDeclaration( AccessorDeclarationSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.VisitNonTrivialToken( node.Keyword );
			this.Visit( node.Body );
			this.Visit( node.ExpressionBody );
			this.VisitTrivialToken( node.SemicolonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitParameterList( ParameterListSyntax node )
		{
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Parameters );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitBracketedParameterList( BracketedParameterListSyntax node )
		{
			this.VisitTrivialToken( node.OpenBracketToken );
			this.Visit( node.Parameters );
			this.VisitTrivialToken( node.CloseBracketToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitParameter( ParameterSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.Visit( node.Type );
			this.VisitNonTrivialToken( node.Identifier );
			this.Visit( node.Default );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitFunctionPointerParameter( FunctionPointerParameterSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.Visit( node.Type );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitIncompleteMember( IncompleteMemberSyntax node )
		{
			this.Visit( node.AttributeLists );
			this.Visit( node.Modifiers );
			this.Visit( node.Type );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitSkippedTokensTrivia( SkippedTokensTriviaSyntax node )
		{
			this.Visit( node.Tokens );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitDocumentationCommentTrivia( DocumentationCommentTriviaSyntax node )
		{
			this.Visit( node.Content );
			this.VisitTrivialToken( node.EndOfComment );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitTypeCref( TypeCrefSyntax node )
		{
			this.Visit( node.Type );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitQualifiedCref( QualifiedCrefSyntax node )
		{
			this.Visit( node.Container );
			this.VisitTrivialToken( node.DotToken );
			this.Visit( node.Member );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitNameMemberCref( NameMemberCrefSyntax node )
		{
			this.Visit( node.Name );
			this.Visit( node.Parameters );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitIndexerMemberCref( IndexerMemberCrefSyntax node )
		{
			this.VisitTrivialToken( node.ThisKeyword );
			this.Visit( node.Parameters );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitOperatorMemberCref( OperatorMemberCrefSyntax node )
		{
			this.VisitTrivialToken( node.OperatorKeyword );
			this.VisitTrivialToken( node.CheckedKeyword );
			this.VisitTrivialToken( node.OperatorToken );
			this.Visit( node.Parameters );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitConversionOperatorMemberCref( ConversionOperatorMemberCrefSyntax node )
		{
			this.VisitTrivialToken( node.ImplicitOrExplicitKeyword );
			this.VisitTrivialToken( node.OperatorKeyword );
			this.VisitTrivialToken( node.CheckedKeyword );
			this.Visit( node.Type );
			this.Visit( node.Parameters );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitCrefParameterList( CrefParameterListSyntax node )
		{
			this.VisitTrivialToken( node.OpenParenToken );
			this.Visit( node.Parameters );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitCrefBracketedParameterList( CrefBracketedParameterListSyntax node )
		{
			this.VisitTrivialToken( node.OpenBracketToken );
			this.Visit( node.Parameters );
			this.VisitTrivialToken( node.CloseBracketToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitCrefParameter( CrefParameterSyntax node )
		{
			this.VisitTrivialToken( node.RefKindKeyword );
			this.Visit( node.Type );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitXmlElement( XmlElementSyntax node )
		{
			this.Visit( node.StartTag );
			this.Visit( node.Content );
			this.Visit( node.EndTag );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitXmlElementStartTag( XmlElementStartTagSyntax node )
		{
			this.VisitTrivialToken( node.LessThanToken );
			this.Visit( node.Name );
			this.Visit( node.Attributes );
			this.VisitTrivialToken( node.GreaterThanToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitXmlElementEndTag( XmlElementEndTagSyntax node )
		{
			this.VisitTrivialToken( node.LessThanSlashToken );
			this.Visit( node.Name );
			this.VisitTrivialToken( node.GreaterThanToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitXmlEmptyElement( XmlEmptyElementSyntax node )
		{
			this.VisitTrivialToken( node.LessThanToken );
			this.Visit( node.Name );
			this.Visit( node.Attributes );
			this.VisitTrivialToken( node.SlashGreaterThanToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitXmlName( XmlNameSyntax node )
		{
			this.Visit( node.Prefix );
			this.VisitNonTrivialToken( node.LocalName );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitXmlPrefix( XmlPrefixSyntax node )
		{
			this.VisitNonTrivialToken( node.Prefix );
			this.VisitTrivialToken( node.ColonToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitXmlTextAttribute( XmlTextAttributeSyntax node )
		{
			this.Visit( node.Name );
			this.VisitTrivialToken( node.EqualsToken );
			this.VisitTrivialToken( node.StartQuoteToken );
			this.Visit( node.TextTokens );
			this.VisitTrivialToken( node.EndQuoteToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitXmlCrefAttribute( XmlCrefAttributeSyntax node )
		{
			this.Visit( node.Name );
			this.VisitTrivialToken( node.EqualsToken );
			this.VisitTrivialToken( node.StartQuoteToken );
			this.Visit( node.Cref );
			this.VisitTrivialToken( node.EndQuoteToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitXmlNameAttribute( XmlNameAttributeSyntax node )
		{
			this.Visit( node.Name );
			this.VisitTrivialToken( node.EqualsToken );
			this.VisitTrivialToken( node.StartQuoteToken );
			this.Visit( node.Identifier );
			this.VisitTrivialToken( node.EndQuoteToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitXmlText( XmlTextSyntax node )
		{
			this.Visit( node.TextTokens );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitXmlCDataSection( XmlCDataSectionSyntax node )
		{
			this.VisitTrivialToken( node.StartCDataToken );
			this.Visit( node.TextTokens );
			this.VisitTrivialToken( node.EndCDataToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitXmlProcessingInstruction( XmlProcessingInstructionSyntax node )
		{
			this.VisitTrivialToken( node.StartProcessingInstructionToken );
			this.Visit( node.Name );
			this.Visit( node.TextTokens );
			this.VisitTrivialToken( node.EndProcessingInstructionToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitXmlComment( XmlCommentSyntax node )
		{
			this.VisitTrivialToken( node.LessThanExclamationMinusMinusToken );
			this.Visit( node.TextTokens );
			this.VisitTrivialToken( node.MinusMinusGreaterThanToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitIfDirectiveTrivia( IfDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.IfKeyword );
			this.Visit( node.Condition );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitElifDirectiveTrivia( ElifDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.ElifKeyword );
			this.Visit( node.Condition );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitElseDirectiveTrivia( ElseDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.ElseKeyword );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitEndIfDirectiveTrivia( EndIfDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.EndIfKeyword );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitRegionDirectiveTrivia( RegionDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.RegionKeyword );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitEndRegionDirectiveTrivia( EndRegionDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.EndRegionKeyword );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitErrorDirectiveTrivia( ErrorDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.ErrorKeyword );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitWarningDirectiveTrivia( WarningDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.WarningKeyword );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitBadDirectiveTrivia( BadDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.Identifier );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitDefineDirectiveTrivia( DefineDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.DefineKeyword );
			this.VisitNonTrivialToken( node.Name );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitUndefDirectiveTrivia( UndefDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.UndefKeyword );
			this.VisitNonTrivialToken( node.Name );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitLineDirectiveTrivia( LineDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.LineKeyword );
			this.VisitNonTrivialToken( node.Line );
			this.VisitNonTrivialToken( node.File );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitLineDirectivePosition( LineDirectivePositionSyntax node )
		{
			this.VisitTrivialToken( node.OpenParenToken );
			this.VisitNonTrivialToken( node.Line );
			this.VisitTrivialToken( node.CommaToken );
			this.VisitNonTrivialToken( node.Character );
			this.VisitTrivialToken( node.CloseParenToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitLineSpanDirectiveTrivia( LineSpanDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.LineKeyword );
			this.Visit( node.Start );
			this.VisitTrivialToken( node.MinusToken );
			this.Visit( node.End );
			this.VisitNonTrivialToken( node.CharacterOffset );
			this.VisitNonTrivialToken( node.File );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitPragmaWarningDirectiveTrivia( PragmaWarningDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.PragmaKeyword );
			this.VisitTrivialToken( node.WarningKeyword );
			this.VisitTrivialToken( node.DisableOrRestoreKeyword );
			this.Visit( node.ErrorCodes );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitPragmaChecksumDirectiveTrivia( PragmaChecksumDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.PragmaKeyword );
			this.VisitTrivialToken( node.ChecksumKeyword );
			this.VisitNonTrivialToken( node.File );
			this.VisitNonTrivialToken( node.Guid );
			this.VisitNonTrivialToken( node.Bytes );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitReferenceDirectiveTrivia( ReferenceDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.ReferenceKeyword );
			this.VisitNonTrivialToken( node.File );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitLoadDirectiveTrivia( LoadDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.LoadKeyword );
			this.VisitNonTrivialToken( node.File );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitShebangDirectiveTrivia( ShebangDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.ExclamationToken );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
		[ExcludeFromCodeCoverage]
		public override void VisitNullableDirectiveTrivia( NullableDirectiveTriviaSyntax node )
		{
			this.VisitTrivialToken( node.HashToken );
			this.VisitTrivialToken( node.NullableKeyword );
			this.VisitTrivialToken( node.SettingToken );
			this.VisitTrivialToken( node.TargetToken );
			this.VisitTrivialToken( node.EndOfDirectiveToken );
		}
	}
}
