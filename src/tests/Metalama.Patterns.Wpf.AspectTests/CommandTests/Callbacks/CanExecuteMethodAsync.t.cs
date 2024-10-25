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
    InstanceNoParametersCommand = new AsyncDelegateCommand(_ =>
    {
      return ExecuteInstanceNoParametersAsync();
    }, () => CanExecuteInstanceNoParameters(), false, false);
    StaticNoParametersCommand = new AsyncDelegateCommand(_ =>
    {
      return ExecuteStaticNoParametersAsync();
    }, () => CanExecuteStaticNoParameters(), false, false);
    InstanceWithParameterCommand = new AsyncDelegateCommand<int>((arg, _) =>
    {
      return ExecuteInstanceWithParameterAsync(arg);
    }, parameter => CanExecuteInstanceWithParameter(parameter), false, false);
    StaticWithParameterCommand = new AsyncDelegateCommand<int>((arg_1, _) =>
    {
      return ExecuteStaticWithParameterAsync(arg_1);
    }, parameter_1 => CanExecuteStaticWithParameter(parameter_1), false, false);
  }
  public AsyncDelegateCommand InstanceNoParametersCommand { get; }
  public AsyncDelegateCommand<int> InstanceWithParameterCommand { get; }
  public AsyncDelegateCommand StaticNoParametersCommand { get; }
  public AsyncDelegateCommand<int> StaticWithParameterCommand { get; }
}