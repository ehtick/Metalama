// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Advices
{
    public abstract class Advice : Attribute
    {
        public string Description { get; set; }

        public int LinesOfCodeAvoided { get; set; }
    }
}