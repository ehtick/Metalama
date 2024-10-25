namespace Metalama.Patterns.Wpf.AspectTests.CommandTests.Callbacks;
public class ExecuteMethodAsync
{
  [Command]
  private Task ExecuteInstanceNoParametersAsync() => Task.CompletedTask;
  [Command]
  private static Task ExecuteStaticNoParametersAsync() => Task.CompletedTask;
  [Command]
  private Task ExecuteInstanceWithParameterAsync(int v) => Task.CompletedTask;
  [Command]
  private static Task ExecuteStaticWithParameterAsync(int v) => Task.CompletedTask;
  [Command]
  private Task ExecuteInstanceWithCancellationTokenAsync(CancellationToken cancellationToken) => Task.CompletedTask;
  [Command]
  private static Task ExecuteStaticWithCancellationTokenAsync(CancellationToken cancellationToken) => Task.CompletedTask;
  [Command]
  private Task ExecuteInstanceWithCancellationTokenAndParameterAsync(int v, CancellationToken cancellationToken) => Task.CompletedTask;
  [Command]
  private static Task ExecuteStaticWithCancellationTokenAndParameterAsync(int v, CancellationToken cancellationToken) => Task.CompletedTask;
  public ExecuteMethodAsync()
  {
    InstanceNoParametersCommand = new AsyncDelegateCommand(_ =>
    {
      return ExecuteInstanceNoParametersAsync();
    }, null, false, false);
    StaticNoParametersCommand = new AsyncDelegateCommand(_ =>
    {
      return ExecuteStaticNoParametersAsync();
    }, null, false, false);
    InstanceWithParameterCommand = new AsyncDelegateCommand<int>((arg, _) =>
    {
      return ExecuteInstanceWithParameterAsync(arg);
    }, null, false, false);
    StaticWithParameterCommand = new AsyncDelegateCommand<int>((arg_1, _) =>
    {
      return ExecuteStaticWithParameterAsync(arg_1);
    }, null, false, false);
    InstanceWithCancellationTokenCommand = new AsyncDelegateCommand(ct =>
    {
      return ExecuteInstanceWithCancellationTokenAsync(ct);
    }, null, true, false);
    StaticWithCancellationTokenCommand = new AsyncDelegateCommand(ct_1 =>
    {
      return ExecuteStaticWithCancellationTokenAsync(ct_1);
    }, null, true, false);
    InstanceWithCancellationTokenAndParameterCommand = new AsyncDelegateCommand<int>((arg_2, ct_2) =>
    {
      return ExecuteInstanceWithCancellationTokenAndParameterAsync(arg_2, ct_2);
    }, null, true, false);
    StaticWithCancellationTokenAndParameterCommand = new AsyncDelegateCommand<int>((arg_3, ct_3) =>
    {
      return ExecuteStaticWithCancellationTokenAndParameterAsync(arg_3, ct_3);
    }, null, true, false);
  }
  public AsyncDelegateCommand InstanceNoParametersCommand { get; }
  public AsyncDelegateCommand<int> InstanceWithCancellationTokenAndParameterCommand { get; }
  public AsyncDelegateCommand InstanceWithCancellationTokenCommand { get; }
  public AsyncDelegateCommand<int> InstanceWithParameterCommand { get; }
  public AsyncDelegateCommand StaticNoParametersCommand { get; }
  public AsyncDelegateCommand<int> StaticWithCancellationTokenAndParameterCommand { get; }
  public AsyncDelegateCommand StaticWithCancellationTokenCommand { get; }
  public AsyncDelegateCommand<int> StaticWithParameterCommand { get; }
}