using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using System;

namespace Metalama.Framework.Tests.AspectTests.Tests.Aspects.Introductions.Interfaces.IntroduceMethodAbstract_Accessibility;

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
    public extern void TestPublic();

    [Template]
    internal extern void TestInternal();

    [Template]
    protected extern void TestProtected();

    [Template]
    protected internal extern void TestProtectedInternal();

    [Template]
    private protected extern void TestPrivateProtected();
}

// <target>
[IntroductionAttribute]
public class TargetType { }