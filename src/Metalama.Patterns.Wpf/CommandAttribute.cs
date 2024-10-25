// Copyright (c) SharpCrafters s.r.o. See the LICENSE.md file in the root directory of this repository root for details.

using JetBrains.Annotations;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Code.SyntaxBuilders;
using Metalama.Framework.Eligibility;
using Metalama.Framework.Project;
using Metalama.Patterns.Wpf.Configuration;
using Metalama.Patterns.Wpf.Implementation;
using Metalama.Patterns.Wpf.Implementation.CommandNamingConvention;
using Metalama.Patterns.Wpf.Implementation.NamingConvention;
using System.ComponentModel;
using System.Windows.Input;
using MetalamaAccessibility = Metalama.Framework.Code.Accessibility;

// TODO: Skip [Observable] on [Command]-targeted auto properties. No functional impact, would just avoid unnecessary generated code.

namespace Metalama.Patterns.Wpf;

[PublicAPI]
[AttributeUsage( AttributeTargets.Method )]
public sealed partial class CommandAttribute : Attribute, IAspect<IMethod>
{
    internal const string CommandPropertyCategory = "command property";
    internal const string CanExecuteMethodCategory = "can-execute method";
    internal const string CanExecutePropertyCategory = "can-execute property";

    /// <summary>
    /// Gets or sets the name of the <see cref="ICommand"/> property that is introduced.
    /// </summary>
    public string? CommandPropertyName { get; set; }

    /// <summary>
    /// Gets or sets the name of the method that is called to determine whether the command can be executed.
    /// This method corresponds to the <see cref="ICommand.CanExecute"/> method.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <c>CanExecute</c> method must be declared in the same class as the command property, return a <c>bool</c> value and can have zero or one parameter.
    /// </para>
    /// <para>
    /// If this property is not set, then the aspect will look for a method named <c>CanFoo</c> or <c>CanExecuteFoo</c>, where <c>Foo</c> is the name of the command without the <c>Command</c> suffix.
    /// </para>
    /// <para>
    /// At most one of the <see cref="CanExecuteMethod"/> and <see cref="CanExecuteProperty"/> properties may be set.
    /// </para>
    /// </remarks>
    public string? CanExecuteMethod { get; set; }

