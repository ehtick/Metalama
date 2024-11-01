using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using System;
using System.Linq;

namespace Metalama.Framework.Tests.AspectTests.Tests.Aspects.Introductions.Interfaces.IntroduceMethodAbstract;

public class IntroductionAttribute : TypeAspect
{
    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        var iface = builder.Advice.IntroduceInterface(builder.Target, "ITest");
        var ifaceMethod = builder.Advice.IntroduceMethod(iface.Declaration, nameof(TestMethod) );

        // Implementation type
        var impl = builder.Advice.IntroduceClass(builder.Target, "TestImpl");
        builder.Advice.ImplementInterface(impl.Declaration, iface.Declaration);
        var constructor = builder.Advice.IntroduceConstructor(impl.Declaration, nameof(Constructor));
        builder.Advice.IntroduceMethod(impl.Declaration, nameof(TestMethodImpl), buildMethod: b => { b.Name = "TestMethod"; });

        var usage = builder.Advice.IntroduceClass(builder.Target, "TestUsage");
        builder.Advice.IntroduceMethod(usage.Declaration, nameof(TestUsageMethod), args: new { T = iface.Declaration, method = ifaceMethod.Declaration, implConstructor = constructor.Declaration });
    }

    [Template]
    public void Constructor()
    {
    }

    [Template]
    public extern void TestMethod();

    [Template]
    public void TestMethodImpl() 
    { 
        Console.WriteLine("Implementation");
    }

    [Template]
    public T TestUsageMethod<[CompileTime] T>(T instance, [CompileTime] IMethod method, [CompileTime] IConstructor implConstructor)
    {
        method.With(instance).Invoke();
        return implConstructor.Invoke();
    }
}

// <target>
[IntroductionAttribute]
public class TargetType { }