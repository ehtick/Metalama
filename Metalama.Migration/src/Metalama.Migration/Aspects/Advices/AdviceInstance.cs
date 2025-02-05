// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Advising;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Advice is not represented by classes in Metalama, but can be added using methods of <see cref="IAdviceFactory"/>.
    /// </summary>
    public abstract class AdviceInstance
    {
        public abstract object MasterAspectMember { get; }

        public string Description { get; set; }

        public int LinesOfCodeAvoided { get; set; }
    }
}