// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no equivalent of this aspect in Metalama because Metalama rewrites the code in such a way that field or property initializations
    /// go through the overridden setter. This is done by moving the initializers to the constructor, where it is safe to call the aspect.
    /// </summary>
    public interface IOnInstanceLocationInitializedAspect : ILocationLevelAspect
    {
        /// <summary>
        /// There is no equivalent in Metalama because field and property initializers go through the overridden setter.
        /// </summary>
        void OnInstanceLocationInitialized( LocationInitializationArgs args );
    }
}