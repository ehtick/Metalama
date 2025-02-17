internal sealed class SomeImplementation : IInterfaceB
{
  [return: global::Metalama.Framework.Tests.PublicPipeline.Aspects.Inheritance.InterfaceMember_ReturnValue.MyAttribute]
  public int M(int arg) => arg;
}