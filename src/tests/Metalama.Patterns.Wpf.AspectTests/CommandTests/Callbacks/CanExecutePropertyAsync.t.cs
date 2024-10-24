using Metalama.Patterns.Wpf.Implementation;
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
    InstanceCommand = new AsyncDelegateCommand((_, _) =>
    {
      return ExecuteInstanceAsync();
    }, _ => CanExecuteInstance, false, false);
    StaticCommand = new AsyncDelegateCommand((_, _) =>
    {
      return ExecuteStaticAsync();
    }, _ => CanExecuteStatic, false, false);
  }
  public IAsyncCommand InstanceCommand { get; }
  public IAsyncCommand StaticCommand { get; }
}