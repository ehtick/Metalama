// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// In Metalama, advice methods have no dependencies.
    /// </summary>
    public sealed class AdviceDependencyAttribute : AspectDependencyAttribute
    {
        public AdviceDependencyAttribute(
            AspectDependencyAction action,
            AspectDependencyPosition position,
            string adviceMethodName )
            : base( action, position )
        {
            this.AdviceMethodName = adviceMethodName;
        }

        public AdviceDependencyAttribute( AspectDependencyAction action, string adviceMethodName )
            : base( action )
        {
            this.AdviceMethodName = adviceMethodName;
        }

        public string AdviceMethodName { get; }
    }
}