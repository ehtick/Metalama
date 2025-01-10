// Copyright (c) SharpCrafters s.r.o. See the LICENSE.md file in the root directory of this repository root for details.

#pragma warning disable CS8669 // Nullability
#pragma warning disable IDE0005, IDE0040, SA1013, SA1027, SA1205, SA1210, SA1216, SA1508 // Formatting
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Metalama.Framework.Engine.CompileTime;
using Metalama.Framework.Engine.Utilities.Roslyn;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Metalama.Framework.Engine.Utilities.Roslyn;

public static class SyntaxNodePartialUpdateExtensions
{
	public readonly struct Option<T>( T value )
	{
		public T? GetValueOrDefault() => value;
		public bool HasValue { get; } = true;
		public static implicit operator Option<T>( T value ) => new( value );
	}
	public static IdentifierNameSyntax PartialUpdate(
		this IdentifierNameSyntax node,
		Option<SyntaxToken> identifier = default )
		=> node.Update(
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier );
	public static QualifiedNameSyntax PartialUpdate(
		this QualifiedNameSyntax node,
		Option<NameSyntax> left = default,
		Option<SyntaxToken> dotToken = default,
		Option<SimpleNameSyntax> right = default )
		=> node.Update(
			left.HasValue ? left.GetValueOrDefault()! : node.Left,
			dotToken.HasValue ? dotToken.GetValueOrDefault()! : node.DotToken,
			right.HasValue ? right.GetValueOrDefault()! : node.Right );
	public static GenericNameSyntax PartialUpdate(
		this GenericNameSyntax node,
		Option<SyntaxToken> identifier = default,
		Option<TypeArgumentListSyntax> typeArgumentList = default )
		=> node.Update(
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			typeArgumentList.HasValue ? typeArgumentList.GetValueOrDefault()! : node.TypeArgumentList );
	public static TypeArgumentListSyntax PartialUpdate(
		this TypeArgumentListSyntax node,
		Option<SyntaxToken> lessThanToken = default,
		Option<SeparatedSyntaxList<TypeSyntax>> arguments = default,
		Option<SyntaxToken> greaterThanToken = default )
		=> node.Update(
			lessThanToken.HasValue ? lessThanToken.GetValueOrDefault()! : node.LessThanToken,
			arguments.HasValue ? arguments.GetValueOrDefault()! : node.Arguments,
			greaterThanToken.HasValue ? greaterThanToken.GetValueOrDefault()! : node.GreaterThanToken );
	public static AliasQualifiedNameSyntax PartialUpdate(
		this AliasQualifiedNameSyntax node,
		Option<IdentifierNameSyntax> alias = default,
		Option<SyntaxToken> colonColonToken = default,
		Option<SimpleNameSyntax> name = default )
		=> node.Update(
			alias.HasValue ? alias.GetValueOrDefault()! : node.Alias,
			colonColonToken.HasValue ? colonColonToken.GetValueOrDefault()! : node.ColonColonToken,
			name.HasValue ? name.GetValueOrDefault()! : node.Name );
	public static PredefinedTypeSyntax PartialUpdate(
		this PredefinedTypeSyntax node,
		Option<SyntaxToken> keyword = default )
		=> node.Update(
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword );
	public static ArrayTypeSyntax PartialUpdate(
		this ArrayTypeSyntax node,
		Option<TypeSyntax> elementType = default,
		Option<SyntaxList<ArrayRankSpecifierSyntax>> rankSpecifiers = default )
		=> node.Update(
			elementType.HasValue ? elementType.GetValueOrDefault()! : node.ElementType,
			rankSpecifiers.HasValue ? rankSpecifiers.GetValueOrDefault()! : node.RankSpecifiers );
	public static ArrayRankSpecifierSyntax PartialUpdate(
		this ArrayRankSpecifierSyntax node,
		Option<SyntaxToken> openBracketToken = default,
		Option<SeparatedSyntaxList<ExpressionSyntax>> sizes = default,
		Option<SyntaxToken> closeBracketToken = default )
		=> node.Update(
			openBracketToken.HasValue ? openBracketToken.GetValueOrDefault()! : node.OpenBracketToken,
			sizes.HasValue ? sizes.GetValueOrDefault()! : node.Sizes,
			closeBracketToken.HasValue ? closeBracketToken.GetValueOrDefault()! : node.CloseBracketToken );
	public static PointerTypeSyntax PartialUpdate(
		this PointerTypeSyntax node,
		Option<TypeSyntax> elementType = default,
		Option<SyntaxToken> asteriskToken = default )
		=> node.Update(
			elementType.HasValue ? elementType.GetValueOrDefault()! : node.ElementType,
			asteriskToken.HasValue ? asteriskToken.GetValueOrDefault()! : node.AsteriskToken );
	public static FunctionPointerTypeSyntax PartialUpdate(
		this FunctionPointerTypeSyntax node,
		Option<SyntaxToken> delegateKeyword = default,
		Option<SyntaxToken> asteriskToken = default,
		Option<FunctionPointerCallingConventionSyntax?> callingConvention = default,
		Option<FunctionPointerParameterListSyntax> parameterList = default )
		=> node.Update(
			delegateKeyword.HasValue ? delegateKeyword.GetValueOrDefault()! : node.DelegateKeyword,
			asteriskToken.HasValue ? asteriskToken.GetValueOrDefault()! : node.AsteriskToken,
			callingConvention.HasValue ? callingConvention.GetValueOrDefault()! : node.CallingConvention,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList );
	public static FunctionPointerParameterListSyntax PartialUpdate(
		this FunctionPointerParameterListSyntax node,
		Option<SyntaxToken> lessThanToken = default,
		Option<SeparatedSyntaxList<FunctionPointerParameterSyntax>> parameters = default,
		Option<SyntaxToken> greaterThanToken = default )
		=> node.Update(
			lessThanToken.HasValue ? lessThanToken.GetValueOrDefault()! : node.LessThanToken,
			parameters.HasValue ? parameters.GetValueOrDefault()! : node.Parameters,
			greaterThanToken.HasValue ? greaterThanToken.GetValueOrDefault()! : node.GreaterThanToken );
	public static FunctionPointerCallingConventionSyntax PartialUpdate(
		this FunctionPointerCallingConventionSyntax node,
		Option<SyntaxToken> managedOrUnmanagedKeyword = default,
		Option<FunctionPointerUnmanagedCallingConventionListSyntax?> unmanagedCallingConventionList = default )
		=> node.Update(
			managedOrUnmanagedKeyword.HasValue ? managedOrUnmanagedKeyword.GetValueOrDefault()! : node.ManagedOrUnmanagedKeyword,
			unmanagedCallingConventionList.HasValue ? unmanagedCallingConventionList.GetValueOrDefault()! : node.UnmanagedCallingConventionList );
	public static FunctionPointerUnmanagedCallingConventionListSyntax PartialUpdate(
		this FunctionPointerUnmanagedCallingConventionListSyntax node,
		Option<SyntaxToken> openBracketToken = default,
		Option<SeparatedSyntaxList<FunctionPointerUnmanagedCallingConventionSyntax>> callingConventions = default,
		Option<SyntaxToken> closeBracketToken = default )
		=> node.Update(
			openBracketToken.HasValue ? openBracketToken.GetValueOrDefault()! : node.OpenBracketToken,
			callingConventions.HasValue ? callingConventions.GetValueOrDefault()! : node.CallingConventions,
			closeBracketToken.HasValue ? closeBracketToken.GetValueOrDefault()! : node.CloseBracketToken );
	public static FunctionPointerUnmanagedCallingConventionSyntax PartialUpdate(
		this FunctionPointerUnmanagedCallingConventionSyntax node,
		Option<SyntaxToken> name = default )
		=> node.Update(
			name.HasValue ? name.GetValueOrDefault()! : node.Name );
	public static NullableTypeSyntax PartialUpdate(
		this NullableTypeSyntax node,
		Option<TypeSyntax> elementType = default,
		Option<SyntaxToken> questionToken = default )
		=> node.Update(
			elementType.HasValue ? elementType.GetValueOrDefault()! : node.ElementType,
			questionToken.HasValue ? questionToken.GetValueOrDefault()! : node.QuestionToken );
	public static TupleTypeSyntax PartialUpdate(
		this TupleTypeSyntax node,
		Option<SyntaxToken> openParenToken = default,
		Option<SeparatedSyntaxList<TupleElementSyntax>> elements = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			elements.HasValue ? elements.GetValueOrDefault()! : node.Elements,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static TupleElementSyntax PartialUpdate(
		this TupleElementSyntax node,
		Option<TypeSyntax> type = default,
		Option<SyntaxToken> identifier = default )
		=> node.Update(
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier );
	public static OmittedTypeArgumentSyntax PartialUpdate(
		this OmittedTypeArgumentSyntax node,
		Option<SyntaxToken> omittedTypeArgumentToken = default )
		=> node.Update(
			omittedTypeArgumentToken.HasValue ? omittedTypeArgumentToken.GetValueOrDefault()! : node.OmittedTypeArgumentToken );
	public static RefTypeSyntax PartialUpdate(
		this RefTypeSyntax node,
		Option<SyntaxToken> refKeyword = default,
		Option<SyntaxToken> readOnlyKeyword = default,
		Option<TypeSyntax> type = default )
		=> node.Update(
			refKeyword.HasValue ? refKeyword.GetValueOrDefault()! : node.RefKeyword,
			readOnlyKeyword.HasValue ? readOnlyKeyword.GetValueOrDefault()! : node.ReadOnlyKeyword,
			type.HasValue ? type.GetValueOrDefault()! : node.Type );
	public static ScopedTypeSyntax PartialUpdate(
		this ScopedTypeSyntax node,
		Option<SyntaxToken> scopedKeyword = default,
		Option<TypeSyntax> type = default )
		=> node.Update(
			scopedKeyword.HasValue ? scopedKeyword.GetValueOrDefault()! : node.ScopedKeyword,
			type.HasValue ? type.GetValueOrDefault()! : node.Type );
	public static ParenthesizedExpressionSyntax PartialUpdate(
		this ParenthesizedExpressionSyntax node,
		Option<SyntaxToken> openParenToken = default,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static TupleExpressionSyntax PartialUpdate(
		this TupleExpressionSyntax node,
		Option<SyntaxToken> openParenToken = default,
		Option<SeparatedSyntaxList<ArgumentSyntax>> arguments = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			arguments.HasValue ? arguments.GetValueOrDefault()! : node.Arguments,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static PrefixUnaryExpressionSyntax PartialUpdate(
		this PrefixUnaryExpressionSyntax node,
		Option<SyntaxToken> operatorToken = default,
		Option<ExpressionSyntax> operand = default )
		=> node.Update(
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken,
			operand.HasValue ? operand.GetValueOrDefault()! : node.Operand );
	public static AwaitExpressionSyntax PartialUpdate(
		this AwaitExpressionSyntax node,
		Option<SyntaxToken> awaitKeyword = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			awaitKeyword.HasValue ? awaitKeyword.GetValueOrDefault()! : node.AwaitKeyword,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static PostfixUnaryExpressionSyntax PartialUpdate(
		this PostfixUnaryExpressionSyntax node,
		Option<ExpressionSyntax> operand = default,
		Option<SyntaxToken> operatorToken = default )
		=> node.Update(
			operand.HasValue ? operand.GetValueOrDefault()! : node.Operand,
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken );
	public static MemberAccessExpressionSyntax PartialUpdate(
		this MemberAccessExpressionSyntax node,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> operatorToken = default,
		Option<SimpleNameSyntax> name = default )
		=> node.Update(
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken,
			name.HasValue ? name.GetValueOrDefault()! : node.Name );
	public static ConditionalAccessExpressionSyntax PartialUpdate(
		this ConditionalAccessExpressionSyntax node,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> operatorToken = default,
		Option<ExpressionSyntax> whenNotNull = default )
		=> node.Update(
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken,
			whenNotNull.HasValue ? whenNotNull.GetValueOrDefault()! : node.WhenNotNull );
	public static MemberBindingExpressionSyntax PartialUpdate(
		this MemberBindingExpressionSyntax node,
		Option<SyntaxToken> operatorToken = default,
		Option<SimpleNameSyntax> name = default )
		=> node.Update(
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken,
			name.HasValue ? name.GetValueOrDefault()! : node.Name );
	public static ElementBindingExpressionSyntax PartialUpdate(
		this ElementBindingExpressionSyntax node,
		Option<BracketedArgumentListSyntax> argumentList = default )
		=> node.Update(
			argumentList.HasValue ? argumentList.GetValueOrDefault()! : node.ArgumentList );
	public static RangeExpressionSyntax PartialUpdate(
		this RangeExpressionSyntax node,
		Option<ExpressionSyntax?> leftOperand = default,
		Option<SyntaxToken> operatorToken = default,
		Option<ExpressionSyntax?> rightOperand = default )
		=> node.Update(
			leftOperand.HasValue ? leftOperand.GetValueOrDefault()! : node.LeftOperand,
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken,
			rightOperand.HasValue ? rightOperand.GetValueOrDefault()! : node.RightOperand );
	public static ImplicitElementAccessSyntax PartialUpdate(
		this ImplicitElementAccessSyntax node,
		Option<BracketedArgumentListSyntax> argumentList = default )
		=> node.Update(
			argumentList.HasValue ? argumentList.GetValueOrDefault()! : node.ArgumentList );
	public static BinaryExpressionSyntax PartialUpdate(
		this BinaryExpressionSyntax node,
		Option<ExpressionSyntax> left = default,
		Option<SyntaxToken> operatorToken = default,
		Option<ExpressionSyntax> right = default )
		=> node.Update(
			left.HasValue ? left.GetValueOrDefault()! : node.Left,
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken,
			right.HasValue ? right.GetValueOrDefault()! : node.Right );
	public static AssignmentExpressionSyntax PartialUpdate(
		this AssignmentExpressionSyntax node,
		Option<ExpressionSyntax> left = default,
		Option<SyntaxToken> operatorToken = default,
		Option<ExpressionSyntax> right = default )
		=> node.Update(
			left.HasValue ? left.GetValueOrDefault()! : node.Left,
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken,
			right.HasValue ? right.GetValueOrDefault()! : node.Right );
	public static ConditionalExpressionSyntax PartialUpdate(
		this ConditionalExpressionSyntax node,
		Option<ExpressionSyntax> condition = default,
		Option<SyntaxToken> questionToken = default,
		Option<ExpressionSyntax> whenTrue = default,
		Option<SyntaxToken> colonToken = default,
		Option<ExpressionSyntax> whenFalse = default )
		=> node.Update(
			condition.HasValue ? condition.GetValueOrDefault()! : node.Condition,
			questionToken.HasValue ? questionToken.GetValueOrDefault()! : node.QuestionToken,
			whenTrue.HasValue ? whenTrue.GetValueOrDefault()! : node.WhenTrue,
			colonToken.HasValue ? colonToken.GetValueOrDefault()! : node.ColonToken,
			whenFalse.HasValue ? whenFalse.GetValueOrDefault()! : node.WhenFalse );
	public static ThisExpressionSyntax PartialUpdate(
		this ThisExpressionSyntax node,
		Option<SyntaxToken> token = default )
		=> node.Update(
			token.HasValue ? token.GetValueOrDefault()! : node.Token );
	public static BaseExpressionSyntax PartialUpdate(
		this BaseExpressionSyntax node,
		Option<SyntaxToken> token = default )
		=> node.Update(
			token.HasValue ? token.GetValueOrDefault()! : node.Token );
	public static LiteralExpressionSyntax PartialUpdate(
		this LiteralExpressionSyntax node,
		Option<SyntaxToken> token = default )
		=> node.Update(
			token.HasValue ? token.GetValueOrDefault()! : node.Token );
	public static MakeRefExpressionSyntax PartialUpdate(
		this MakeRefExpressionSyntax node,
		Option<SyntaxToken> keyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static RefTypeExpressionSyntax PartialUpdate(
		this RefTypeExpressionSyntax node,
		Option<SyntaxToken> keyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static RefValueExpressionSyntax PartialUpdate(
		this RefValueExpressionSyntax node,
		Option<SyntaxToken> keyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> comma = default,
		Option<TypeSyntax> type = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			comma.HasValue ? comma.GetValueOrDefault()! : node.Comma,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static CheckedExpressionSyntax PartialUpdate(
		this CheckedExpressionSyntax node,
		Option<SyntaxToken> keyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static DefaultExpressionSyntax PartialUpdate(
		this DefaultExpressionSyntax node,
		Option<SyntaxToken> keyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<TypeSyntax> type = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static TypeOfExpressionSyntax PartialUpdate(
		this TypeOfExpressionSyntax node,
		Option<SyntaxToken> keyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<TypeSyntax> type = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static SizeOfExpressionSyntax PartialUpdate(
		this SizeOfExpressionSyntax node,
		Option<SyntaxToken> keyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<TypeSyntax> type = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static InvocationExpressionSyntax PartialUpdate(
		this InvocationExpressionSyntax node,
		Option<ExpressionSyntax> expression = default,
		Option<ArgumentListSyntax> argumentList = default )
		=> node.Update(
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			argumentList.HasValue ? argumentList.GetValueOrDefault()! : node.ArgumentList );
	public static ElementAccessExpressionSyntax PartialUpdate(
		this ElementAccessExpressionSyntax node,
		Option<ExpressionSyntax> expression = default,
		Option<BracketedArgumentListSyntax> argumentList = default )
		=> node.Update(
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			argumentList.HasValue ? argumentList.GetValueOrDefault()! : node.ArgumentList );
	public static ArgumentListSyntax PartialUpdate(
		this ArgumentListSyntax node,
		Option<SyntaxToken> openParenToken = default,
		Option<SeparatedSyntaxList<ArgumentSyntax>> arguments = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			arguments.HasValue ? arguments.GetValueOrDefault()! : node.Arguments,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static BracketedArgumentListSyntax PartialUpdate(
		this BracketedArgumentListSyntax node,
		Option<SyntaxToken> openBracketToken = default,
		Option<SeparatedSyntaxList<ArgumentSyntax>> arguments = default,
		Option<SyntaxToken> closeBracketToken = default )
		=> node.Update(
			openBracketToken.HasValue ? openBracketToken.GetValueOrDefault()! : node.OpenBracketToken,
			arguments.HasValue ? arguments.GetValueOrDefault()! : node.Arguments,
			closeBracketToken.HasValue ? closeBracketToken.GetValueOrDefault()! : node.CloseBracketToken );
	public static ArgumentSyntax PartialUpdate(
		this ArgumentSyntax node,
		Option<NameColonSyntax?> nameColon = default,
		Option<SyntaxToken> refKindKeyword = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			nameColon.HasValue ? nameColon.GetValueOrDefault()! : node.NameColon,
			refKindKeyword.HasValue ? refKindKeyword.GetValueOrDefault()! : node.RefKindKeyword,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static ExpressionColonSyntax PartialUpdate(
		this ExpressionColonSyntax node,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> colonToken = default )
		=> node.Update(
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			colonToken.HasValue ? colonToken.GetValueOrDefault()! : node.ColonToken );
	public static NameColonSyntax PartialUpdate(
		this NameColonSyntax node,
		Option<IdentifierNameSyntax> name = default,
		Option<SyntaxToken> colonToken = default )
		=> node.Update(
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			colonToken.HasValue ? colonToken.GetValueOrDefault()! : node.ColonToken );
	public static DeclarationExpressionSyntax PartialUpdate(
		this DeclarationExpressionSyntax node,
		Option<TypeSyntax> type = default,
		Option<VariableDesignationSyntax> designation = default )
		=> node.Update(
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			designation.HasValue ? designation.GetValueOrDefault()! : node.Designation );
	public static CastExpressionSyntax PartialUpdate(
		this CastExpressionSyntax node,
		Option<SyntaxToken> openParenToken = default,
		Option<TypeSyntax> type = default,
		Option<SyntaxToken> closeParenToken = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static AnonymousMethodExpressionSyntax PartialUpdate(
		this AnonymousMethodExpressionSyntax node,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> delegateKeyword = default,
		Option<ParameterListSyntax?> parameterList = default,
		Option<BlockSyntax> block = default,
		Option<ExpressionSyntax?> expressionBody = default )
		=> node.Update(
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			delegateKeyword.HasValue ? delegateKeyword.GetValueOrDefault()! : node.DelegateKeyword,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			block.HasValue ? block.GetValueOrDefault()! : node.Block,
			expressionBody.HasValue ? expressionBody.GetValueOrDefault()! : node.ExpressionBody );
	public static SimpleLambdaExpressionSyntax PartialUpdate(
		this SimpleLambdaExpressionSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<ParameterSyntax> parameter = default,
		Option<SyntaxToken> arrowToken = default,
		Option<BlockSyntax?> block = default,
		Option<ExpressionSyntax?> expressionBody = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			parameter.HasValue ? parameter.GetValueOrDefault()! : node.Parameter,
			arrowToken.HasValue ? arrowToken.GetValueOrDefault()! : node.ArrowToken,
			block.HasValue ? block.GetValueOrDefault()! : node.Block,
			expressionBody.HasValue ? expressionBody.GetValueOrDefault()! : node.ExpressionBody );
	public static RefExpressionSyntax PartialUpdate(
		this RefExpressionSyntax node,
		Option<SyntaxToken> refKeyword = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			refKeyword.HasValue ? refKeyword.GetValueOrDefault()! : node.RefKeyword,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static ParenthesizedLambdaExpressionSyntax PartialUpdate(
		this ParenthesizedLambdaExpressionSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<TypeSyntax?> returnType = default,
		Option<ParameterListSyntax> parameterList = default,
		Option<SyntaxToken> arrowToken = default,
		Option<BlockSyntax?> block = default,
		Option<ExpressionSyntax?> expressionBody = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			returnType.HasValue ? returnType.GetValueOrDefault()! : node.ReturnType,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			arrowToken.HasValue ? arrowToken.GetValueOrDefault()! : node.ArrowToken,
			block.HasValue ? block.GetValueOrDefault()! : node.Block,
			expressionBody.HasValue ? expressionBody.GetValueOrDefault()! : node.ExpressionBody );
	public static InitializerExpressionSyntax PartialUpdate(
		this InitializerExpressionSyntax node,
		Option<SyntaxToken> openBraceToken = default,
		Option<SeparatedSyntaxList<ExpressionSyntax>> expressions = default,
		Option<SyntaxToken> closeBraceToken = default )
		=> node.Update(
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			expressions.HasValue ? expressions.GetValueOrDefault()! : node.Expressions,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken );
	public static ImplicitObjectCreationExpressionSyntax PartialUpdate(
		this ImplicitObjectCreationExpressionSyntax node,
		Option<SyntaxToken> newKeyword = default,
		Option<ArgumentListSyntax> argumentList = default,
		Option<InitializerExpressionSyntax?> initializer = default )
		=> node.Update(
			newKeyword.HasValue ? newKeyword.GetValueOrDefault()! : node.NewKeyword,
			argumentList.HasValue ? argumentList.GetValueOrDefault()! : node.ArgumentList,
			initializer.HasValue ? initializer.GetValueOrDefault()! : node.Initializer );
	public static ObjectCreationExpressionSyntax PartialUpdate(
		this ObjectCreationExpressionSyntax node,
		Option<SyntaxToken> newKeyword = default,
		Option<TypeSyntax> type = default,
		Option<ArgumentListSyntax?> argumentList = default,
		Option<InitializerExpressionSyntax?> initializer = default )
		=> node.Update(
			newKeyword.HasValue ? newKeyword.GetValueOrDefault()! : node.NewKeyword,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			argumentList.HasValue ? argumentList.GetValueOrDefault()! : node.ArgumentList,
			initializer.HasValue ? initializer.GetValueOrDefault()! : node.Initializer );
	public static WithExpressionSyntax PartialUpdate(
		this WithExpressionSyntax node,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> withKeyword = default,
		Option<InitializerExpressionSyntax> initializer = default )
		=> node.Update(
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			withKeyword.HasValue ? withKeyword.GetValueOrDefault()! : node.WithKeyword,
			initializer.HasValue ? initializer.GetValueOrDefault()! : node.Initializer );
	public static AnonymousObjectMemberDeclaratorSyntax PartialUpdate(
		this AnonymousObjectMemberDeclaratorSyntax node,
		Option<NameEqualsSyntax?> nameEquals = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			nameEquals.HasValue ? nameEquals.GetValueOrDefault()! : node.NameEquals,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static AnonymousObjectCreationExpressionSyntax PartialUpdate(
		this AnonymousObjectCreationExpressionSyntax node,
		Option<SyntaxToken> newKeyword = default,
		Option<SyntaxToken> openBraceToken = default,
		Option<SeparatedSyntaxList<AnonymousObjectMemberDeclaratorSyntax>> initializers = default,
		Option<SyntaxToken> closeBraceToken = default )
		=> node.Update(
			newKeyword.HasValue ? newKeyword.GetValueOrDefault()! : node.NewKeyword,
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			initializers.HasValue ? initializers.GetValueOrDefault()! : node.Initializers,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken );
	public static ArrayCreationExpressionSyntax PartialUpdate(
		this ArrayCreationExpressionSyntax node,
		Option<SyntaxToken> newKeyword = default,
		Option<ArrayTypeSyntax> type = default,
		Option<InitializerExpressionSyntax?> initializer = default )
		=> node.Update(
			newKeyword.HasValue ? newKeyword.GetValueOrDefault()! : node.NewKeyword,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			initializer.HasValue ? initializer.GetValueOrDefault()! : node.Initializer );
	public static ImplicitArrayCreationExpressionSyntax PartialUpdate(
		this ImplicitArrayCreationExpressionSyntax node,
		Option<SyntaxToken> newKeyword = default,
		Option<SyntaxToken> openBracketToken = default,
		Option<SyntaxTokenList> commas = default,
		Option<SyntaxToken> closeBracketToken = default,
		Option<InitializerExpressionSyntax> initializer = default )
		=> node.Update(
			newKeyword.HasValue ? newKeyword.GetValueOrDefault()! : node.NewKeyword,
			openBracketToken.HasValue ? openBracketToken.GetValueOrDefault()! : node.OpenBracketToken,
			commas.HasValue ? commas.GetValueOrDefault()! : node.Commas,
			closeBracketToken.HasValue ? closeBracketToken.GetValueOrDefault()! : node.CloseBracketToken,
			initializer.HasValue ? initializer.GetValueOrDefault()! : node.Initializer );
	public static StackAllocArrayCreationExpressionSyntax PartialUpdate(
		this StackAllocArrayCreationExpressionSyntax node,
		Option<SyntaxToken> stackAllocKeyword = default,
		Option<TypeSyntax> type = default,
		Option<InitializerExpressionSyntax?> initializer = default )
		=> node.Update(
			stackAllocKeyword.HasValue ? stackAllocKeyword.GetValueOrDefault()! : node.StackAllocKeyword,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			initializer.HasValue ? initializer.GetValueOrDefault()! : node.Initializer );
	public static ImplicitStackAllocArrayCreationExpressionSyntax PartialUpdate(
		this ImplicitStackAllocArrayCreationExpressionSyntax node,
		Option<SyntaxToken> stackAllocKeyword = default,
		Option<SyntaxToken> openBracketToken = default,
		Option<SyntaxToken> closeBracketToken = default,
		Option<InitializerExpressionSyntax> initializer = default )
		=> node.Update(
			stackAllocKeyword.HasValue ? stackAllocKeyword.GetValueOrDefault()! : node.StackAllocKeyword,
			openBracketToken.HasValue ? openBracketToken.GetValueOrDefault()! : node.OpenBracketToken,
			closeBracketToken.HasValue ? closeBracketToken.GetValueOrDefault()! : node.CloseBracketToken,
			initializer.HasValue ? initializer.GetValueOrDefault()! : node.Initializer );
	public static CollectionExpressionSyntax PartialUpdate(
		this CollectionExpressionSyntax node,
		Option<SyntaxToken> openBracketToken = default,
		Option<SeparatedSyntaxList<CollectionElementSyntax>> elements = default,
		Option<SyntaxToken> closeBracketToken = default )
		=> node.Update(
			openBracketToken.HasValue ? openBracketToken.GetValueOrDefault()! : node.OpenBracketToken,
			elements.HasValue ? elements.GetValueOrDefault()! : node.Elements,
			closeBracketToken.HasValue ? closeBracketToken.GetValueOrDefault()! : node.CloseBracketToken );
	public static ExpressionElementSyntax PartialUpdate(
		this ExpressionElementSyntax node,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static SpreadElementSyntax PartialUpdate(
		this SpreadElementSyntax node,
		Option<SyntaxToken> operatorToken = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static QueryExpressionSyntax PartialUpdate(
		this QueryExpressionSyntax node,
		Option<FromClauseSyntax> fromClause = default,
		Option<QueryBodySyntax> body = default )
		=> node.Update(
			fromClause.HasValue ? fromClause.GetValueOrDefault()! : node.FromClause,
			body.HasValue ? body.GetValueOrDefault()! : node.Body );
	public static QueryBodySyntax PartialUpdate(
		this QueryBodySyntax node,
		Option<SyntaxList<QueryClauseSyntax>> clauses = default,
		Option<SelectOrGroupClauseSyntax> selectOrGroup = default,
		Option<QueryContinuationSyntax?> continuation = default )
		=> node.Update(
			clauses.HasValue ? clauses.GetValueOrDefault()! : node.Clauses,
			selectOrGroup.HasValue ? selectOrGroup.GetValueOrDefault()! : node.SelectOrGroup,
			continuation.HasValue ? continuation.GetValueOrDefault()! : node.Continuation );
	public static FromClauseSyntax PartialUpdate(
		this FromClauseSyntax node,
		Option<SyntaxToken> fromKeyword = default,
		Option<TypeSyntax?> type = default,
		Option<SyntaxToken> identifier = default,
		Option<SyntaxToken> inKeyword = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			fromKeyword.HasValue ? fromKeyword.GetValueOrDefault()! : node.FromKeyword,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			inKeyword.HasValue ? inKeyword.GetValueOrDefault()! : node.InKeyword,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static LetClauseSyntax PartialUpdate(
		this LetClauseSyntax node,
		Option<SyntaxToken> letKeyword = default,
		Option<SyntaxToken> identifier = default,
		Option<SyntaxToken> equalsToken = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			letKeyword.HasValue ? letKeyword.GetValueOrDefault()! : node.LetKeyword,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			equalsToken.HasValue ? equalsToken.GetValueOrDefault()! : node.EqualsToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static JoinClauseSyntax PartialUpdate(
		this JoinClauseSyntax node,
		Option<SyntaxToken> joinKeyword = default,
		Option<TypeSyntax?> type = default,
		Option<SyntaxToken> identifier = default,
		Option<SyntaxToken> inKeyword = default,
		Option<ExpressionSyntax> inExpression = default,
		Option<SyntaxToken> onKeyword = default,
		Option<ExpressionSyntax> leftExpression = default,
		Option<SyntaxToken> equalsKeyword = default,
		Option<ExpressionSyntax> rightExpression = default,
		Option<JoinIntoClauseSyntax?> into = default )
		=> node.Update(
			joinKeyword.HasValue ? joinKeyword.GetValueOrDefault()! : node.JoinKeyword,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			inKeyword.HasValue ? inKeyword.GetValueOrDefault()! : node.InKeyword,
			inExpression.HasValue ? inExpression.GetValueOrDefault()! : node.InExpression,
			onKeyword.HasValue ? onKeyword.GetValueOrDefault()! : node.OnKeyword,
			leftExpression.HasValue ? leftExpression.GetValueOrDefault()! : node.LeftExpression,
			equalsKeyword.HasValue ? equalsKeyword.GetValueOrDefault()! : node.EqualsKeyword,
			rightExpression.HasValue ? rightExpression.GetValueOrDefault()! : node.RightExpression,
			into.HasValue ? into.GetValueOrDefault()! : node.Into );
	public static JoinIntoClauseSyntax PartialUpdate(
		this JoinIntoClauseSyntax node,
		Option<SyntaxToken> intoKeyword = default,
		Option<SyntaxToken> identifier = default )
		=> node.Update(
			intoKeyword.HasValue ? intoKeyword.GetValueOrDefault()! : node.IntoKeyword,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier );
	public static WhereClauseSyntax PartialUpdate(
		this WhereClauseSyntax node,
		Option<SyntaxToken> whereKeyword = default,
		Option<ExpressionSyntax> condition = default )
		=> node.Update(
			whereKeyword.HasValue ? whereKeyword.GetValueOrDefault()! : node.WhereKeyword,
			condition.HasValue ? condition.GetValueOrDefault()! : node.Condition );
	public static OrderByClauseSyntax PartialUpdate(
		this OrderByClauseSyntax node,
		Option<SyntaxToken> orderByKeyword = default,
		Option<SeparatedSyntaxList<OrderingSyntax>> orderings = default )
		=> node.Update(
			orderByKeyword.HasValue ? orderByKeyword.GetValueOrDefault()! : node.OrderByKeyword,
			orderings.HasValue ? orderings.GetValueOrDefault()! : node.Orderings );
	public static OrderingSyntax PartialUpdate(
		this OrderingSyntax node,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> ascendingOrDescendingKeyword = default )
		=> node.Update(
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			ascendingOrDescendingKeyword.HasValue ? ascendingOrDescendingKeyword.GetValueOrDefault()! : node.AscendingOrDescendingKeyword );
	public static SelectClauseSyntax PartialUpdate(
		this SelectClauseSyntax node,
		Option<SyntaxToken> selectKeyword = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			selectKeyword.HasValue ? selectKeyword.GetValueOrDefault()! : node.SelectKeyword,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static GroupClauseSyntax PartialUpdate(
		this GroupClauseSyntax node,
		Option<SyntaxToken> groupKeyword = default,
		Option<ExpressionSyntax> groupExpression = default,
		Option<SyntaxToken> byKeyword = default,
		Option<ExpressionSyntax> byExpression = default )
		=> node.Update(
			groupKeyword.HasValue ? groupKeyword.GetValueOrDefault()! : node.GroupKeyword,
			groupExpression.HasValue ? groupExpression.GetValueOrDefault()! : node.GroupExpression,
			byKeyword.HasValue ? byKeyword.GetValueOrDefault()! : node.ByKeyword,
			byExpression.HasValue ? byExpression.GetValueOrDefault()! : node.ByExpression );
	public static QueryContinuationSyntax PartialUpdate(
		this QueryContinuationSyntax node,
		Option<SyntaxToken> intoKeyword = default,
		Option<SyntaxToken> identifier = default,
		Option<QueryBodySyntax> body = default )
		=> node.Update(
			intoKeyword.HasValue ? intoKeyword.GetValueOrDefault()! : node.IntoKeyword,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			body.HasValue ? body.GetValueOrDefault()! : node.Body );
	public static OmittedArraySizeExpressionSyntax PartialUpdate(
		this OmittedArraySizeExpressionSyntax node,
		Option<SyntaxToken> omittedArraySizeExpressionToken = default )
		=> node.Update(
			omittedArraySizeExpressionToken.HasValue ? omittedArraySizeExpressionToken.GetValueOrDefault()! : node.OmittedArraySizeExpressionToken );
	public static InterpolatedStringExpressionSyntax PartialUpdate(
		this InterpolatedStringExpressionSyntax node,
		Option<SyntaxToken> stringStartToken = default,
		Option<SyntaxList<InterpolatedStringContentSyntax>> contents = default,
		Option<SyntaxToken> stringEndToken = default )
		=> node.Update(
			stringStartToken.HasValue ? stringStartToken.GetValueOrDefault()! : node.StringStartToken,
			contents.HasValue ? contents.GetValueOrDefault()! : node.Contents,
			stringEndToken.HasValue ? stringEndToken.GetValueOrDefault()! : node.StringEndToken );
	public static IsPatternExpressionSyntax PartialUpdate(
		this IsPatternExpressionSyntax node,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> isKeyword = default,
		Option<PatternSyntax> pattern = default )
		=> node.Update(
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			isKeyword.HasValue ? isKeyword.GetValueOrDefault()! : node.IsKeyword,
			pattern.HasValue ? pattern.GetValueOrDefault()! : node.Pattern );
	public static ThrowExpressionSyntax PartialUpdate(
		this ThrowExpressionSyntax node,
		Option<SyntaxToken> throwKeyword = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			throwKeyword.HasValue ? throwKeyword.GetValueOrDefault()! : node.ThrowKeyword,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static WhenClauseSyntax PartialUpdate(
		this WhenClauseSyntax node,
		Option<SyntaxToken> whenKeyword = default,
		Option<ExpressionSyntax> condition = default )
		=> node.Update(
			whenKeyword.HasValue ? whenKeyword.GetValueOrDefault()! : node.WhenKeyword,
			condition.HasValue ? condition.GetValueOrDefault()! : node.Condition );
	public static DiscardPatternSyntax PartialUpdate(
		this DiscardPatternSyntax node,
		Option<SyntaxToken> underscoreToken = default )
		=> node.Update(
			underscoreToken.HasValue ? underscoreToken.GetValueOrDefault()! : node.UnderscoreToken );
	public static DeclarationPatternSyntax PartialUpdate(
		this DeclarationPatternSyntax node,
		Option<TypeSyntax> type = default,
		Option<VariableDesignationSyntax> designation = default )
		=> node.Update(
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			designation.HasValue ? designation.GetValueOrDefault()! : node.Designation );
	public static VarPatternSyntax PartialUpdate(
		this VarPatternSyntax node,
		Option<SyntaxToken> varKeyword = default,
		Option<VariableDesignationSyntax> designation = default )
		=> node.Update(
			varKeyword.HasValue ? varKeyword.GetValueOrDefault()! : node.VarKeyword,
			designation.HasValue ? designation.GetValueOrDefault()! : node.Designation );
	public static RecursivePatternSyntax PartialUpdate(
		this RecursivePatternSyntax node,
		Option<TypeSyntax?> type = default,
		Option<PositionalPatternClauseSyntax?> positionalPatternClause = default,
		Option<PropertyPatternClauseSyntax?> propertyPatternClause = default,
		Option<VariableDesignationSyntax?> designation = default )
		=> node.Update(
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			positionalPatternClause.HasValue ? positionalPatternClause.GetValueOrDefault()! : node.PositionalPatternClause,
			propertyPatternClause.HasValue ? propertyPatternClause.GetValueOrDefault()! : node.PropertyPatternClause,
			designation.HasValue ? designation.GetValueOrDefault()! : node.Designation );
	public static PositionalPatternClauseSyntax PartialUpdate(
		this PositionalPatternClauseSyntax node,
		Option<SyntaxToken> openParenToken = default,
		Option<SeparatedSyntaxList<SubpatternSyntax>> subpatterns = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			subpatterns.HasValue ? subpatterns.GetValueOrDefault()! : node.Subpatterns,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static PropertyPatternClauseSyntax PartialUpdate(
		this PropertyPatternClauseSyntax node,
		Option<SyntaxToken> openBraceToken = default,
		Option<SeparatedSyntaxList<SubpatternSyntax>> subpatterns = default,
		Option<SyntaxToken> closeBraceToken = default )
		=> node.Update(
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			subpatterns.HasValue ? subpatterns.GetValueOrDefault()! : node.Subpatterns,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken );
	public static SubpatternSyntax PartialUpdate(
		this SubpatternSyntax node,
		Option<BaseExpressionColonSyntax?> expressionColon = default,
		Option<PatternSyntax> pattern = default )
		=> node.Update(
			expressionColon.HasValue ? expressionColon.GetValueOrDefault()! : node.ExpressionColon,
			pattern.HasValue ? pattern.GetValueOrDefault()! : node.Pattern );
	public static ConstantPatternSyntax PartialUpdate(
		this ConstantPatternSyntax node,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static ParenthesizedPatternSyntax PartialUpdate(
		this ParenthesizedPatternSyntax node,
		Option<SyntaxToken> openParenToken = default,
		Option<PatternSyntax> pattern = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			pattern.HasValue ? pattern.GetValueOrDefault()! : node.Pattern,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static RelationalPatternSyntax PartialUpdate(
		this RelationalPatternSyntax node,
		Option<SyntaxToken> operatorToken = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static TypePatternSyntax PartialUpdate(
		this TypePatternSyntax node,
		Option<TypeSyntax> type = default )
		=> node.Update(
			type.HasValue ? type.GetValueOrDefault()! : node.Type );
	public static BinaryPatternSyntax PartialUpdate(
		this BinaryPatternSyntax node,
		Option<PatternSyntax> left = default,
		Option<SyntaxToken> operatorToken = default,
		Option<PatternSyntax> right = default )
		=> node.Update(
			left.HasValue ? left.GetValueOrDefault()! : node.Left,
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken,
			right.HasValue ? right.GetValueOrDefault()! : node.Right );
	public static UnaryPatternSyntax PartialUpdate(
		this UnaryPatternSyntax node,
		Option<SyntaxToken> operatorToken = default,
		Option<PatternSyntax> pattern = default )
		=> node.Update(
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken,
			pattern.HasValue ? pattern.GetValueOrDefault()! : node.Pattern );
	public static ListPatternSyntax PartialUpdate(
		this ListPatternSyntax node,
		Option<SyntaxToken> openBracketToken = default,
		Option<SeparatedSyntaxList<PatternSyntax>> patterns = default,
		Option<SyntaxToken> closeBracketToken = default,
		Option<VariableDesignationSyntax?> designation = default )
		=> node.Update(
			openBracketToken.HasValue ? openBracketToken.GetValueOrDefault()! : node.OpenBracketToken,
			patterns.HasValue ? patterns.GetValueOrDefault()! : node.Patterns,
			closeBracketToken.HasValue ? closeBracketToken.GetValueOrDefault()! : node.CloseBracketToken,
			designation.HasValue ? designation.GetValueOrDefault()! : node.Designation );
	public static SlicePatternSyntax PartialUpdate(
		this SlicePatternSyntax node,
		Option<SyntaxToken> dotDotToken = default,
		Option<PatternSyntax?> pattern = default )
		=> node.Update(
			dotDotToken.HasValue ? dotDotToken.GetValueOrDefault()! : node.DotDotToken,
			pattern.HasValue ? pattern.GetValueOrDefault()! : node.Pattern );
	public static InterpolatedStringTextSyntax PartialUpdate(
		this InterpolatedStringTextSyntax node,
		Option<SyntaxToken> textToken = default )
		=> node.Update(
			textToken.HasValue ? textToken.GetValueOrDefault()! : node.TextToken );
	public static InterpolationSyntax PartialUpdate(
		this InterpolationSyntax node,
		Option<SyntaxToken> openBraceToken = default,
		Option<ExpressionSyntax> expression = default,
		Option<InterpolationAlignmentClauseSyntax?> alignmentClause = default,
		Option<InterpolationFormatClauseSyntax?> formatClause = default,
		Option<SyntaxToken> closeBraceToken = default )
		=> node.Update(
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			alignmentClause.HasValue ? alignmentClause.GetValueOrDefault()! : node.AlignmentClause,
			formatClause.HasValue ? formatClause.GetValueOrDefault()! : node.FormatClause,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken );
	public static InterpolationAlignmentClauseSyntax PartialUpdate(
		this InterpolationAlignmentClauseSyntax node,
		Option<SyntaxToken> commaToken = default,
		Option<ExpressionSyntax> value = default )
		=> node.Update(
			commaToken.HasValue ? commaToken.GetValueOrDefault()! : node.CommaToken,
			value.HasValue ? value.GetValueOrDefault()! : node.Value );
	public static InterpolationFormatClauseSyntax PartialUpdate(
		this InterpolationFormatClauseSyntax node,
		Option<SyntaxToken> colonToken = default,
		Option<SyntaxToken> formatStringToken = default )
		=> node.Update(
			colonToken.HasValue ? colonToken.GetValueOrDefault()! : node.ColonToken,
			formatStringToken.HasValue ? formatStringToken.GetValueOrDefault()! : node.FormatStringToken );
	public static GlobalStatementSyntax PartialUpdate(
		this GlobalStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<StatementSyntax> statement = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			statement.HasValue ? statement.GetValueOrDefault()! : node.Statement );
	public static BlockSyntax PartialUpdate(
		this BlockSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> openBraceToken = default,
		Option<SyntaxList<StatementSyntax>> statements = default,
		Option<SyntaxToken> closeBraceToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			statements.HasValue ? statements.GetValueOrDefault()! : node.Statements,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken );
	public static LocalFunctionStatementSyntax PartialUpdate(
		this LocalFunctionStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<TypeSyntax> returnType = default,
		Option<SyntaxToken> identifier = default,
		Option<TypeParameterListSyntax?> typeParameterList = default,
		Option<ParameterListSyntax> parameterList = default,
		Option<SyntaxList<TypeParameterConstraintClauseSyntax>> constraintClauses = default,
		Option<BlockSyntax?> body = default,
		Option<ArrowExpressionClauseSyntax?> expressionBody = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			returnType.HasValue ? returnType.GetValueOrDefault()! : node.ReturnType,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			typeParameterList.HasValue ? typeParameterList.GetValueOrDefault()! : node.TypeParameterList,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			constraintClauses.HasValue ? constraintClauses.GetValueOrDefault()! : node.ConstraintClauses,
			body.HasValue ? body.GetValueOrDefault()! : node.Body,
			expressionBody.HasValue ? expressionBody.GetValueOrDefault()! : node.ExpressionBody,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static LocalDeclarationStatementSyntax PartialUpdate(
		this LocalDeclarationStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> awaitKeyword = default,
		Option<SyntaxToken> usingKeyword = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<VariableDeclarationSyntax> declaration = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			awaitKeyword.HasValue ? awaitKeyword.GetValueOrDefault()! : node.AwaitKeyword,
			usingKeyword.HasValue ? usingKeyword.GetValueOrDefault()! : node.UsingKeyword,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			declaration.HasValue ? declaration.GetValueOrDefault()! : node.Declaration,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static VariableDeclarationSyntax PartialUpdate(
		this VariableDeclarationSyntax node,
		Option<TypeSyntax> type = default,
		Option<SeparatedSyntaxList<VariableDeclaratorSyntax>> variables = default )
		=> node.Update(
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			variables.HasValue ? variables.GetValueOrDefault()! : node.Variables );
	public static VariableDeclaratorSyntax PartialUpdate(
		this VariableDeclaratorSyntax node,
		Option<SyntaxToken> identifier = default,
		Option<BracketedArgumentListSyntax?> argumentList = default,
		Option<EqualsValueClauseSyntax?> initializer = default )
		=> node.Update(
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			argumentList.HasValue ? argumentList.GetValueOrDefault()! : node.ArgumentList,
			initializer.HasValue ? initializer.GetValueOrDefault()! : node.Initializer );
	public static EqualsValueClauseSyntax PartialUpdate(
		this EqualsValueClauseSyntax node,
		Option<SyntaxToken> equalsToken = default,
		Option<ExpressionSyntax> value = default )
		=> node.Update(
			equalsToken.HasValue ? equalsToken.GetValueOrDefault()! : node.EqualsToken,
			value.HasValue ? value.GetValueOrDefault()! : node.Value );
	public static SingleVariableDesignationSyntax PartialUpdate(
		this SingleVariableDesignationSyntax node,
		Option<SyntaxToken> identifier = default )
		=> node.Update(
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier );
	public static DiscardDesignationSyntax PartialUpdate(
		this DiscardDesignationSyntax node,
		Option<SyntaxToken> underscoreToken = default )
		=> node.Update(
			underscoreToken.HasValue ? underscoreToken.GetValueOrDefault()! : node.UnderscoreToken );
	public static ParenthesizedVariableDesignationSyntax PartialUpdate(
		this ParenthesizedVariableDesignationSyntax node,
		Option<SyntaxToken> openParenToken = default,
		Option<SeparatedSyntaxList<VariableDesignationSyntax>> variables = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			variables.HasValue ? variables.GetValueOrDefault()! : node.Variables,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static ExpressionStatementSyntax PartialUpdate(
		this ExpressionStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static EmptyStatementSyntax PartialUpdate(
		this EmptyStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static LabeledStatementSyntax PartialUpdate(
		this LabeledStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> identifier = default,
		Option<SyntaxToken> colonToken = default,
		Option<StatementSyntax> statement = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			colonToken.HasValue ? colonToken.GetValueOrDefault()! : node.ColonToken,
			statement.HasValue ? statement.GetValueOrDefault()! : node.Statement );
	public static GotoStatementSyntax PartialUpdate(
		this GotoStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> gotoKeyword = default,
		Option<SyntaxToken> caseOrDefaultKeyword = default,
		Option<ExpressionSyntax?> expression = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			gotoKeyword.HasValue ? gotoKeyword.GetValueOrDefault()! : node.GotoKeyword,
			caseOrDefaultKeyword.HasValue ? caseOrDefaultKeyword.GetValueOrDefault()! : node.CaseOrDefaultKeyword,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static BreakStatementSyntax PartialUpdate(
		this BreakStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> breakKeyword = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			breakKeyword.HasValue ? breakKeyword.GetValueOrDefault()! : node.BreakKeyword,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static ContinueStatementSyntax PartialUpdate(
		this ContinueStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> continueKeyword = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			continueKeyword.HasValue ? continueKeyword.GetValueOrDefault()! : node.ContinueKeyword,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static ReturnStatementSyntax PartialUpdate(
		this ReturnStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> returnKeyword = default,
		Option<ExpressionSyntax?> expression = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			returnKeyword.HasValue ? returnKeyword.GetValueOrDefault()! : node.ReturnKeyword,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static ThrowStatementSyntax PartialUpdate(
		this ThrowStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> throwKeyword = default,
		Option<ExpressionSyntax?> expression = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			throwKeyword.HasValue ? throwKeyword.GetValueOrDefault()! : node.ThrowKeyword,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static YieldStatementSyntax PartialUpdate(
		this YieldStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> yieldKeyword = default,
		Option<SyntaxToken> returnOrBreakKeyword = default,
		Option<ExpressionSyntax?> expression = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			yieldKeyword.HasValue ? yieldKeyword.GetValueOrDefault()! : node.YieldKeyword,
			returnOrBreakKeyword.HasValue ? returnOrBreakKeyword.GetValueOrDefault()! : node.ReturnOrBreakKeyword,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static WhileStatementSyntax PartialUpdate(
		this WhileStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> whileKeyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<ExpressionSyntax> condition = default,
		Option<SyntaxToken> closeParenToken = default,
		Option<StatementSyntax> statement = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			whileKeyword.HasValue ? whileKeyword.GetValueOrDefault()! : node.WhileKeyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			condition.HasValue ? condition.GetValueOrDefault()! : node.Condition,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken,
			statement.HasValue ? statement.GetValueOrDefault()! : node.Statement );
	public static DoStatementSyntax PartialUpdate(
		this DoStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> doKeyword = default,
		Option<StatementSyntax> statement = default,
		Option<SyntaxToken> whileKeyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<ExpressionSyntax> condition = default,
		Option<SyntaxToken> closeParenToken = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			doKeyword.HasValue ? doKeyword.GetValueOrDefault()! : node.DoKeyword,
			statement.HasValue ? statement.GetValueOrDefault()! : node.Statement,
			whileKeyword.HasValue ? whileKeyword.GetValueOrDefault()! : node.WhileKeyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			condition.HasValue ? condition.GetValueOrDefault()! : node.Condition,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static ForStatementSyntax PartialUpdate(
		this ForStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> forKeyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<VariableDeclarationSyntax?> declaration = default,
		Option<SeparatedSyntaxList<ExpressionSyntax>> initializers = default,
		Option<SyntaxToken> firstSemicolonToken = default,
		Option<ExpressionSyntax?> condition = default,
		Option<SyntaxToken> secondSemicolonToken = default,
		Option<SeparatedSyntaxList<ExpressionSyntax>> incrementors = default,
		Option<SyntaxToken> closeParenToken = default,
		Option<StatementSyntax> statement = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			forKeyword.HasValue ? forKeyword.GetValueOrDefault()! : node.ForKeyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			declaration.HasValue ? declaration.GetValueOrDefault()! : node.Declaration,
			initializers.HasValue ? initializers.GetValueOrDefault()! : node.Initializers,
			firstSemicolonToken.HasValue ? firstSemicolonToken.GetValueOrDefault()! : node.FirstSemicolonToken,
			condition.HasValue ? condition.GetValueOrDefault()! : node.Condition,
			secondSemicolonToken.HasValue ? secondSemicolonToken.GetValueOrDefault()! : node.SecondSemicolonToken,
			incrementors.HasValue ? incrementors.GetValueOrDefault()! : node.Incrementors,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken,
			statement.HasValue ? statement.GetValueOrDefault()! : node.Statement );
	public static ForEachStatementSyntax PartialUpdate(
		this ForEachStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> awaitKeyword = default,
		Option<SyntaxToken> forEachKeyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<TypeSyntax> type = default,
		Option<SyntaxToken> identifier = default,
		Option<SyntaxToken> inKeyword = default,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> closeParenToken = default,
		Option<StatementSyntax> statement = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			awaitKeyword.HasValue ? awaitKeyword.GetValueOrDefault()! : node.AwaitKeyword,
			forEachKeyword.HasValue ? forEachKeyword.GetValueOrDefault()! : node.ForEachKeyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			inKeyword.HasValue ? inKeyword.GetValueOrDefault()! : node.InKeyword,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken,
			statement.HasValue ? statement.GetValueOrDefault()! : node.Statement );
	public static ForEachVariableStatementSyntax PartialUpdate(
		this ForEachVariableStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> awaitKeyword = default,
		Option<SyntaxToken> forEachKeyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<ExpressionSyntax> variable = default,
		Option<SyntaxToken> inKeyword = default,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> closeParenToken = default,
		Option<StatementSyntax> statement = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			awaitKeyword.HasValue ? awaitKeyword.GetValueOrDefault()! : node.AwaitKeyword,
			forEachKeyword.HasValue ? forEachKeyword.GetValueOrDefault()! : node.ForEachKeyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			variable.HasValue ? variable.GetValueOrDefault()! : node.Variable,
			inKeyword.HasValue ? inKeyword.GetValueOrDefault()! : node.InKeyword,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken,
			statement.HasValue ? statement.GetValueOrDefault()! : node.Statement );
	public static UsingStatementSyntax PartialUpdate(
		this UsingStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> awaitKeyword = default,
		Option<SyntaxToken> usingKeyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<VariableDeclarationSyntax?> declaration = default,
		Option<ExpressionSyntax?> expression = default,
		Option<SyntaxToken> closeParenToken = default,
		Option<StatementSyntax> statement = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			awaitKeyword.HasValue ? awaitKeyword.GetValueOrDefault()! : node.AwaitKeyword,
			usingKeyword.HasValue ? usingKeyword.GetValueOrDefault()! : node.UsingKeyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			declaration.HasValue ? declaration.GetValueOrDefault()! : node.Declaration,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken,
			statement.HasValue ? statement.GetValueOrDefault()! : node.Statement );
	public static FixedStatementSyntax PartialUpdate(
		this FixedStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> fixedKeyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<VariableDeclarationSyntax> declaration = default,
		Option<SyntaxToken> closeParenToken = default,
		Option<StatementSyntax> statement = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			fixedKeyword.HasValue ? fixedKeyword.GetValueOrDefault()! : node.FixedKeyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			declaration.HasValue ? declaration.GetValueOrDefault()! : node.Declaration,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken,
			statement.HasValue ? statement.GetValueOrDefault()! : node.Statement );
	public static CheckedStatementSyntax PartialUpdate(
		this CheckedStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> keyword = default,
		Option<BlockSyntax> block = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			block.HasValue ? block.GetValueOrDefault()! : node.Block );
	public static UnsafeStatementSyntax PartialUpdate(
		this UnsafeStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> unsafeKeyword = default,
		Option<BlockSyntax> block = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			unsafeKeyword.HasValue ? unsafeKeyword.GetValueOrDefault()! : node.UnsafeKeyword,
			block.HasValue ? block.GetValueOrDefault()! : node.Block );
	public static LockStatementSyntax PartialUpdate(
		this LockStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> lockKeyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> closeParenToken = default,
		Option<StatementSyntax> statement = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			lockKeyword.HasValue ? lockKeyword.GetValueOrDefault()! : node.LockKeyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken,
			statement.HasValue ? statement.GetValueOrDefault()! : node.Statement );
	public static IfStatementSyntax PartialUpdate(
		this IfStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> ifKeyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<ExpressionSyntax> condition = default,
		Option<SyntaxToken> closeParenToken = default,
		Option<StatementSyntax> statement = default,
		Option<ElseClauseSyntax?> @else = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			ifKeyword.HasValue ? ifKeyword.GetValueOrDefault()! : node.IfKeyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			condition.HasValue ? condition.GetValueOrDefault()! : node.Condition,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken,
			statement.HasValue ? statement.GetValueOrDefault()! : node.Statement,
			@else.HasValue ? @else.GetValueOrDefault()! : node.Else );
	public static ElseClauseSyntax PartialUpdate(
		this ElseClauseSyntax node,
		Option<SyntaxToken> elseKeyword = default,
		Option<StatementSyntax> statement = default )
		=> node.Update(
			elseKeyword.HasValue ? elseKeyword.GetValueOrDefault()! : node.ElseKeyword,
			statement.HasValue ? statement.GetValueOrDefault()! : node.Statement );
	public static SwitchStatementSyntax PartialUpdate(
		this SwitchStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> switchKeyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<ExpressionSyntax> expression = default,
		Option<SyntaxToken> closeParenToken = default,
		Option<SyntaxToken> openBraceToken = default,
		Option<SyntaxList<SwitchSectionSyntax>> sections = default,
		Option<SyntaxToken> closeBraceToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			switchKeyword.HasValue ? switchKeyword.GetValueOrDefault()! : node.SwitchKeyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken,
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			sections.HasValue ? sections.GetValueOrDefault()! : node.Sections,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken );
	public static SwitchSectionSyntax PartialUpdate(
		this SwitchSectionSyntax node,
		Option<SyntaxList<SwitchLabelSyntax>> labels = default,
		Option<SyntaxList<StatementSyntax>> statements = default )
		=> node.Update(
			labels.HasValue ? labels.GetValueOrDefault()! : node.Labels,
			statements.HasValue ? statements.GetValueOrDefault()! : node.Statements );
	public static CasePatternSwitchLabelSyntax PartialUpdate(
		this CasePatternSwitchLabelSyntax node,
		Option<SyntaxToken> keyword = default,
		Option<PatternSyntax> pattern = default,
		Option<WhenClauseSyntax?> whenClause = default,
		Option<SyntaxToken> colonToken = default )
		=> node.Update(
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			pattern.HasValue ? pattern.GetValueOrDefault()! : node.Pattern,
			whenClause.HasValue ? whenClause.GetValueOrDefault()! : node.WhenClause,
			colonToken.HasValue ? colonToken.GetValueOrDefault()! : node.ColonToken );
	public static CaseSwitchLabelSyntax PartialUpdate(
		this CaseSwitchLabelSyntax node,
		Option<SyntaxToken> keyword = default,
		Option<ExpressionSyntax> value = default,
		Option<SyntaxToken> colonToken = default )
		=> node.Update(
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			value.HasValue ? value.GetValueOrDefault()! : node.Value,
			colonToken.HasValue ? colonToken.GetValueOrDefault()! : node.ColonToken );
	public static DefaultSwitchLabelSyntax PartialUpdate(
		this DefaultSwitchLabelSyntax node,
		Option<SyntaxToken> keyword = default,
		Option<SyntaxToken> colonToken = default )
		=> node.Update(
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			colonToken.HasValue ? colonToken.GetValueOrDefault()! : node.ColonToken );
	public static SwitchExpressionSyntax PartialUpdate(
		this SwitchExpressionSyntax node,
		Option<ExpressionSyntax> governingExpression = default,
		Option<SyntaxToken> switchKeyword = default,
		Option<SyntaxToken> openBraceToken = default,
		Option<SeparatedSyntaxList<SwitchExpressionArmSyntax>> arms = default,
		Option<SyntaxToken> closeBraceToken = default )
		=> node.Update(
			governingExpression.HasValue ? governingExpression.GetValueOrDefault()! : node.GoverningExpression,
			switchKeyword.HasValue ? switchKeyword.GetValueOrDefault()! : node.SwitchKeyword,
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			arms.HasValue ? arms.GetValueOrDefault()! : node.Arms,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken );
	public static SwitchExpressionArmSyntax PartialUpdate(
		this SwitchExpressionArmSyntax node,
		Option<PatternSyntax> pattern = default,
		Option<WhenClauseSyntax?> whenClause = default,
		Option<SyntaxToken> equalsGreaterThanToken = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			pattern.HasValue ? pattern.GetValueOrDefault()! : node.Pattern,
			whenClause.HasValue ? whenClause.GetValueOrDefault()! : node.WhenClause,
			equalsGreaterThanToken.HasValue ? equalsGreaterThanToken.GetValueOrDefault()! : node.EqualsGreaterThanToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static TryStatementSyntax PartialUpdate(
		this TryStatementSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> tryKeyword = default,
		Option<BlockSyntax> block = default,
		Option<SyntaxList<CatchClauseSyntax>> catches = default,
		Option<FinallyClauseSyntax?> @finally = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			tryKeyword.HasValue ? tryKeyword.GetValueOrDefault()! : node.TryKeyword,
			block.HasValue ? block.GetValueOrDefault()! : node.Block,
			catches.HasValue ? catches.GetValueOrDefault()! : node.Catches,
			@finally.HasValue ? @finally.GetValueOrDefault()! : node.Finally );
	public static CatchClauseSyntax PartialUpdate(
		this CatchClauseSyntax node,
		Option<SyntaxToken> catchKeyword = default,
		Option<CatchDeclarationSyntax?> declaration = default,
		Option<CatchFilterClauseSyntax?> filter = default,
		Option<BlockSyntax> block = default )
		=> node.Update(
			catchKeyword.HasValue ? catchKeyword.GetValueOrDefault()! : node.CatchKeyword,
			declaration.HasValue ? declaration.GetValueOrDefault()! : node.Declaration,
			filter.HasValue ? filter.GetValueOrDefault()! : node.Filter,
			block.HasValue ? block.GetValueOrDefault()! : node.Block );
	public static CatchDeclarationSyntax PartialUpdate(
		this CatchDeclarationSyntax node,
		Option<SyntaxToken> openParenToken = default,
		Option<TypeSyntax> type = default,
		Option<SyntaxToken> identifier = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static CatchFilterClauseSyntax PartialUpdate(
		this CatchFilterClauseSyntax node,
		Option<SyntaxToken> whenKeyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<ExpressionSyntax> filterExpression = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			whenKeyword.HasValue ? whenKeyword.GetValueOrDefault()! : node.WhenKeyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			filterExpression.HasValue ? filterExpression.GetValueOrDefault()! : node.FilterExpression,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static FinallyClauseSyntax PartialUpdate(
		this FinallyClauseSyntax node,
		Option<SyntaxToken> finallyKeyword = default,
		Option<BlockSyntax> block = default )
		=> node.Update(
			finallyKeyword.HasValue ? finallyKeyword.GetValueOrDefault()! : node.FinallyKeyword,
			block.HasValue ? block.GetValueOrDefault()! : node.Block );
	public static CompilationUnitSyntax PartialUpdate(
		this CompilationUnitSyntax node,
		Option<SyntaxList<ExternAliasDirectiveSyntax>> externs = default,
		Option<SyntaxList<UsingDirectiveSyntax>> usings = default,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxList<MemberDeclarationSyntax>> members = default,
		Option<SyntaxToken> endOfFileToken = default )
		=> node.Update(
			externs.HasValue ? externs.GetValueOrDefault()! : node.Externs,
			usings.HasValue ? usings.GetValueOrDefault()! : node.Usings,
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			members.HasValue ? members.GetValueOrDefault()! : node.Members,
			endOfFileToken.HasValue ? endOfFileToken.GetValueOrDefault()! : node.EndOfFileToken );
	public static ExternAliasDirectiveSyntax PartialUpdate(
		this ExternAliasDirectiveSyntax node,
		Option<SyntaxToken> externKeyword = default,
		Option<SyntaxToken> aliasKeyword = default,
		Option<SyntaxToken> identifier = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			externKeyword.HasValue ? externKeyword.GetValueOrDefault()! : node.ExternKeyword,
			aliasKeyword.HasValue ? aliasKeyword.GetValueOrDefault()! : node.AliasKeyword,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static UsingDirectiveSyntax PartialUpdate(
		this UsingDirectiveSyntax node,
		Option<SyntaxToken> globalKeyword = default,
		Option<SyntaxToken> usingKeyword = default,
		Option<SyntaxToken> staticKeyword = default,
		Option<SyntaxToken> unsafeKeyword = default,
		Option<NameEqualsSyntax?> alias = default,
		Option<TypeSyntax> namespaceOrType = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			globalKeyword.HasValue ? globalKeyword.GetValueOrDefault()! : node.GlobalKeyword,
			usingKeyword.HasValue ? usingKeyword.GetValueOrDefault()! : node.UsingKeyword,
			staticKeyword.HasValue ? staticKeyword.GetValueOrDefault()! : node.StaticKeyword,
			unsafeKeyword.HasValue ? unsafeKeyword.GetValueOrDefault()! : node.UnsafeKeyword,
			alias.HasValue ? alias.GetValueOrDefault()! : node.Alias,
			namespaceOrType.HasValue ? namespaceOrType.GetValueOrDefault()! : node.NamespaceOrType,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static NamespaceDeclarationSyntax PartialUpdate(
		this NamespaceDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> namespaceKeyword = default,
		Option<NameSyntax> name = default,
		Option<SyntaxToken> openBraceToken = default,
		Option<SyntaxList<ExternAliasDirectiveSyntax>> externs = default,
		Option<SyntaxList<UsingDirectiveSyntax>> usings = default,
		Option<SyntaxList<MemberDeclarationSyntax>> members = default,
		Option<SyntaxToken> closeBraceToken = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			namespaceKeyword.HasValue ? namespaceKeyword.GetValueOrDefault()! : node.NamespaceKeyword,
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			externs.HasValue ? externs.GetValueOrDefault()! : node.Externs,
			usings.HasValue ? usings.GetValueOrDefault()! : node.Usings,
			members.HasValue ? members.GetValueOrDefault()! : node.Members,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static FileScopedNamespaceDeclarationSyntax PartialUpdate(
		this FileScopedNamespaceDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> namespaceKeyword = default,
		Option<NameSyntax> name = default,
		Option<SyntaxToken> semicolonToken = default,
		Option<SyntaxList<ExternAliasDirectiveSyntax>> externs = default,
		Option<SyntaxList<UsingDirectiveSyntax>> usings = default,
		Option<SyntaxList<MemberDeclarationSyntax>> members = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			namespaceKeyword.HasValue ? namespaceKeyword.GetValueOrDefault()! : node.NamespaceKeyword,
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken,
			externs.HasValue ? externs.GetValueOrDefault()! : node.Externs,
			usings.HasValue ? usings.GetValueOrDefault()! : node.Usings,
			members.HasValue ? members.GetValueOrDefault()! : node.Members );
	public static AttributeListSyntax PartialUpdate(
		this AttributeListSyntax node,
		Option<SyntaxToken> openBracketToken = default,
		Option<AttributeTargetSpecifierSyntax?> target = default,
		Option<SeparatedSyntaxList<AttributeSyntax>> attributes = default,
		Option<SyntaxToken> closeBracketToken = default )
		=> node.Update(
			openBracketToken.HasValue ? openBracketToken.GetValueOrDefault()! : node.OpenBracketToken,
			target.HasValue ? target.GetValueOrDefault()! : node.Target,
			attributes.HasValue ? attributes.GetValueOrDefault()! : node.Attributes,
			closeBracketToken.HasValue ? closeBracketToken.GetValueOrDefault()! : node.CloseBracketToken );
	public static AttributeTargetSpecifierSyntax PartialUpdate(
		this AttributeTargetSpecifierSyntax node,
		Option<SyntaxToken> identifier = default,
		Option<SyntaxToken> colonToken = default )
		=> node.Update(
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			colonToken.HasValue ? colonToken.GetValueOrDefault()! : node.ColonToken );
	public static AttributeSyntax PartialUpdate(
		this AttributeSyntax node,
		Option<NameSyntax> name = default,
		Option<AttributeArgumentListSyntax?> argumentList = default )
		=> node.Update(
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			argumentList.HasValue ? argumentList.GetValueOrDefault()! : node.ArgumentList );
	public static AttributeArgumentListSyntax PartialUpdate(
		this AttributeArgumentListSyntax node,
		Option<SyntaxToken> openParenToken = default,
		Option<SeparatedSyntaxList<AttributeArgumentSyntax>> arguments = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			arguments.HasValue ? arguments.GetValueOrDefault()! : node.Arguments,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static AttributeArgumentSyntax PartialUpdate(
		this AttributeArgumentSyntax node,
		Option<NameEqualsSyntax?> nameEquals = default,
		Option<NameColonSyntax?> nameColon = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			nameEquals.HasValue ? nameEquals.GetValueOrDefault()! : node.NameEquals,
			nameColon.HasValue ? nameColon.GetValueOrDefault()! : node.NameColon,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static NameEqualsSyntax PartialUpdate(
		this NameEqualsSyntax node,
		Option<IdentifierNameSyntax> name = default,
		Option<SyntaxToken> equalsToken = default )
		=> node.Update(
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			equalsToken.HasValue ? equalsToken.GetValueOrDefault()! : node.EqualsToken );
	public static TypeParameterListSyntax PartialUpdate(
		this TypeParameterListSyntax node,
		Option<SyntaxToken> lessThanToken = default,
		Option<SeparatedSyntaxList<TypeParameterSyntax>> parameters = default,
		Option<SyntaxToken> greaterThanToken = default )
		=> node.Update(
			lessThanToken.HasValue ? lessThanToken.GetValueOrDefault()! : node.LessThanToken,
			parameters.HasValue ? parameters.GetValueOrDefault()! : node.Parameters,
			greaterThanToken.HasValue ? greaterThanToken.GetValueOrDefault()! : node.GreaterThanToken );
	public static TypeParameterSyntax PartialUpdate(
		this TypeParameterSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxToken> varianceKeyword = default,
		Option<SyntaxToken> identifier = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			varianceKeyword.HasValue ? varianceKeyword.GetValueOrDefault()! : node.VarianceKeyword,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier );
	public static ClassDeclarationSyntax PartialUpdate(
		this ClassDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> keyword = default,
		Option<SyntaxToken> identifier = default,
		Option<TypeParameterListSyntax?> typeParameterList = default,
		Option<ParameterListSyntax?> parameterList = default,
		Option<BaseListSyntax?> baseList = default,
		Option<SyntaxList<TypeParameterConstraintClauseSyntax>> constraintClauses = default,
		Option<SyntaxToken> openBraceToken = default,
		Option<SyntaxList<MemberDeclarationSyntax>> members = default,
		Option<SyntaxToken> closeBraceToken = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			typeParameterList.HasValue ? typeParameterList.GetValueOrDefault()! : node.TypeParameterList,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			baseList.HasValue ? baseList.GetValueOrDefault()! : node.BaseList,
			constraintClauses.HasValue ? constraintClauses.GetValueOrDefault()! : node.ConstraintClauses,
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			members.HasValue ? members.GetValueOrDefault()! : node.Members,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static StructDeclarationSyntax PartialUpdate(
		this StructDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> keyword = default,
		Option<SyntaxToken> identifier = default,
		Option<TypeParameterListSyntax?> typeParameterList = default,
		Option<ParameterListSyntax?> parameterList = default,
		Option<BaseListSyntax?> baseList = default,
		Option<SyntaxList<TypeParameterConstraintClauseSyntax>> constraintClauses = default,
		Option<SyntaxToken> openBraceToken = default,
		Option<SyntaxList<MemberDeclarationSyntax>> members = default,
		Option<SyntaxToken> closeBraceToken = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			typeParameterList.HasValue ? typeParameterList.GetValueOrDefault()! : node.TypeParameterList,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			baseList.HasValue ? baseList.GetValueOrDefault()! : node.BaseList,
			constraintClauses.HasValue ? constraintClauses.GetValueOrDefault()! : node.ConstraintClauses,
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			members.HasValue ? members.GetValueOrDefault()! : node.Members,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static InterfaceDeclarationSyntax PartialUpdate(
		this InterfaceDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> keyword = default,
		Option<SyntaxToken> identifier = default,
		Option<TypeParameterListSyntax?> typeParameterList = default,
		Option<ParameterListSyntax?> parameterList = default,
		Option<BaseListSyntax?> baseList = default,
		Option<SyntaxList<TypeParameterConstraintClauseSyntax>> constraintClauses = default,
		Option<SyntaxToken> openBraceToken = default,
		Option<SyntaxList<MemberDeclarationSyntax>> members = default,
		Option<SyntaxToken> closeBraceToken = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			typeParameterList.HasValue ? typeParameterList.GetValueOrDefault()! : node.TypeParameterList,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			baseList.HasValue ? baseList.GetValueOrDefault()! : node.BaseList,
			constraintClauses.HasValue ? constraintClauses.GetValueOrDefault()! : node.ConstraintClauses,
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			members.HasValue ? members.GetValueOrDefault()! : node.Members,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static RecordDeclarationSyntax PartialUpdate(
		this RecordDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> keyword = default,
		Option<SyntaxToken> classOrStructKeyword = default,
		Option<SyntaxToken> identifier = default,
		Option<TypeParameterListSyntax?> typeParameterList = default,
		Option<ParameterListSyntax?> parameterList = default,
		Option<BaseListSyntax?> baseList = default,
		Option<SyntaxList<TypeParameterConstraintClauseSyntax>> constraintClauses = default,
		Option<SyntaxToken> openBraceToken = default,
		Option<SyntaxList<MemberDeclarationSyntax>> members = default,
		Option<SyntaxToken> closeBraceToken = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			classOrStructKeyword.HasValue ? classOrStructKeyword.GetValueOrDefault()! : node.ClassOrStructKeyword,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			typeParameterList.HasValue ? typeParameterList.GetValueOrDefault()! : node.TypeParameterList,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			baseList.HasValue ? baseList.GetValueOrDefault()! : node.BaseList,
			constraintClauses.HasValue ? constraintClauses.GetValueOrDefault()! : node.ConstraintClauses,
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			members.HasValue ? members.GetValueOrDefault()! : node.Members,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static EnumDeclarationSyntax PartialUpdate(
		this EnumDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> enumKeyword = default,
		Option<SyntaxToken> identifier = default,
		Option<BaseListSyntax?> baseList = default,
		Option<SyntaxToken> openBraceToken = default,
		Option<SeparatedSyntaxList<EnumMemberDeclarationSyntax>> members = default,
		Option<SyntaxToken> closeBraceToken = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			enumKeyword.HasValue ? enumKeyword.GetValueOrDefault()! : node.EnumKeyword,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			baseList.HasValue ? baseList.GetValueOrDefault()! : node.BaseList,
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			members.HasValue ? members.GetValueOrDefault()! : node.Members,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static DelegateDeclarationSyntax PartialUpdate(
		this DelegateDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> delegateKeyword = default,
		Option<TypeSyntax> returnType = default,
		Option<SyntaxToken> identifier = default,
		Option<TypeParameterListSyntax?> typeParameterList = default,
		Option<ParameterListSyntax> parameterList = default,
		Option<SyntaxList<TypeParameterConstraintClauseSyntax>> constraintClauses = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			delegateKeyword.HasValue ? delegateKeyword.GetValueOrDefault()! : node.DelegateKeyword,
			returnType.HasValue ? returnType.GetValueOrDefault()! : node.ReturnType,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			typeParameterList.HasValue ? typeParameterList.GetValueOrDefault()! : node.TypeParameterList,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			constraintClauses.HasValue ? constraintClauses.GetValueOrDefault()! : node.ConstraintClauses,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static EnumMemberDeclarationSyntax PartialUpdate(
		this EnumMemberDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> identifier = default,
		Option<EqualsValueClauseSyntax?> equalsValue = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			equalsValue.HasValue ? equalsValue.GetValueOrDefault()! : node.EqualsValue );
	public static BaseListSyntax PartialUpdate(
		this BaseListSyntax node,
		Option<SyntaxToken> colonToken = default,
		Option<SeparatedSyntaxList<BaseTypeSyntax>> types = default )
		=> node.Update(
			colonToken.HasValue ? colonToken.GetValueOrDefault()! : node.ColonToken,
			types.HasValue ? types.GetValueOrDefault()! : node.Types );
	public static SimpleBaseTypeSyntax PartialUpdate(
		this SimpleBaseTypeSyntax node,
		Option<TypeSyntax> type = default )
		=> node.Update(
			type.HasValue ? type.GetValueOrDefault()! : node.Type );
	public static PrimaryConstructorBaseTypeSyntax PartialUpdate(
		this PrimaryConstructorBaseTypeSyntax node,
		Option<TypeSyntax> type = default,
		Option<ArgumentListSyntax> argumentList = default )
		=> node.Update(
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			argumentList.HasValue ? argumentList.GetValueOrDefault()! : node.ArgumentList );
	public static TypeParameterConstraintClauseSyntax PartialUpdate(
		this TypeParameterConstraintClauseSyntax node,
		Option<SyntaxToken> whereKeyword = default,
		Option<IdentifierNameSyntax> name = default,
		Option<SyntaxToken> colonToken = default,
		Option<SeparatedSyntaxList<TypeParameterConstraintSyntax>> constraints = default )
		=> node.Update(
			whereKeyword.HasValue ? whereKeyword.GetValueOrDefault()! : node.WhereKeyword,
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			colonToken.HasValue ? colonToken.GetValueOrDefault()! : node.ColonToken,
			constraints.HasValue ? constraints.GetValueOrDefault()! : node.Constraints );
	public static ConstructorConstraintSyntax PartialUpdate(
		this ConstructorConstraintSyntax node,
		Option<SyntaxToken> newKeyword = default,
		Option<SyntaxToken> openParenToken = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			newKeyword.HasValue ? newKeyword.GetValueOrDefault()! : node.NewKeyword,
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static ClassOrStructConstraintSyntax PartialUpdate(
		this ClassOrStructConstraintSyntax node,
		Option<SyntaxToken> classOrStructKeyword = default,
		Option<SyntaxToken> questionToken = default )
		=> node.Update(
			classOrStructKeyword.HasValue ? classOrStructKeyword.GetValueOrDefault()! : node.ClassOrStructKeyword,
			questionToken.HasValue ? questionToken.GetValueOrDefault()! : node.QuestionToken );
	public static TypeConstraintSyntax PartialUpdate(
		this TypeConstraintSyntax node,
		Option<TypeSyntax> type = default )
		=> node.Update(
			type.HasValue ? type.GetValueOrDefault()! : node.Type );
	public static DefaultConstraintSyntax PartialUpdate(
		this DefaultConstraintSyntax node,
		Option<SyntaxToken> defaultKeyword = default )
		=> node.Update(
			defaultKeyword.HasValue ? defaultKeyword.GetValueOrDefault()! : node.DefaultKeyword );
	public static AllowsConstraintClauseSyntax PartialUpdate(
		this AllowsConstraintClauseSyntax node,
		Option<SyntaxToken> allowsKeyword = default,
		Option<SeparatedSyntaxList<AllowsConstraintSyntax>> constraints = default )
		=> node.Update(
			allowsKeyword.HasValue ? allowsKeyword.GetValueOrDefault()! : node.AllowsKeyword,
			constraints.HasValue ? constraints.GetValueOrDefault()! : node.Constraints );
	public static RefStructConstraintSyntax PartialUpdate(
		this RefStructConstraintSyntax node,
		Option<SyntaxToken> refKeyword = default,
		Option<SyntaxToken> structKeyword = default )
		=> node.Update(
			refKeyword.HasValue ? refKeyword.GetValueOrDefault()! : node.RefKeyword,
			structKeyword.HasValue ? structKeyword.GetValueOrDefault()! : node.StructKeyword );
	public static FieldDeclarationSyntax PartialUpdate(
		this FieldDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<VariableDeclarationSyntax> declaration = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			declaration.HasValue ? declaration.GetValueOrDefault()! : node.Declaration,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static EventFieldDeclarationSyntax PartialUpdate(
		this EventFieldDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> eventKeyword = default,
		Option<VariableDeclarationSyntax> declaration = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			eventKeyword.HasValue ? eventKeyword.GetValueOrDefault()! : node.EventKeyword,
			declaration.HasValue ? declaration.GetValueOrDefault()! : node.Declaration,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static ExplicitInterfaceSpecifierSyntax PartialUpdate(
		this ExplicitInterfaceSpecifierSyntax node,
		Option<NameSyntax> name = default,
		Option<SyntaxToken> dotToken = default )
		=> node.Update(
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			dotToken.HasValue ? dotToken.GetValueOrDefault()! : node.DotToken );
	public static MethodDeclarationSyntax PartialUpdate(
		this MethodDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<TypeSyntax> returnType = default,
		Option<ExplicitInterfaceSpecifierSyntax?> explicitInterfaceSpecifier = default,
		Option<SyntaxToken> identifier = default,
		Option<TypeParameterListSyntax?> typeParameterList = default,
		Option<ParameterListSyntax> parameterList = default,
		Option<SyntaxList<TypeParameterConstraintClauseSyntax>> constraintClauses = default,
		Option<BlockSyntax?> body = default,
		Option<ArrowExpressionClauseSyntax?> expressionBody = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			returnType.HasValue ? returnType.GetValueOrDefault()! : node.ReturnType,
			explicitInterfaceSpecifier.HasValue ? explicitInterfaceSpecifier.GetValueOrDefault()! : node.ExplicitInterfaceSpecifier,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			typeParameterList.HasValue ? typeParameterList.GetValueOrDefault()! : node.TypeParameterList,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			constraintClauses.HasValue ? constraintClauses.GetValueOrDefault()! : node.ConstraintClauses,
			body.HasValue ? body.GetValueOrDefault()! : node.Body,
			expressionBody.HasValue ? expressionBody.GetValueOrDefault()! : node.ExpressionBody,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static OperatorDeclarationSyntax PartialUpdate(
		this OperatorDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<TypeSyntax> returnType = default,
		Option<ExplicitInterfaceSpecifierSyntax?> explicitInterfaceSpecifier = default,
		Option<SyntaxToken> operatorKeyword = default,
		Option<SyntaxToken> checkedKeyword = default,
		Option<SyntaxToken> operatorToken = default,
		Option<ParameterListSyntax> parameterList = default,
		Option<BlockSyntax?> body = default,
		Option<ArrowExpressionClauseSyntax?> expressionBody = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			returnType.HasValue ? returnType.GetValueOrDefault()! : node.ReturnType,
			explicitInterfaceSpecifier.HasValue ? explicitInterfaceSpecifier.GetValueOrDefault()! : node.ExplicitInterfaceSpecifier,
			operatorKeyword.HasValue ? operatorKeyword.GetValueOrDefault()! : node.OperatorKeyword,
			checkedKeyword.HasValue ? checkedKeyword.GetValueOrDefault()! : node.CheckedKeyword,
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			body.HasValue ? body.GetValueOrDefault()! : node.Body,
			expressionBody.HasValue ? expressionBody.GetValueOrDefault()! : node.ExpressionBody,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static ConversionOperatorDeclarationSyntax PartialUpdate(
		this ConversionOperatorDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> implicitOrExplicitKeyword = default,
		Option<ExplicitInterfaceSpecifierSyntax?> explicitInterfaceSpecifier = default,
		Option<SyntaxToken> operatorKeyword = default,
		Option<SyntaxToken> checkedKeyword = default,
		Option<TypeSyntax> type = default,
		Option<ParameterListSyntax> parameterList = default,
		Option<BlockSyntax?> body = default,
		Option<ArrowExpressionClauseSyntax?> expressionBody = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			implicitOrExplicitKeyword.HasValue ? implicitOrExplicitKeyword.GetValueOrDefault()! : node.ImplicitOrExplicitKeyword,
			explicitInterfaceSpecifier.HasValue ? explicitInterfaceSpecifier.GetValueOrDefault()! : node.ExplicitInterfaceSpecifier,
			operatorKeyword.HasValue ? operatorKeyword.GetValueOrDefault()! : node.OperatorKeyword,
			checkedKeyword.HasValue ? checkedKeyword.GetValueOrDefault()! : node.CheckedKeyword,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			body.HasValue ? body.GetValueOrDefault()! : node.Body,
			expressionBody.HasValue ? expressionBody.GetValueOrDefault()! : node.ExpressionBody,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static ConstructorDeclarationSyntax PartialUpdate(
		this ConstructorDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> identifier = default,
		Option<ParameterListSyntax> parameterList = default,
		Option<ConstructorInitializerSyntax?> initializer = default,
		Option<BlockSyntax?> body = default,
		Option<ArrowExpressionClauseSyntax?> expressionBody = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			initializer.HasValue ? initializer.GetValueOrDefault()! : node.Initializer,
			body.HasValue ? body.GetValueOrDefault()! : node.Body,
			expressionBody.HasValue ? expressionBody.GetValueOrDefault()! : node.ExpressionBody,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static ConstructorInitializerSyntax PartialUpdate(
		this ConstructorInitializerSyntax node,
		Option<SyntaxToken> colonToken = default,
		Option<SyntaxToken> thisOrBaseKeyword = default,
		Option<ArgumentListSyntax> argumentList = default )
		=> node.Update(
			colonToken.HasValue ? colonToken.GetValueOrDefault()! : node.ColonToken,
			thisOrBaseKeyword.HasValue ? thisOrBaseKeyword.GetValueOrDefault()! : node.ThisOrBaseKeyword,
			argumentList.HasValue ? argumentList.GetValueOrDefault()! : node.ArgumentList );
	public static DestructorDeclarationSyntax PartialUpdate(
		this DestructorDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> tildeToken = default,
		Option<SyntaxToken> identifier = default,
		Option<ParameterListSyntax> parameterList = default,
		Option<BlockSyntax?> body = default,
		Option<ArrowExpressionClauseSyntax?> expressionBody = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			tildeToken.HasValue ? tildeToken.GetValueOrDefault()! : node.TildeToken,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			body.HasValue ? body.GetValueOrDefault()! : node.Body,
			expressionBody.HasValue ? expressionBody.GetValueOrDefault()! : node.ExpressionBody,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static PropertyDeclarationSyntax PartialUpdate(
		this PropertyDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<TypeSyntax> type = default,
		Option<ExplicitInterfaceSpecifierSyntax?> explicitInterfaceSpecifier = default,
		Option<SyntaxToken> identifier = default,
		Option<AccessorListSyntax?> accessorList = default,
		Option<ArrowExpressionClauseSyntax?> expressionBody = default,
		Option<EqualsValueClauseSyntax?> initializer = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			explicitInterfaceSpecifier.HasValue ? explicitInterfaceSpecifier.GetValueOrDefault()! : node.ExplicitInterfaceSpecifier,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			accessorList.HasValue ? accessorList.GetValueOrDefault()! : node.AccessorList,
			expressionBody.HasValue ? expressionBody.GetValueOrDefault()! : node.ExpressionBody,
			initializer.HasValue ? initializer.GetValueOrDefault()! : node.Initializer,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static ArrowExpressionClauseSyntax PartialUpdate(
		this ArrowExpressionClauseSyntax node,
		Option<SyntaxToken> arrowToken = default,
		Option<ExpressionSyntax> expression = default )
		=> node.Update(
			arrowToken.HasValue ? arrowToken.GetValueOrDefault()! : node.ArrowToken,
			expression.HasValue ? expression.GetValueOrDefault()! : node.Expression );
	public static EventDeclarationSyntax PartialUpdate(
		this EventDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> eventKeyword = default,
		Option<TypeSyntax> type = default,
		Option<ExplicitInterfaceSpecifierSyntax?> explicitInterfaceSpecifier = default,
		Option<SyntaxToken> identifier = default,
		Option<AccessorListSyntax?> accessorList = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			eventKeyword.HasValue ? eventKeyword.GetValueOrDefault()! : node.EventKeyword,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			explicitInterfaceSpecifier.HasValue ? explicitInterfaceSpecifier.GetValueOrDefault()! : node.ExplicitInterfaceSpecifier,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			accessorList.HasValue ? accessorList.GetValueOrDefault()! : node.AccessorList,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static IndexerDeclarationSyntax PartialUpdate(
		this IndexerDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<TypeSyntax> type = default,
		Option<ExplicitInterfaceSpecifierSyntax?> explicitInterfaceSpecifier = default,
		Option<SyntaxToken> thisKeyword = default,
		Option<BracketedParameterListSyntax> parameterList = default,
		Option<AccessorListSyntax?> accessorList = default,
		Option<ArrowExpressionClauseSyntax?> expressionBody = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			explicitInterfaceSpecifier.HasValue ? explicitInterfaceSpecifier.GetValueOrDefault()! : node.ExplicitInterfaceSpecifier,
			thisKeyword.HasValue ? thisKeyword.GetValueOrDefault()! : node.ThisKeyword,
			parameterList.HasValue ? parameterList.GetValueOrDefault()! : node.ParameterList,
			accessorList.HasValue ? accessorList.GetValueOrDefault()! : node.AccessorList,
			expressionBody.HasValue ? expressionBody.GetValueOrDefault()! : node.ExpressionBody,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static AccessorListSyntax PartialUpdate(
		this AccessorListSyntax node,
		Option<SyntaxToken> openBraceToken = default,
		Option<SyntaxList<AccessorDeclarationSyntax>> accessors = default,
		Option<SyntaxToken> closeBraceToken = default )
		=> node.Update(
			openBraceToken.HasValue ? openBraceToken.GetValueOrDefault()! : node.OpenBraceToken,
			accessors.HasValue ? accessors.GetValueOrDefault()! : node.Accessors,
			closeBraceToken.HasValue ? closeBraceToken.GetValueOrDefault()! : node.CloseBraceToken );
	public static AccessorDeclarationSyntax PartialUpdate(
		this AccessorDeclarationSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<SyntaxToken> keyword = default,
		Option<BlockSyntax?> body = default,
		Option<ArrowExpressionClauseSyntax?> expressionBody = default,
		Option<SyntaxToken> semicolonToken = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			keyword.HasValue ? keyword.GetValueOrDefault()! : node.Keyword,
			body.HasValue ? body.GetValueOrDefault()! : node.Body,
			expressionBody.HasValue ? expressionBody.GetValueOrDefault()! : node.ExpressionBody,
			semicolonToken.HasValue ? semicolonToken.GetValueOrDefault()! : node.SemicolonToken );
	public static ParameterListSyntax PartialUpdate(
		this ParameterListSyntax node,
		Option<SyntaxToken> openParenToken = default,
		Option<SeparatedSyntaxList<ParameterSyntax>> parameters = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			parameters.HasValue ? parameters.GetValueOrDefault()! : node.Parameters,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static BracketedParameterListSyntax PartialUpdate(
		this BracketedParameterListSyntax node,
		Option<SyntaxToken> openBracketToken = default,
		Option<SeparatedSyntaxList<ParameterSyntax>> parameters = default,
		Option<SyntaxToken> closeBracketToken = default )
		=> node.Update(
			openBracketToken.HasValue ? openBracketToken.GetValueOrDefault()! : node.OpenBracketToken,
			parameters.HasValue ? parameters.GetValueOrDefault()! : node.Parameters,
			closeBracketToken.HasValue ? closeBracketToken.GetValueOrDefault()! : node.CloseBracketToken );
	public static ParameterSyntax PartialUpdate(
		this ParameterSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<TypeSyntax?> type = default,
		Option<SyntaxToken> identifier = default,
		Option<EqualsValueClauseSyntax?> @default = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			@default.HasValue ? @default.GetValueOrDefault()! : node.Default );
	public static FunctionPointerParameterSyntax PartialUpdate(
		this FunctionPointerParameterSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<TypeSyntax> type = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			type.HasValue ? type.GetValueOrDefault()! : node.Type );
	public static IncompleteMemberSyntax PartialUpdate(
		this IncompleteMemberSyntax node,
		Option<SyntaxList<AttributeListSyntax>> attributeLists = default,
		Option<SyntaxTokenList> modifiers = default,
		Option<TypeSyntax?> type = default )
		=> node.Update(
			attributeLists.HasValue ? attributeLists.GetValueOrDefault()! : node.AttributeLists,
			modifiers.HasValue ? modifiers.GetValueOrDefault()! : node.Modifiers,
			type.HasValue ? type.GetValueOrDefault()! : node.Type );
	public static SkippedTokensTriviaSyntax PartialUpdate(
		this SkippedTokensTriviaSyntax node,
		Option<SyntaxTokenList> tokens = default )
		=> node.Update(
			tokens.HasValue ? tokens.GetValueOrDefault()! : node.Tokens );
	public static DocumentationCommentTriviaSyntax PartialUpdate(
		this DocumentationCommentTriviaSyntax node,
		Option<SyntaxList<XmlNodeSyntax>> content = default,
		Option<SyntaxToken> endOfComment = default )
		=> node.Update(
			content.HasValue ? content.GetValueOrDefault()! : node.Content,
			endOfComment.HasValue ? endOfComment.GetValueOrDefault()! : node.EndOfComment );
	public static TypeCrefSyntax PartialUpdate(
		this TypeCrefSyntax node,
		Option<TypeSyntax> type = default )
		=> node.Update(
			type.HasValue ? type.GetValueOrDefault()! : node.Type );
	public static QualifiedCrefSyntax PartialUpdate(
		this QualifiedCrefSyntax node,
		Option<TypeSyntax> container = default,
		Option<SyntaxToken> dotToken = default,
		Option<MemberCrefSyntax> member = default )
		=> node.Update(
			container.HasValue ? container.GetValueOrDefault()! : node.Container,
			dotToken.HasValue ? dotToken.GetValueOrDefault()! : node.DotToken,
			member.HasValue ? member.GetValueOrDefault()! : node.Member );
	public static NameMemberCrefSyntax PartialUpdate(
		this NameMemberCrefSyntax node,
		Option<TypeSyntax> name = default,
		Option<CrefParameterListSyntax?> parameters = default )
		=> node.Update(
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			parameters.HasValue ? parameters.GetValueOrDefault()! : node.Parameters );
	public static IndexerMemberCrefSyntax PartialUpdate(
		this IndexerMemberCrefSyntax node,
		Option<SyntaxToken> thisKeyword = default,
		Option<CrefBracketedParameterListSyntax?> parameters = default )
		=> node.Update(
			thisKeyword.HasValue ? thisKeyword.GetValueOrDefault()! : node.ThisKeyword,
			parameters.HasValue ? parameters.GetValueOrDefault()! : node.Parameters );
	public static OperatorMemberCrefSyntax PartialUpdate(
		this OperatorMemberCrefSyntax node,
		Option<SyntaxToken> operatorKeyword = default,
		Option<SyntaxToken> checkedKeyword = default,
		Option<SyntaxToken> operatorToken = default,
		Option<CrefParameterListSyntax?> parameters = default )
		=> node.Update(
			operatorKeyword.HasValue ? operatorKeyword.GetValueOrDefault()! : node.OperatorKeyword,
			checkedKeyword.HasValue ? checkedKeyword.GetValueOrDefault()! : node.CheckedKeyword,
			operatorToken.HasValue ? operatorToken.GetValueOrDefault()! : node.OperatorToken,
			parameters.HasValue ? parameters.GetValueOrDefault()! : node.Parameters );
	public static ConversionOperatorMemberCrefSyntax PartialUpdate(
		this ConversionOperatorMemberCrefSyntax node,
		Option<SyntaxToken> implicitOrExplicitKeyword = default,
		Option<SyntaxToken> operatorKeyword = default,
		Option<SyntaxToken> checkedKeyword = default,
		Option<TypeSyntax> type = default,
		Option<CrefParameterListSyntax?> parameters = default )
		=> node.Update(
			implicitOrExplicitKeyword.HasValue ? implicitOrExplicitKeyword.GetValueOrDefault()! : node.ImplicitOrExplicitKeyword,
			operatorKeyword.HasValue ? operatorKeyword.GetValueOrDefault()! : node.OperatorKeyword,
			checkedKeyword.HasValue ? checkedKeyword.GetValueOrDefault()! : node.CheckedKeyword,
			type.HasValue ? type.GetValueOrDefault()! : node.Type,
			parameters.HasValue ? parameters.GetValueOrDefault()! : node.Parameters );
	public static CrefParameterListSyntax PartialUpdate(
		this CrefParameterListSyntax node,
		Option<SyntaxToken> openParenToken = default,
		Option<SeparatedSyntaxList<CrefParameterSyntax>> parameters = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			parameters.HasValue ? parameters.GetValueOrDefault()! : node.Parameters,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static CrefBracketedParameterListSyntax PartialUpdate(
		this CrefBracketedParameterListSyntax node,
		Option<SyntaxToken> openBracketToken = default,
		Option<SeparatedSyntaxList<CrefParameterSyntax>> parameters = default,
		Option<SyntaxToken> closeBracketToken = default )
		=> node.Update(
			openBracketToken.HasValue ? openBracketToken.GetValueOrDefault()! : node.OpenBracketToken,
			parameters.HasValue ? parameters.GetValueOrDefault()! : node.Parameters,
			closeBracketToken.HasValue ? closeBracketToken.GetValueOrDefault()! : node.CloseBracketToken );
	public static CrefParameterSyntax PartialUpdate(
		this CrefParameterSyntax node,
		Option<SyntaxToken> refKindKeyword = default,
		Option<SyntaxToken> readOnlyKeyword = default,
		Option<TypeSyntax> type = default )
		=> node.Update(
			refKindKeyword.HasValue ? refKindKeyword.GetValueOrDefault()! : node.RefKindKeyword,
			readOnlyKeyword.HasValue ? readOnlyKeyword.GetValueOrDefault()! : node.ReadOnlyKeyword,
			type.HasValue ? type.GetValueOrDefault()! : node.Type );
	public static XmlElementSyntax PartialUpdate(
		this XmlElementSyntax node,
		Option<XmlElementStartTagSyntax> startTag = default,
		Option<SyntaxList<XmlNodeSyntax>> content = default,
		Option<XmlElementEndTagSyntax> endTag = default )
		=> node.Update(
			startTag.HasValue ? startTag.GetValueOrDefault()! : node.StartTag,
			content.HasValue ? content.GetValueOrDefault()! : node.Content,
			endTag.HasValue ? endTag.GetValueOrDefault()! : node.EndTag );
	public static XmlElementStartTagSyntax PartialUpdate(
		this XmlElementStartTagSyntax node,
		Option<SyntaxToken> lessThanToken = default,
		Option<XmlNameSyntax> name = default,
		Option<SyntaxList<XmlAttributeSyntax>> attributes = default,
		Option<SyntaxToken> greaterThanToken = default )
		=> node.Update(
			lessThanToken.HasValue ? lessThanToken.GetValueOrDefault()! : node.LessThanToken,
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			attributes.HasValue ? attributes.GetValueOrDefault()! : node.Attributes,
			greaterThanToken.HasValue ? greaterThanToken.GetValueOrDefault()! : node.GreaterThanToken );
	public static XmlElementEndTagSyntax PartialUpdate(
		this XmlElementEndTagSyntax node,
		Option<SyntaxToken> lessThanSlashToken = default,
		Option<XmlNameSyntax> name = default,
		Option<SyntaxToken> greaterThanToken = default )
		=> node.Update(
			lessThanSlashToken.HasValue ? lessThanSlashToken.GetValueOrDefault()! : node.LessThanSlashToken,
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			greaterThanToken.HasValue ? greaterThanToken.GetValueOrDefault()! : node.GreaterThanToken );
	public static XmlEmptyElementSyntax PartialUpdate(
		this XmlEmptyElementSyntax node,
		Option<SyntaxToken> lessThanToken = default,
		Option<XmlNameSyntax> name = default,
		Option<SyntaxList<XmlAttributeSyntax>> attributes = default,
		Option<SyntaxToken> slashGreaterThanToken = default )
		=> node.Update(
			lessThanToken.HasValue ? lessThanToken.GetValueOrDefault()! : node.LessThanToken,
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			attributes.HasValue ? attributes.GetValueOrDefault()! : node.Attributes,
			slashGreaterThanToken.HasValue ? slashGreaterThanToken.GetValueOrDefault()! : node.SlashGreaterThanToken );
	public static XmlNameSyntax PartialUpdate(
		this XmlNameSyntax node,
		Option<XmlPrefixSyntax?> prefix = default,
		Option<SyntaxToken> localName = default )
		=> node.Update(
			prefix.HasValue ? prefix.GetValueOrDefault()! : node.Prefix,
			localName.HasValue ? localName.GetValueOrDefault()! : node.LocalName );
	public static XmlPrefixSyntax PartialUpdate(
		this XmlPrefixSyntax node,
		Option<SyntaxToken> prefix = default,
		Option<SyntaxToken> colonToken = default )
		=> node.Update(
			prefix.HasValue ? prefix.GetValueOrDefault()! : node.Prefix,
			colonToken.HasValue ? colonToken.GetValueOrDefault()! : node.ColonToken );
	public static XmlTextAttributeSyntax PartialUpdate(
		this XmlTextAttributeSyntax node,
		Option<XmlNameSyntax> name = default,
		Option<SyntaxToken> equalsToken = default,
		Option<SyntaxToken> startQuoteToken = default,
		Option<SyntaxTokenList> textTokens = default,
		Option<SyntaxToken> endQuoteToken = default )
		=> node.Update(
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			equalsToken.HasValue ? equalsToken.GetValueOrDefault()! : node.EqualsToken,
			startQuoteToken.HasValue ? startQuoteToken.GetValueOrDefault()! : node.StartQuoteToken,
			textTokens.HasValue ? textTokens.GetValueOrDefault()! : node.TextTokens,
			endQuoteToken.HasValue ? endQuoteToken.GetValueOrDefault()! : node.EndQuoteToken );
	public static XmlCrefAttributeSyntax PartialUpdate(
		this XmlCrefAttributeSyntax node,
		Option<XmlNameSyntax> name = default,
		Option<SyntaxToken> equalsToken = default,
		Option<SyntaxToken> startQuoteToken = default,
		Option<CrefSyntax> cref = default,
		Option<SyntaxToken> endQuoteToken = default )
		=> node.Update(
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			equalsToken.HasValue ? equalsToken.GetValueOrDefault()! : node.EqualsToken,
			startQuoteToken.HasValue ? startQuoteToken.GetValueOrDefault()! : node.StartQuoteToken,
			cref.HasValue ? cref.GetValueOrDefault()! : node.Cref,
			endQuoteToken.HasValue ? endQuoteToken.GetValueOrDefault()! : node.EndQuoteToken );
	public static XmlNameAttributeSyntax PartialUpdate(
		this XmlNameAttributeSyntax node,
		Option<XmlNameSyntax> name = default,
		Option<SyntaxToken> equalsToken = default,
		Option<SyntaxToken> startQuoteToken = default,
		Option<IdentifierNameSyntax> identifier = default,
		Option<SyntaxToken> endQuoteToken = default )
		=> node.Update(
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			equalsToken.HasValue ? equalsToken.GetValueOrDefault()! : node.EqualsToken,
			startQuoteToken.HasValue ? startQuoteToken.GetValueOrDefault()! : node.StartQuoteToken,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			endQuoteToken.HasValue ? endQuoteToken.GetValueOrDefault()! : node.EndQuoteToken );
	public static XmlTextSyntax PartialUpdate(
		this XmlTextSyntax node,
		Option<SyntaxTokenList> textTokens = default )
		=> node.Update(
			textTokens.HasValue ? textTokens.GetValueOrDefault()! : node.TextTokens );
	public static XmlCDataSectionSyntax PartialUpdate(
		this XmlCDataSectionSyntax node,
		Option<SyntaxToken> startCDataToken = default,
		Option<SyntaxTokenList> textTokens = default,
		Option<SyntaxToken> endCDataToken = default )
		=> node.Update(
			startCDataToken.HasValue ? startCDataToken.GetValueOrDefault()! : node.StartCDataToken,
			textTokens.HasValue ? textTokens.GetValueOrDefault()! : node.TextTokens,
			endCDataToken.HasValue ? endCDataToken.GetValueOrDefault()! : node.EndCDataToken );
	public static XmlProcessingInstructionSyntax PartialUpdate(
		this XmlProcessingInstructionSyntax node,
		Option<SyntaxToken> startProcessingInstructionToken = default,
		Option<XmlNameSyntax> name = default,
		Option<SyntaxTokenList> textTokens = default,
		Option<SyntaxToken> endProcessingInstructionToken = default )
		=> node.Update(
			startProcessingInstructionToken.HasValue ? startProcessingInstructionToken.GetValueOrDefault()! : node.StartProcessingInstructionToken,
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			textTokens.HasValue ? textTokens.GetValueOrDefault()! : node.TextTokens,
			endProcessingInstructionToken.HasValue ? endProcessingInstructionToken.GetValueOrDefault()! : node.EndProcessingInstructionToken );
	public static XmlCommentSyntax PartialUpdate(
		this XmlCommentSyntax node,
		Option<SyntaxToken> lessThanExclamationMinusMinusToken = default,
		Option<SyntaxTokenList> textTokens = default,
		Option<SyntaxToken> minusMinusGreaterThanToken = default )
		=> node.Update(
			lessThanExclamationMinusMinusToken.HasValue ? lessThanExclamationMinusMinusToken.GetValueOrDefault()! : node.LessThanExclamationMinusMinusToken,
			textTokens.HasValue ? textTokens.GetValueOrDefault()! : node.TextTokens,
			minusMinusGreaterThanToken.HasValue ? minusMinusGreaterThanToken.GetValueOrDefault()! : node.MinusMinusGreaterThanToken );
	public static IfDirectiveTriviaSyntax PartialUpdate(
		this IfDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> ifKeyword = default,
		Option<ExpressionSyntax> condition = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default,
		Option<bool> branchTaken = default,
		Option<bool> conditionValue = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			ifKeyword.HasValue ? ifKeyword.GetValueOrDefault()! : node.IfKeyword,
			condition.HasValue ? condition.GetValueOrDefault()! : node.Condition,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive,
			branchTaken.HasValue ? branchTaken.GetValueOrDefault()! : node.BranchTaken,
			conditionValue.HasValue ? conditionValue.GetValueOrDefault()! : node.ConditionValue );
	public static ElifDirectiveTriviaSyntax PartialUpdate(
		this ElifDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> elifKeyword = default,
		Option<ExpressionSyntax> condition = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default,
		Option<bool> branchTaken = default,
		Option<bool> conditionValue = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			elifKeyword.HasValue ? elifKeyword.GetValueOrDefault()! : node.ElifKeyword,
			condition.HasValue ? condition.GetValueOrDefault()! : node.Condition,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive,
			branchTaken.HasValue ? branchTaken.GetValueOrDefault()! : node.BranchTaken,
			conditionValue.HasValue ? conditionValue.GetValueOrDefault()! : node.ConditionValue );
	public static ElseDirectiveTriviaSyntax PartialUpdate(
		this ElseDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> elseKeyword = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default,
		Option<bool> branchTaken = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			elseKeyword.HasValue ? elseKeyword.GetValueOrDefault()! : node.ElseKeyword,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive,
			branchTaken.HasValue ? branchTaken.GetValueOrDefault()! : node.BranchTaken );
	public static EndIfDirectiveTriviaSyntax PartialUpdate(
		this EndIfDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> endIfKeyword = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			endIfKeyword.HasValue ? endIfKeyword.GetValueOrDefault()! : node.EndIfKeyword,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static RegionDirectiveTriviaSyntax PartialUpdate(
		this RegionDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> regionKeyword = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			regionKeyword.HasValue ? regionKeyword.GetValueOrDefault()! : node.RegionKeyword,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static EndRegionDirectiveTriviaSyntax PartialUpdate(
		this EndRegionDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> endRegionKeyword = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			endRegionKeyword.HasValue ? endRegionKeyword.GetValueOrDefault()! : node.EndRegionKeyword,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static ErrorDirectiveTriviaSyntax PartialUpdate(
		this ErrorDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> errorKeyword = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			errorKeyword.HasValue ? errorKeyword.GetValueOrDefault()! : node.ErrorKeyword,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static WarningDirectiveTriviaSyntax PartialUpdate(
		this WarningDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> warningKeyword = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			warningKeyword.HasValue ? warningKeyword.GetValueOrDefault()! : node.WarningKeyword,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static BadDirectiveTriviaSyntax PartialUpdate(
		this BadDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> identifier = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			identifier.HasValue ? identifier.GetValueOrDefault()! : node.Identifier,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static DefineDirectiveTriviaSyntax PartialUpdate(
		this DefineDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> defineKeyword = default,
		Option<SyntaxToken> name = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			defineKeyword.HasValue ? defineKeyword.GetValueOrDefault()! : node.DefineKeyword,
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static UndefDirectiveTriviaSyntax PartialUpdate(
		this UndefDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> undefKeyword = default,
		Option<SyntaxToken> name = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			undefKeyword.HasValue ? undefKeyword.GetValueOrDefault()! : node.UndefKeyword,
			name.HasValue ? name.GetValueOrDefault()! : node.Name,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static LineDirectiveTriviaSyntax PartialUpdate(
		this LineDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> lineKeyword = default,
		Option<SyntaxToken> line = default,
		Option<SyntaxToken> @file = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			lineKeyword.HasValue ? lineKeyword.GetValueOrDefault()! : node.LineKeyword,
			line.HasValue ? line.GetValueOrDefault()! : node.Line,
			@file.HasValue ? @file.GetValueOrDefault()! : node.File,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static LineDirectivePositionSyntax PartialUpdate(
		this LineDirectivePositionSyntax node,
		Option<SyntaxToken> openParenToken = default,
		Option<SyntaxToken> line = default,
		Option<SyntaxToken> commaToken = default,
		Option<SyntaxToken> character = default,
		Option<SyntaxToken> closeParenToken = default )
		=> node.Update(
			openParenToken.HasValue ? openParenToken.GetValueOrDefault()! : node.OpenParenToken,
			line.HasValue ? line.GetValueOrDefault()! : node.Line,
			commaToken.HasValue ? commaToken.GetValueOrDefault()! : node.CommaToken,
			character.HasValue ? character.GetValueOrDefault()! : node.Character,
			closeParenToken.HasValue ? closeParenToken.GetValueOrDefault()! : node.CloseParenToken );
	public static LineSpanDirectiveTriviaSyntax PartialUpdate(
		this LineSpanDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> lineKeyword = default,
		Option<LineDirectivePositionSyntax> start = default,
		Option<SyntaxToken> minusToken = default,
		Option<LineDirectivePositionSyntax> end = default,
		Option<SyntaxToken> characterOffset = default,
		Option<SyntaxToken> @file = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			lineKeyword.HasValue ? lineKeyword.GetValueOrDefault()! : node.LineKeyword,
			start.HasValue ? start.GetValueOrDefault()! : node.Start,
			minusToken.HasValue ? minusToken.GetValueOrDefault()! : node.MinusToken,
			end.HasValue ? end.GetValueOrDefault()! : node.End,
			characterOffset.HasValue ? characterOffset.GetValueOrDefault()! : node.CharacterOffset,
			@file.HasValue ? @file.GetValueOrDefault()! : node.File,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static PragmaWarningDirectiveTriviaSyntax PartialUpdate(
		this PragmaWarningDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> pragmaKeyword = default,
		Option<SyntaxToken> warningKeyword = default,
		Option<SyntaxToken> disableOrRestoreKeyword = default,
		Option<SeparatedSyntaxList<ExpressionSyntax>> errorCodes = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			pragmaKeyword.HasValue ? pragmaKeyword.GetValueOrDefault()! : node.PragmaKeyword,
			warningKeyword.HasValue ? warningKeyword.GetValueOrDefault()! : node.WarningKeyword,
			disableOrRestoreKeyword.HasValue ? disableOrRestoreKeyword.GetValueOrDefault()! : node.DisableOrRestoreKeyword,
			errorCodes.HasValue ? errorCodes.GetValueOrDefault()! : node.ErrorCodes,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static PragmaChecksumDirectiveTriviaSyntax PartialUpdate(
		this PragmaChecksumDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> pragmaKeyword = default,
		Option<SyntaxToken> checksumKeyword = default,
		Option<SyntaxToken> @file = default,
		Option<SyntaxToken> guid = default,
		Option<SyntaxToken> bytes = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			pragmaKeyword.HasValue ? pragmaKeyword.GetValueOrDefault()! : node.PragmaKeyword,
			checksumKeyword.HasValue ? checksumKeyword.GetValueOrDefault()! : node.ChecksumKeyword,
			@file.HasValue ? @file.GetValueOrDefault()! : node.File,
			guid.HasValue ? guid.GetValueOrDefault()! : node.Guid,
			bytes.HasValue ? bytes.GetValueOrDefault()! : node.Bytes,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static ReferenceDirectiveTriviaSyntax PartialUpdate(
		this ReferenceDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> referenceKeyword = default,
		Option<SyntaxToken> @file = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			referenceKeyword.HasValue ? referenceKeyword.GetValueOrDefault()! : node.ReferenceKeyword,
			@file.HasValue ? @file.GetValueOrDefault()! : node.File,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static LoadDirectiveTriviaSyntax PartialUpdate(
		this LoadDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> loadKeyword = default,
		Option<SyntaxToken> @file = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			loadKeyword.HasValue ? loadKeyword.GetValueOrDefault()! : node.LoadKeyword,
			@file.HasValue ? @file.GetValueOrDefault()! : node.File,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static ShebangDirectiveTriviaSyntax PartialUpdate(
		this ShebangDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> exclamationToken = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			exclamationToken.HasValue ? exclamationToken.GetValueOrDefault()! : node.ExclamationToken,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
	public static NullableDirectiveTriviaSyntax PartialUpdate(
		this NullableDirectiveTriviaSyntax node,
		Option<SyntaxToken> hashToken = default,
		Option<SyntaxToken> nullableKeyword = default,
		Option<SyntaxToken> settingToken = default,
		Option<SyntaxToken> targetToken = default,
		Option<SyntaxToken> endOfDirectiveToken = default,
		Option<bool> isActive = default )
		=> node.Update(
			hashToken.HasValue ? hashToken.GetValueOrDefault()! : node.HashToken,
			nullableKeyword.HasValue ? nullableKeyword.GetValueOrDefault()! : node.NullableKeyword,
			settingToken.HasValue ? settingToken.GetValueOrDefault()! : node.SettingToken,
			targetToken.HasValue ? targetToken.GetValueOrDefault()! : node.TargetToken,
			endOfDirectiveToken.HasValue ? endOfDirectiveToken.GetValueOrDefault()! : node.EndOfDirectiveToken,
			isActive.HasValue ? isActive.GetValueOrDefault()! : node.IsActive );
}