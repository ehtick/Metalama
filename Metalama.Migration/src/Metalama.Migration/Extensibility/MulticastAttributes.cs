// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// See the remarks on <see cref="MulticastAttribute"/>.
    /// </summary>
    [Flags]
    public enum MulticastAttributes
    {
        Default = 0,

        Private = 1 << 1,

        Protected = 1 << 2,

        Internal = 1 << 3,

        InternalAndProtected = 1 << 4,

        InternalOrProtected = 1 << 5,

        Public = 1 << 6,

        AnyVisibility = Private | Protected | Internal | InternalAndProtected | InternalOrProtected | Public,

        Static = 1 << 7,

        Instance = 1 << 8,

        AnyScope = Static | Instance,

        Abstract = 1 << 9,

        NonAbstract = 1 << 10,

        AnyAbstraction = Abstract | NonAbstract,

        Virtual = 1 << 11,

        NonVirtual = 1 << 12,

        AnyVirtuality = NonVirtual | Virtual,

        Managed = 1 << 13,

        NonManaged = 1 << 14,

        AnyImplementation = Managed | NonManaged,

        Literal = 1 << 15,

        NonLiteral = 1 << 16,

        AnyLiterality = Literal | NonLiteral,

        InParameter = 1 << 17,

        CompilerGenerated = 1 << 18,

        UserGenerated = 1 << 19,

        AnyGeneration = CompilerGenerated | UserGenerated,

        OutParameter = 1 << 20,

        RefParameter = 1 << 21,

        AnyParameter = InParameter | OutParameter | RefParameter,

        All =
            AnyVisibility | AnyVirtuality | AnyScope | AnyImplementation | AnyLiterality | AnyAbstraction |
            AnyGeneration | AnyParameter
    }
}