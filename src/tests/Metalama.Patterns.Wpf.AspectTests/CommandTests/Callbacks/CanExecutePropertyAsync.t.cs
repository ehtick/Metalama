namespace Metalama.Patterns.Wpf.AspectTests.CommandTests.Callbacks;
public class CanExecutePropertysync
{
  [Command]
  private Task ExecuteInstanceAsync() => Task.CompletedTask;
  private bool CanExecuteInstance => true;
  [Command]
  private static Task ExecuteStaticAsync() => Task.CompletedTask;
  private static bool CanExecuteStatic => true;
  public CanExecutePropertysync()
  {
    InstanceCommand = new AsyncDelegateCommand(_ =>
    {
      return ExecuteInstanceAsync();
    }, () => CanExecuteInstance, false, false);
    StaticCommand = new AsyncDelegateCommand(_ =>
    {
      return ExecuteStaticAsync();
    }, () => CanExecuteStatic, false, false);
  }
  public AsyncDelegateCommand InstanceCommand { get; }
  public AsyncDelegateCommand StaticCommand { get; }
}