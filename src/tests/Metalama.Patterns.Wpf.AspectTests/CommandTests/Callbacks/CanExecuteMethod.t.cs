namespace Metalama.Patterns.Wpf.AspectTests.CommandTests.Callbacks;
public class CanExecuteMethod
{
  [Command]
  private void ExecuteInstanceNoParameters()
  {
  }
  private bool CanExecuteInstanceNoParameters() => true;
  [Command]
  private static void ExecuteStaticNoParameters()
  {
  }
  private static bool CanExecuteStaticNoParameters() => true;
  [Command]
  private void ExecuteInstanceWithParameter(int v)
  {
  }
  private bool CanExecuteInstanceWithParameter(int v) => true;
  [Command]
  private static void ExecuteStaticWithParameter(int v)
  {
  }
  private static bool CanExecuteStaticWithParameter(int v) => true;
  public CanExecuteMethod()
  {
    InstanceNoParametersCommand = new DelegateCommand(() => ExecuteInstanceNoParameters(), () => CanExecuteInstanceNoParameters());
    StaticNoParametersCommand = new DelegateCommand(() => ExecuteStaticNoParameters(), () => CanExecuteStaticNoParameters());
    InstanceWithParameterCommand = new DelegateCommand<int>(parameter_1 => ExecuteInstanceWithParameter(parameter_1), parameter => CanExecuteInstanceWithParameter(parameter));
    StaticWithParameterCommand = new DelegateCommand<int>(parameter_3 => ExecuteStaticWithParameter(parameter_3), parameter_2 => CanExecuteStaticWithParameter(parameter_2));
  }
  public DelegateCommand InstanceNoParametersCommand { get; }
  public DelegateCommand<int> InstanceWithParameterCommand { get; }
  public DelegateCommand StaticNoParametersCommand { get; }
  public DelegateCommand<int> StaticWithParameterCommand { get; }
}