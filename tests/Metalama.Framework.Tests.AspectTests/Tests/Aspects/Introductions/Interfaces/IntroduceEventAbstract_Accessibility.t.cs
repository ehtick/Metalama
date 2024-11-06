// Warning CS0626  on `TestPublic`: `Method, operator, or accessor 'IntroductionAttribute.TestPublic.remove' is marked external and has no attributes on it. Consider adding a DllImport attribute to specify the external implementation.`
// Warning CS0626  on `TestInternal`: `Method, operator, or accessor 'IntroductionAttribute.TestInternal.remove' is marked external and has no attributes on it. Consider adding a DllImport attribute to specify the external implementation.`
// Warning CS0626  on `TestProtected`: `Method, operator, or accessor 'IntroductionAttribute.TestProtected.remove' is marked external and has no attributes on it. Consider adding a DllImport attribute to specify the external implementation.`
// Warning CS0626  on `TestProtectedInternal`: `Method, operator, or accessor 'IntroductionAttribute.TestProtectedInternal.remove' is marked external and has no attributes on it. Consider adding a DllImport attribute to specify the external implementation.`
// Warning CS0626  on `TestPrivateProtected`: `Method, operator, or accessor 'IntroductionAttribute.TestPrivateProtected.remove' is marked external and has no attributes on it. Consider adding a DllImport attribute to specify the external implementation.`
[IntroductionAttribute]
public class TargetType
{
  interface ITest
  {
    internal event global::System.EventHandler TestInternal;
    private protected event global::System.EventHandler TestPrivateProtected;
    protected event global::System.EventHandler TestProtected;
    protected internal event global::System.EventHandler TestProtectedInternal;
    event global::System.EventHandler TestPublic;
  }
}
