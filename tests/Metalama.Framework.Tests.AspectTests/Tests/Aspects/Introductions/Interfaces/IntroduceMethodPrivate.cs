using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using System;

namespace Metalama.Framework.Tests.AspectTests.Tests.Aspects.Introductions.Interfaces.IntroduceMethodPrivate;

public class IntroductionAttribute : TypeAspect
{
    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        var iface = builder.Advice.IntroduceInterface(builder.Target, "ITest");
        var ifacePrivateMethod = builder.Advice.IntroduceMethod(iface.Declaration, nameof(TestMethod));
        builder.Advice.IntroduceMethod(iface.Declaration, nameof(TestUsageMethod), args: new { privateMethod = ifacePrivateMethod.Declaration } );

    }

    [Template]
    private void TestMethod()
    {
        Console.WriteLine("Default");
    }

    [Template]
    public virtual void TestUsageMethod( [CompileTime] IMethod privateMethod)
    {
        privateMethod.Invoke();
    }
}

// <target>
[IntroductionAttribute]
public class TargetType { }