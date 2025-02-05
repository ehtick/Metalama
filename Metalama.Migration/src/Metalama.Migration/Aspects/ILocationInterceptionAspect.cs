// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="OverrideFieldOrPropertyAspect"/>.
    /// </summary>
    public interface ILocationInterceptionAspect : ILocationLevelAspect
    {
        /// <summary>
        /// In Metalama, implement <see cref="OverrideFieldOrPropertyAspect.OverrideProperty"/>.
        /// </summary>
        void OnGetValue( LocationInterceptionArgs args );

        /// <summary>
        /// In Metalama, implement <see cref="OverrideFieldOrPropertyAspect.OverrideProperty"/>.
        /// </summary>
        void OnSetValue( LocationInterceptionArgs args );
    }
}