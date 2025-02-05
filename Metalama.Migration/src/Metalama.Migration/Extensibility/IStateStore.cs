// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public interface IStateStore
    {
        T Get<T>() where T : class;

        void Set<T>( T value ) where T : class;

        T GetOrAdd<T>( Func<T> getter );

        T GetOrNew<T>() where T : new();
    }
}