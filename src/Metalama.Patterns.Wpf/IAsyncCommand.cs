// Copyright (c) SharpCrafters s.r.o. See the LICENSE.md file in the root directory of this repository root for details.

using System.ComponentModel;
using System.Windows.Input;

namespace Metalama.Patterns.Wpf;

public interface IAsyncCommand : ICommand, INotifyPropertyChanged
{
    void Cancel();
    bool CanBeCanceled { get; }
    bool IsCancellationRequested { get; }
    bool IsRunning { get; }
    Task? ExecutionTask { get; }
}