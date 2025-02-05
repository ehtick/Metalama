// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using PostSharp.Aspects.Dependencies;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no aspect configuration in Metalama.
    /// </summary>
    public class AspectConfiguration
    {
        /// <summary>
        /// In Metalama, order aspects using <see cref="AspectOrderAttribute"/>.
        /// </summary>
        public int? AspectPriority { get; set; }

        /// <summary>
        /// In Metalama, aspects are also serializable, but for different reasons. Serialization is not configurable.
        /// </summary>
        public TypeIdentity SerializerType { get; set; }

        /// <summary>
        /// In Metalama, use <see cref="IAspectBuilder{TAspectTarget}"/>.<see cref="IAspectReceiver{TDeclaration}.RequireAspect{TAspect}"/>.
        /// </summary>
        public AspectDependencyAttributeCollection Dependencies { get; set; }

        public UnsupportedTargetAction? UnsupportedTargetAction { get; set; }
    }
}