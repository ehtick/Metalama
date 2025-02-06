// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use <see cref="IServiceProvider"/>.
    /// </summary>
    public interface IServiceLocator : IService
    {
        T GetService<T>( bool throwing = true ) where T : class, IService;
    }
}