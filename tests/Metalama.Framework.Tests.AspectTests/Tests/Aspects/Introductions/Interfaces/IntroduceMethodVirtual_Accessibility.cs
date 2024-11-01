using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using System;

namespace Metalama.Framework.Tests.AspectTests.Tests.Aspects.Introductions.Interfaces.IntroduceMethodVirtual_Accessibility;

public class IntroductionAttribute : TypeAspect
{
    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        var iface = builder.Advice.IntroduceInterface(builder.Target, "ITest");
        builder.Advice.IntroduceMethod(iface.Declaration, nameof(TestPublic));
        builder.Advice.IntroduceMethod(iface.Declaration, nameof(TestInternal));
        builder.Advice.IntroduceMethod(iface.Declaration, nameof(TestProtected));
        builder.Advice.IntroduceMethod(iface.Declaration, nameof(TestProtectedInternal));
        builder.Advice.IntroduceMethod(iface.Declaration, nameof(TestPrivateProtected));
    }

    [Template]
    public virtual void TestPublic()
    {
        Console.WriteLine("Implementation");
    }

    [Template]
    internal virtual void TestInternal()
    {
        Console.WriteLine("Implementation");
    }

    [Template]
    protected virtual void TestProtected()
    {
        Console.WriteLine("Implementation");
    }

    [Template]
    protected internal virtual void TestProtectedInternal()
    {
        Console.WriteLine("Implementation");
    }

    [Template]
    private protected virtual void TestPrivateProtected()
    {
        Console.WriteLine("Implementation");
    }
}

// <target>
[IntroductionAttribute]
public class TargetType { }