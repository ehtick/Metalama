// Warning CS0626 on `TestEvent`: `Method, operator, or accessor 'IntroductionAttribute.TestEvent.remove' is marked external and has no attributes on it. Consider adding a DllImport attribute to specify the external implementation.`
// Warning CS0626 on `TestEvent`: `Method, operator, or accessor 'IntroductionAttribute.TestEvent.remove' is marked external and has no attributes on it. Consider adding a DllImport attribute to specify the external implementation.`
[IntroductionAttribute]
public class TargetType
{
  interface ITest
  {
    static abstract event global::System.EventHandler TestEvent;
  }
  class TestImplementation : global::Metalama.Framework.Tests.AspectTests.Tests.Aspects.Introductions.Interfaces.IntroduceEventStaticAbstract.TargetType.ITest
  {
    public static event global::System.EventHandler TestEvent
    {
      add
      {
        global::System.Console.WriteLine("Implementation");
      }
      remove
      {
        global::System.Console.WriteLine("Implementation");
      }
    }
  }
  class TestUsage<T>
    where T : global::Metalama.Framework.Tests.AspectTests.Tests.Aspects.Introductions.Interfaces.IntroduceEventStaticAbstract.TargetType.ITest
  {
    public static void TestUsageMethod()
    {
      T.TestEvent += (global::System.EventHandler)((s, ea) => global::System.Console.WriteLine("Handler"));
      global::Metalama.Framework.Tests.AspectTests.Tests.Aspects.Introductions.Interfaces.IntroduceEventStaticAbstract.TargetType.TestImplementation.TestEvent += (global::System.EventHandler)((s_1, ea_1) => global::System.Console.WriteLine("Handler"));
    }
  }
}