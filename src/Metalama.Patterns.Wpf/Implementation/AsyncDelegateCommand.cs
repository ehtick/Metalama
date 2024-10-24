// Copyright (c) SharpCrafters s.r.o. See the LICENSE.md file in the root directory of this repository root for details.

using JetBrains.Annotations;
using System.ComponentModel;

namespace Metalama.Patterns.Wpf.Implementation;

/// <summary>
/// An implementation of <see cref="IAsyncCommand"/> which uses delegates to access callbacks. This class supports
/// the <see cref="CommandAttribute"/> aspect infrastructure and should not be used directly.
/// </summary>
[PublicAPI]
public sealed class AsyncDelegateCommand : IAsyncCommand
{
    /* Original comment from PostSharp:
     * Two options how to support this:
     *   - have INPC detect dependencies in the CanExecuteChanged method
     *   - use a property instead of method and route the notification (NPC -> CanExecuteChanged)
     *     limitation: parameters would not be easily supported
     * Currently: only property in [NPC] classes is supported.
     *
     * In this (Metalama) implementation:
     *
     * Currently INPC integration is strictly via INotifyPropertyChanged, where CanExecute must be a public property.
     * The only requirement for integration with [NPC] is aspect ordering so that [NPC] aspect is applied before [Command], so [Command]
     * sees that INotifyPropertyChanged is implemented.
     */

    private static readonly SendOrPostCallback _onCanExecuteChangedDelegate = OnCanExecuteChanged;
    private static readonly string[] _allProperties = [nameof(ExecutionTask), nameof(IsRunning), nameof(IsCancellationRequested), nameof(CanBeCanceled)];
    private static readonly string[] _cancellationProperties = [nameof(CanBeCanceled), nameof(IsCancellationRequested)];

    private readonly SynchronizationContext? _synchronizationContext;
    private readonly Func<object?, bool>? _canExecute;
    private readonly bool _supportsCancellation;
    private readonly Func<object?, CancellationToken, Task> _execute;
    private readonly string? _canExecutePropertyName;
    private readonly bool _supportsConcurrentExecution;
    private CancellationTokenSource? _cancellationTokenSource;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncDelegateCommand"/> class, without <see cref="INotifyPropertyChanged"/> integration.
    /// </summary>
    public AsyncDelegateCommand(
        Func<object?, CancellationToken, Task> execute,
        Func<object?, bool>? canExecute,
        bool supportsCancellation,
        bool supportsConcurrentExecution )
    {
        this._synchronizationContext = SynchronizationContext.Current;
        this._execute = execute;
        this._canExecute = canExecute;
        this._supportsCancellation = supportsCancellation;
        this._supportsConcurrentExecution = supportsConcurrentExecution;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncDelegateCommand"/> class, with <see cref="INotifyPropertyChanged"/> integration.
    /// </summary>
    public AsyncDelegateCommand(
        Func<object?, CancellationToken, Task> execute,
        Func<object?, bool> canExecute,
        INotifyPropertyChanged canExecutePropertyChangeNotifier,
        string canExecutePropertyName,
        bool supportsCancellation,
        bool supportsConcurrentExecution )
    {
        this._synchronizationContext = SynchronizationContext.Current;
        this._execute = execute;
        this._canExecute = canExecute;
        this._canExecutePropertyName = canExecutePropertyName;
        this._supportsConcurrentExecution = supportsConcurrentExecution;
        canExecutePropertyChangeNotifier.PropertyChanged += this.OnUpstreamPropertyChanged;
    }

    public event EventHandler? CanExecuteChanged;

    public event PropertyChangedEventHandler? PropertyChanged;

    public bool CanBeCanceled => this._supportsCancellation && this.IsRunning;

    public bool IsCancellationRequested => this._cancellationTokenSource?.IsCancellationRequested == true;

    public bool IsRunning => this.ExecutionTask is { IsCanceled: false, IsCompleted: false, IsFaulted: false };

    public Task? ExecutionTask { get; private set; }

    public void Execute( object? parameter )
    {
        if ( !this.CanExecute( parameter ) )
        {
            throw new InvalidOperationException( "The command cannot be executed." );
        }

        this.ExecutionTask = this.ExecuteAsync( parameter );

        this.OnPropertiesChanged( _allProperties );
    }

    private async Task ExecuteAsync( object? parameter )
    {
        CancellationToken cancellationToken;

        if ( this._supportsCancellation )
        {
            this._cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = this._cancellationTokenSource.Token;
        }
        else
        {
            cancellationToken = default;
        }

        try
        {
            await this._execute( parameter, cancellationToken );
        }
        finally
        {
            this._cancellationTokenSource?.Dispose();
            this._cancellationTokenSource = null;

            this.OnPropertiesChanged( _allProperties );
        }
    }

    public bool CanExecute( object? parameter )
    {
        if ( this.IsRunning && !this._supportsConcurrentExecution )
        {
            return false;
        }
        else
        {
            return this._canExecute == null || this._canExecute( parameter );
        }
    }

    private void OnUpstreamPropertyChanged( object? sender, PropertyChangedEventArgs args )
    {
        if ( this.CanExecuteChanged != null )
        {
            if ( args.PropertyName == this._canExecutePropertyName )
            {
                if ( this._synchronizationContext != null )
                {
                    this._synchronizationContext.Send( _onCanExecuteChangedDelegate, this );
                }
                else
                {
                    OnCanExecuteChanged( this );
                }
            }
        }
    }

    private static void OnCanExecuteChanged( object? obj ) => (obj as AsyncDelegateCommand)?.CanExecuteChanged?.Invoke( obj, EventArgs.Empty );

    public void Cancel()
    {
        var source = this._cancellationTokenSource;

        if ( source != null )
        {
            source.Cancel();
            this.OnPropertiesChanged( _cancellationProperties );
        }
        else
        {
            throw new InvalidOperationException( "This command cannot be cancelled." );
        }
    }

    private void OnPropertiesChanged( string[] properties )
    {
        var propertyChangedEventHandler = this.PropertyChanged;

        if ( propertyChangedEventHandler != null )
        {
            if ( this._synchronizationContext != null )
            {
                // Raise in the original context.
                this._synchronizationContext.Send(
                    _ =>
                    {
                        foreach ( var property in properties )
                        {
                            propertyChangedEventHandler( this, new PropertyChangedEventArgs( property ) );
                        }
                    },
                    null );
            }
            else
            {
                foreach ( var property in properties )
                {
                    propertyChangedEventHandler( this, new PropertyChangedEventArgs( property ) );
                }
            }
        }
    }
}