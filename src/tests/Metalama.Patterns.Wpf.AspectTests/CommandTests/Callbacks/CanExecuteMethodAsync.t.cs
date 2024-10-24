using Metalama.Patterns.Wpf.Implementation;
namespace Metalama.Patterns.Wpf.AspectTests.CommandTests.Callbacks;
public class CanExecuteMethodAsync
{
  [Command]
  private Task ExecuteInstanceNoParametersAsync() => Task.CompletedTask;
  private bool CanExecuteInstanceNoParameters() => true;
  [Command]
  private static Task ExecuteStaticNoParametersAsync() => Task.CompletedTask;
  private static bool CanExecuteStaticNoParameters() => true;
  [Command]
  private Task ExecuteInstanceWithParameterAsync(int v) => Task.CompletedTask;
  private bool CanExecuteInstanceWithParameter(int v) => true;
  [Command]
  private static Task ExecuteStaticWithParameterAsync(int v) => Task.CompletedTask;
  private static bool CanExecuteStaticWithParameter(int v) => true;
  public CanExecuteMethodAsync()
  {
    InstanceNoParametersCommand = new AsyncDelegateCommand((_, _) =>
    {
      return ExecuteInstanceNoParametersAsync();
    }, _ => CanExecuteInstanceNoParameters(), false, false);
    StaticNoParametersCommand = new AsyncDelegateCommand((_, _) =>
    {
      return ExecuteStaticNoParametersAsync();
    }, _ => CanExecuteStaticNoParameters(), false, false);
    InstanceWithParameterCommand = new AsyncDelegateCommand((arg, _) =>
    {
      return ExecuteInstanceWithParameterAsync((int)arg);
    }, parameter => CanExecuteInstanceWithParameter((int)parameter), false, false);
    StaticWithParameterCommand = new AsyncDelegateCommand((arg_1, _) =>
    {
      return ExecuteStaticWithParameterAsync((int)arg_1);
    }, parameter_1 => CanExecuteStaticWithParameter((int)parameter_1), false, false);
  }
  public IAsyncCommand InstanceNoParametersCommand { get; }
  public IAsyncCommand InstanceWithParameterCommand { get; }
  public IAsyncCommand StaticNoParametersCommand { get; }
  public IAsyncCommand StaticWithParameterCommand { get; }
}