// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use a local variable in the template.
    /// </summary>
    public sealed class StateAttribute : AdviceParameterAttribute
    {
        public StateAttribute( StateScope scope )
        {
            this.Scope = scope;
        }

        public StateAttribute( StateScope scope, string slotName )
        {
            this.Scope = scope;
            this.SlotName = slotName;
        }

        public StateScope Scope { get; }

        public string SlotName { get; }
    }
}