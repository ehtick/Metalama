namespace Metalama.Patterns.Wpf.AspectTests.CommandTests.Callbacks;
public class ExecuteMethod
{
  [Command]
  private void ExecuteInstanceNoParameters()
  {
  }
  [Command]
  private static void ExecuteStaticNoParameters()
  {
  }
  [Command]
  private void ExecuteInstanceWithParameter(int v)
  {
  }
  [Command]
  private static void ExecuteStaticWithParameter(int v)
  {
  }
  public ExecuteMethod()
  {
    InstanceNoParametersCommand = new DelegateCommand(() => ExecuteInstanceNoParameters(), null);
    StaticNoParametersCommand = new DelegateCommand(() => ExecuteStaticNoParameters(), null);
    InstanceWithParameterCommand = new DelegateCommand<int>(parameter => ExecuteInstanceWithParameter(parameter), null);
    StaticWithParameterCommand = new DelegateCommand<int>(parameter_1 => ExecuteStaticWithParameter(parameter_1), null);
  }
  public DelegateCommand InstanceNoParametersCommand { get; }
  public DelegateCommand<int> InstanceWithParameterCommand { get; }
  public DelegateCommand StaticNoParametersCommand { get; }
  public DelegateCommand<int> StaticWithParameterCommand { get; }
}