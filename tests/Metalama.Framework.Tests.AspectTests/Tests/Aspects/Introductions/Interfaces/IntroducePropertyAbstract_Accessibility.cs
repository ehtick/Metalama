using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using System;

namespace Metalama.Framework.Tests.AspectTests.Tests.Aspects.Introductions.Interfaces.IntroducePropertyAbstract_Accessibility;

public class IntroductionAttribute : TypeAspect
{
    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        var iface = builder.Advice.IntroduceInterface(builder.Target, "ITest");
        builder.Advice.IntroduceProperty(iface.Declaration, nameof(TestPublic));
        builder.Advice.IntroduceProperty(iface.Declaration, nameof(TestInternal));
        builder.Advice.IntroduceProperty(iface.Declaration, nameof(TestProtected));
        builder.Advice.IntroduceProperty(iface.Declaration, nameof(TestProtectedInternal));
        builder.Advice.IntroduceProperty(iface.Declaration, nameof(TestPrivateProtected));
    }

    [Template]
    public extern int TestPublic{ get; set; }

    [Template]
    internal extern int TestInternal { get; set; }

    [Template]
    protected extern int TestProtected { get; set; }

    [Template]
    protected internal extern int TestProtectedInternal { get; set; }

    [Template]
    private protected extern int TestPrivateProtected { get; set; }
}

// <target>
[IntroductionAttribute]
public class TargetType { }