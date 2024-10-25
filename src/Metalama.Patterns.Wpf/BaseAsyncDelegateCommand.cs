// Copyright (c) SharpCrafters s.r.o. See the LICENSE.md file in the root directory of this repository root for details.

using System.Collections.Concurrent;
using System.ComponentModel;
using System.Windows.Input;

namespace Metalama.Patterns.Wpf;

/// <summary>
/// A base class for delegate-based async commands.
/// </summary>
public abstract class BaseAsyncDelegateCommand : BaseDelegateCommand, IAsyncCommand
{
    private static volatile int _nextExecutionId;

    private readonly bool _supportsCancellation;
    private readonly bool _supportsConcurrentExecution;
    private static readonly string[] _allProperties = [nameof(ExecutionTask), nameof(IsRunning), nameof(IsCancellationRequested), nameof(CanCancel)];
    private static readonly string[] _cancellationProperties = [nameof(CanCancel), nameof(IsCancellationRequested)];
    private ConcurrentDictionary<int, CancellationTokenSource>? _cancellationTokenSources;

    private protected BaseAsyncDelegateCommand(
        INotifyPropertyChanged canExecutePropertyChangeNotifier,
        string canExecutePropertyName,
        bool supportsCancellation,
        bool supportsConcurrentExecution ) : base( canExecutePropertyChangeNotifier, canExecutePropertyName )
    {
        this._supportsCancellation = supportsCancellation;
        this._supportsConcurrentExecution = supportsConcurrentExecution;
    }

    private protected BaseAsyncDelegateCommand( bool supportsCancellation, bool supportsConcurrentExecution )
    {
        this._supportsCancellation = supportsCancellation;
        this._supportsConcurrentExecution = supportsConcurrentExecution;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Gets a value indicating whether the current command can be cancelled. Returns <c>true</c> if the command
    /// supports cancellation (e.g. has a parameter of type <see cref="CancellationToken"/>) and is currently running.
    /// </summary>
    public bool CanCancel => this._supportsCancellation && this.IsRunning;

    /// <summary>
    /// Gets a value indicating whether the <see cref="Cancel"/> method was called and the current command
    /// execution is still running.
    /// </summary>
    public bool IsCancellationRequested
        => this._cancellationTokenSources != null && this._cancellationTokenSources.Values.Any( t => t.IsCancellationRequested );

    /// <summary>
    /// Gets a value indicating whether any command is executing.
    /// </summary>
    public bool IsRunning => this._cancellationTokenSources is { IsEmpty: false };

    /// <summary>
    /// Gets the <see cref="Task"/> representing the last execution of the command.
    /// </summary>
    public Task? ExecutionTask { get; private set; }

    void ICommand.Execute( object? parameter ) => this.OuterExecute( parameter );

    bool ICommand.CanExecute( object? parameter ) => this.OuterCanExecute( parameter );

    private protected bool OuterCanExecute( object? parameter )
    {
        if ( this.IsRunning && !this._supportsConcurrentExecution )
        {
            return false;
        }
        else
        {
            return this.InnerCanExecute( parameter );
        }
    }

    private protected abstract bool InnerCanExecute( object? parameter );

    private protected sealed override bool CanExecuteCore( object? parameter ) => this.OuterCanExecute( parameter );

    private protected sealed override void ExecuteCore( object? parameter ) => this.OuterExecute( parameter );

    private protected abstract Task InnerExecuteAsync( object? parameter, CancellationToken cancellationToken );

    private protected void OuterExecute( object? parameter )
    {
        if ( !this.OuterCanExecute( parameter ) )
        {
            throw new InvalidOperationException( "The command cannot be executed." );
        }

        this.ExecutionTask = this.ExecuteAsync( parameter );

        this.OnPropertiesChanged( _allProperties );
    }

    private async Task ExecuteAsync( object? parameter )
    {
        var taskId = Interlocked.Increment( ref _nextExecutionId );

        CancellationTokenSource? cancellationTokenSource;

        if ( this._supportsCancellation )
        {
            // Store the CancellationTokenSource into a local variable because another task may
            cancellationTokenSource = new CancellationTokenSource();

            LazyInitializer.EnsureInitialized( ref this._cancellationTokenSources )!.TryAdd( taskId, cancellationTokenSource );
        }
        else
        {
            cancellationTokenSource = null;
        }

        try
        {
            await this.InnerExecuteAsync( parameter, cancellationTokenSource?.Token ?? CancellationToken.None );
        }
        finally
        {
            cancellationTokenSource?.Dispose();

            this._cancellationTokenSources!.TryRemove( taskId, out _ );

            this.OnPropertiesChanged( _allProperties );
        }
    }

    /// <summary>
    /// Cancels all currently pending executions.
    /// </summary>
    public void Cancel()
    {
        // We don't throw any exception in case there is nothing to cancel to avoid races with the CanCancel property.
        if ( this._cancellationTokenSources is { Count: > 0 } )
        {
            foreach ( var task in this._cancellationTokenSources!.Values )
            {
                task.Cancel();
            }

            this.OnPropertiesChanged( _cancellationProperties );
        }
    }

    private void OnPropertiesChanged( string[] properties )
    {
        var propertyChangedEventHandler = this.PropertyChanged;

        if ( propertyChangedEventHandler != null )
        {
            this.SendNotification(
                () =>
                {
                    foreach ( var property in properties )
                    {
                        propertyChangedEventHandler( this, new PropertyChangedEventArgs( property ) );
                    }
                } );
        }
    }
}