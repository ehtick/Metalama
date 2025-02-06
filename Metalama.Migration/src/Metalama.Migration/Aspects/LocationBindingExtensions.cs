// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects
{
    public static class LocationBindingExtensions
    {
        public static object GetValue( this ILocationBinding locationBinding, object instance, Arguments index )
        {
            throw new NotImplementedException();
        }

        public static T GetValue<T>( this ILocationBinding<T> locationBinding, object instance, Arguments index )
        {
            throw new NotImplementedException();
        }

        public static object GetValue( this ILocationBinding locationBinding, object instance )
        {
            throw new NotImplementedException();
        }

        public static T GetValue<T>( this ILocationBinding<T> locationBinding, object instance )
        {
            throw new NotImplementedException();
        }

        public static void SetValue( this ILocationBinding locationBinding, object instance, Arguments index, object value )
        {
            throw new NotImplementedException();
        }

        public static void SetValue<T>( this ILocationBinding<T> locationBinding, object instance, Arguments index, T value )
        {
            throw new NotImplementedException();
        }

        public static void SetValue<T>( this ILocationBinding<T> locationBinding, object instance, T value )
        {
            throw new NotImplementedException();
        }

        public static void SetValue( this ILocationBinding locationBinding, object instance, object value )
        {
            throw new NotImplementedException();
        }
    }
}