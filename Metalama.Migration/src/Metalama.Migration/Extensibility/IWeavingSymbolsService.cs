// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;
using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [InternalImplement]
    public interface IWeavingSymbolsService : IService
    {
        void PushAnnotation(
            object targetDeclaration,
            Type annotationClass = null,
            string arguments = null,
            string description = null,
            int linesOfCodeAvoided = 0 );
    }
}