    /// <summary>
    /// Gets or sets the name of the property that is evaluated to determine whether the command can be executed.
    /// This property corresponds to the <see cref="ICommand.CanExecute"/> method.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <c>CanExecute</c> property must be declared in the same class as the command property and return a <c>bool</c> value.
    /// </para>
    /// <para>
    /// If this property is not set, then the aspect will look for a property named <c>CanFoo</c> or <c>CanExecuteFoo</c>, where <c>Foo</c> is the name of the command without the <c>Command</c> suffix.
    /// </para>
    /// <para>
    /// At most one of the <see cref="CanExecuteMethod"/> and <see cref="CanExecuteProperty"/> properties may be set.
    /// </para>
    /// </remarks>
    public string? CanExecuteProperty { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether integration with <see cref="INotifyPropertyChanged"/> is enabled. The default is <see langword="true"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// When <see cref="EnableINotifyPropertyChangedIntegration"/> is <see langword="true"/> (the default), and when a can-execute property (not a method) is used,
    /// and when the containing type of the target property implements <see cref="INotifyPropertyChanged"/>,then the <see cref="ICommand.CanExecuteChanged"/> event of 
    /// the command will be raised when the can-execute property changes. A warning is reported if the can-execute property is not public because <see cref="INotifyPropertyChanged"/>
    /// implementations typically only notify changes to public properties.
    /// </para>
    /// </remarks>
    public bool? EnableINotifyPropertyChangedIntegration { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether several executions of the command can run concurrently. This property is only considered for asynchronous methods.
    /// Its default value is <c>false</c>, which means that the <see cref="ICommand.CanExecute"/> method will return <c>false</c> if another execution is still running.
    /// </summary>
    public bool SupportsConcurrentExecution { get; set; }

    void IEligible<IMethod>.BuildEligibility( IEligibilityBuilder<IMethod> builder )
    {
        builder.MustNotHaveRefOrOutParameter();
        builder.MustSatisfy( m => m.TypeParameters.Count == 0, m => $"{m} must not be generic" );

        builder.ReturnType().MustSatisfyAny( b => b.MustEqual( SpecialType.Void ), b => b.MustEqual( SpecialType.Task ) );

        // Rules for void (non-async) methods.
        builder.If( b => b.ReturnType.SpecialType == SpecialType.Void )
            .MustSatisfy( m => m.Parameters.Count is 0 or 1, m => $"{m} must have zero or one parameter" );

        // Rules for async methods.
        builder.If( b => b.ReturnType.SpecialType == SpecialType.Task )
            .MustSatisfyAll(
                b => b.MustSatisfy( m => m.Parameters.Count <= 2, m => $"{m} must have 2 or fewer parameters" ),
                b => b.If( m => m.Parameters.Count == 2 )
                    .MustSatisfy(
                        m => m.Parameters[^1].Type.Equals( typeof(CancellationToken) ),
                        m => $"if {m} has two parameters, the last one must be a CancellationToken" ) );
    }

    void IAspect<IMethod>.BuildAspect( IAspectBuilder<IMethod> builder )
    {
        var target = builder.Target;
        var declaringType = target.DeclaringType;
        var options = target.Enhancements().GetOptions<CommandOptions>();

        if ( this is { CanExecuteMethod: not null, CanExecuteProperty: not null } )
        {
            builder.Diagnostics.Report( Diagnostics.CannotSpecifyBothCanExecuteMethodAndCanExecuteProperty );

            // Further diagnostics would be confusing and transformation is not possible.

            return;
        }

        var hasExplicitCanExecuteNaming = this.CanExecuteMethod != null || this.CanExecuteProperty != null;

        // Find the CanExecute method or property.
        var namingConventions = hasExplicitCanExecuteNaming
            ? [new ExplicitCommandNamingConvention( this.CommandPropertyName, this.CanExecuteMethod, this.CanExecuteProperty )]
            : options.GetSortedNamingConventions();

        var diagnosticReporter = new DiagnosticReporter( builder );

        if ( !NamingConventionEvaluator.TryEvaluate( namingConventions, target, diagnosticReporter, out var match ) )
        {
            builder.SkipAspect();

            return;
        }

        IProperty? commandProperty;
        IMethod? canExecuteMethod = null;
        IProperty? canExecuteProperty = null;

        switch ( match.CanExecuteMatch.Member )
        {
            case null:
                break;

            case IProperty property:
                canExecuteProperty = property;

                break;

            case IMethod method:
                canExecuteMethod = method;

                break;

            default:
                throw new NotSupportedException( "Expected a method or property." );
        }

        // Determines the type of command we need to plug.
        var isAsyncCommand = target.ReturnType.SpecialType == SpecialType.Task;

        var parameterType = builder.Target.Parameters.Count > 0 && !builder.Target.Parameters[0].Type.Equals( typeof(CancellationToken) )
            ? builder.Target.Parameters[0].Type
            : null;

        var (propertyTemplate, commandType) = (isAsyncCommand, parameterType) switch
        {
            (false, null) => (nameof(CommandProperty), TypeFactory.GetType( typeof(DelegateCommand) )),
            (false, not null) => (nameof(CommandProperty),
                                  ((INamedType) TypeFactory.GetType( typeof(DelegateCommand<>) )).MakeGenericInstance( parameterType )),
            (true, null) => (nameof(AsyncCommandProperty), TypeFactory.GetType( typeof(AsyncDelegateCommand) )),
            (true, not null) => (nameof(AsyncCommandProperty),
                                 ((INamedType) TypeFactory.GetType( typeof(AsyncDelegateCommand<>) )).MakeGenericInstance( parameterType ))
        };

        // Introduce the Command property.
        var introducePropertyResult = builder.Advice.IntroduceProperty(
            declaringType,
            propertyTemplate,
            IntroductionScope.Instance,
            OverrideStrategy.Fail,
            b =>
            {
                b.Type = commandType;
                b.Name = match.CommandPropertyName!;

                // ReSharper disable once RedundantNameQualifier
                b.Accessibility = MetalamaAccessibility.Public;

                // ReSharper disable once RedundantNameQualifier
                b.GetMethod!.Accessibility = MetalamaAccessibility.Public;
            } );

        if ( introducePropertyResult.Outcome == AdviceOutcome.Default )
        {
            commandProperty = introducePropertyResult.Declaration;
        }
        else
        {
            builder.SkipAspect();

            return;
        }

        var useInpcIntegration = false;

        if ( canExecuteProperty != null && options.EnableINotifyPropertyChangedIntegration == true )
        {
            if ( declaringType.AllImplementedInterfaces.Contains( typeof(INotifyPropertyChanged) ) )
            {
                // ReSharper disable once RedundantNameQualifier
                if ( canExecuteProperty.Accessibility != MetalamaAccessibility.Public )
                {
                    builder.Diagnostics.Report(
                        Diagnostics.CommandNotifiableCanExecutePropertyIsNotPublic.WithArguments( target ),
                        canExecuteProperty );
                }

                useInpcIntegration = true;
            }
        }

        if ( !MetalamaExecutionContext.Current.ExecutionScenario.CapturesNonObservableTransformations )
        {
            builder.Diagnostics.Suppress( Suppressions.SuppressRemoveUnusedPrivateMembersIDE0051, target );

            if ( canExecuteMethod != null )
            {
                builder.Diagnostics.Suppress( Suppressions.SuppressRemoveUnusedPrivateMembersIDE0051, canExecuteMethod );
            }

            if ( canExecuteProperty != null )
            {
                builder.Diagnostics.Suppress( Suppressions.SuppressRemoveUnusedPrivateMembersIDE0051, canExecuteProperty );
            }

            return;
        }

        builder.Advice.AddInitializer(
            declaringType,
            parameterType != null ? nameof(this.InitializeCommandWithParameter) : nameof(this.InitializeCommandWithoutParameter),
            InitializerKind.BeforeInstanceConstructor,
            args: new
            {
                commandProperty,
                executeMethod = target,
                canExecuteMethod,
                canExecuteProperty,
                useInpcIntegration,
                isAsyncCommand,
                T = parameterType
            } );
    }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [Template]
    private static dynamic CommandProperty { get; }

    [Template]
    private static dynamic AsyncCommandProperty { get; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [Template]
    private void InitializeCommandWithoutParameter(
        [CompileTime] IProperty commandProperty,
        [CompileTime] IMethod executeMethod,
        [CompileTime] IMethod? canExecuteMethod,
        [CompileTime] IProperty? canExecuteProperty,
        [CompileTime] bool useInpcIntegration,
        [CompileTime] bool isAsyncCommand )
    {
        IExpression? canExecuteExpression = null;

        if ( canExecuteMethod != null || canExecuteProperty != null )
        {
            if ( canExecuteMethod != null )
            {
                canExecuteExpression = ExpressionFactory.Capture( new Func<bool>( () => (bool) canExecuteMethod.Invoke()! ) );
            }
            else
            {
                canExecuteExpression = ExpressionFactory.Capture( new Func<bool>( () => (bool) canExecuteProperty!.Value! ) );
            }
        }

#pragma warning disable IDE0053

// ReSharper disable ConvertToLambdaExpression

        IExpression? executeExpression;

        if ( !isAsyncCommand )
        {
            executeExpression = ExpressionFactory.Capture( new Action( () => { executeMethod.Invoke(); } ) );

            if ( useInpcIntegration )
            {
                commandProperty.Value = new DelegateCommand( executeExpression.Value!, canExecuteExpression!.Value!, meta.This, canExecuteProperty!.Name );
            }
            else
            {
                // ReSharper disable once MergeConditionalExpression
#pragma warning disable IDE0031 // Use null propagation
                commandProperty.Value = new DelegateCommand( executeExpression.Value!, canExecuteExpression == null ? null : canExecuteExpression.Value );
#pragma warning restore IDE0031 // Use null propagation
            }
        }
        else
        {
            var supportsCancellation = meta.CompileTime( false );

            switch ( executeMethod.Parameters.Count )
            {
                case 0:
                    executeExpression =
                        ExpressionFactory.Capture( new Func<CancellationToken, Task>( _ => { return executeMethod.Invoke()!; } ) );

                    break;

                case 1 when executeMethod.Parameters[0].Type.Equals( typeof(CancellationToken) ):
                    executeExpression = ExpressionFactory.Capture( new Func<CancellationToken, Task>( ct => { return executeMethod.Invoke( ct )!; } ) );

                    supportsCancellation = true;

                    break;

                default:
                    // This should never happen, but we cannot throw a compile-time exception.
                    executeExpression = null!;

                    break;
            }

            if ( useInpcIntegration )
            {
                commandProperty.Value = new AsyncDelegateCommand(
                    executeExpression.Value!,
                    canExecuteExpression!.Value!,
                    meta.This,
                    canExecuteProperty!.Name,
                    supportsCancellation,
                    this.SupportsConcurrentExecution );
            }
            else
            {
                // ReSharper disable once MergeConditionalExpression
#pragma warning disable IDE0031 // Use null propagation
                commandProperty.Value = new AsyncDelegateCommand(
                    executeExpression.Value!,
                    canExecuteExpression == null ? null : canExecuteExpression.Value,
                    supportsCancellation,
                    this.SupportsConcurrentExecution );
#pragma warning restore IDE0031 // Use null propagation
            }
        }

// ReSharper restore ConvertToLambdaExpression        
#pragma warning restore IDE0053
    }

    [Template]
    private void InitializeCommandWithParameter<[CompileTime] T>(
        [CompileTime] IProperty commandProperty,
        [CompileTime] IMethod executeMethod,
        [CompileTime] IMethod? canExecuteMethod,
        [CompileTime] IProperty? canExecuteProperty,
        [CompileTime] bool useInpcIntegration,
        [CompileTime] bool isAsyncCommand )
    {
        IExpression? canExecuteExpression = null;

        if ( canExecuteMethod != null || canExecuteProperty != null )
        {
            if ( canExecuteMethod != null )
            {
                canExecuteExpression = ExpressionFactory.Capture(
                    new Func<T, bool>( parameter => (bool) canExecuteMethod.Invoke( meta.Cast( canExecuteMethod.Parameters[0].Type, parameter ) ) ) );
            }
            else
            {
                canExecuteExpression = ExpressionFactory.Capture( new Func<T, bool>( _ => (bool) canExecuteProperty!.Value! ) );
            }
        }

#pragma warning disable IDE0053

// ReSharper disable ConvertToLambdaExpression

        IExpression? executeExpression;

        if ( !isAsyncCommand )
        {
            executeExpression = ExpressionFactory.Capture(
                new Action<T>(
                    parameter =>
                    {
                        executeMethod.Invoke( meta.Cast( executeMethod.Parameters[0].Type, parameter ) );
                    } ) );

            if ( useInpcIntegration )
            {
                commandProperty.Value = new DelegateCommand<T>( executeExpression.Value!, canExecuteExpression!.Value!, meta.This, canExecuteProperty!.Name );
            }
            else
            {
                // ReSharper disable once MergeConditionalExpression
#pragma warning disable IDE0031 // Use null propagation
                commandProperty.Value = new DelegateCommand<T>( executeExpression.Value!, canExecuteExpression == null ? null : canExecuteExpression.Value );
#pragma warning restore IDE0031 // Use null propagation
            }
        }
        else
        {
            var supportsCancellation = meta.CompileTime( false );

            switch ( executeMethod.Parameters.Count )
            {
                case 1:
                    executeExpression = ExpressionFactory.Capture(
                        new Func<T, CancellationToken, Task>( ( arg, _ ) => { return executeMethod.Invoke( arg )!; } ) );

                    break;

                case 2:
                    executeExpression = ExpressionFactory.Capture(
                        new Func<T, CancellationToken, Task>( ( arg, ct ) => { return executeMethod.Invoke( arg, ct )!; } ) );

                    supportsCancellation = true;

                    break;

                default:
                    // This should never happen, but we cannot throw a compile-time exception.
                    executeExpression = null!;

                    break;
            }

            if ( useInpcIntegration )
            {
                commandProperty.Value = new AsyncDelegateCommand<T>(
                    executeExpression.Value!,
                    canExecuteExpression!.Value!,
                    meta.This,
                    canExecuteProperty!.Name,
                    supportsCancellation,
                    this.SupportsConcurrentExecution );
            }
            else
            {
                // ReSharper disable once MergeConditionalExpression
#pragma warning disable IDE0031 // Use null propagation
                commandProperty.Value = new AsyncDelegateCommand<T>(
                    executeExpression.Value!,
                    canExecuteExpression == null ? null : canExecuteExpression.Value,
                    supportsCancellation,
                    this.SupportsConcurrentExecution );
#pragma warning restore IDE0031 // Use null propagation
            }
        }

// ReSharper restore ConvertToLambdaExpression        
#pragma warning restore IDE0053
    }
}