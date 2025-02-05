// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Globalization;
using System.Reflection;

namespace PostSharp.Reflection
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public sealed class CustomReflectionBinder : Binder
    {
        public static readonly CustomReflectionBinder Instance =
            new();

        public override FieldInfo BindToField(
            BindingFlags bindingFlags,
            FieldInfo[] match,
            object value,
            CultureInfo culture )
        {
            throw new NotImplementedException();
        }

        public override MethodBase BindToMethod(
            BindingFlags bindingFlags,
            MethodBase[] match,
            ref object[] args,
            ParameterModifier[] modifiers,
            CultureInfo culture,
            string[] names,
            out object state )
        {
            throw new NotImplementedException();
        }

        public override object ChangeType( object value, Type type, CultureInfo culture )
        {
            throw new NotImplementedException();
        }

        public override void ReorderArgumentArray( ref object[] args, object state )
        {
            throw new NotImplementedException();
        }

        public override MethodBase SelectMethod(
            BindingFlags bindingFlags,
            MethodBase[] match,
            Type[] types,
            ParameterModifier[] modifiers )
        {
            throw new NotImplementedException();
        }

        public override PropertyInfo SelectProperty(
            BindingFlags bindingFlags,
            PropertyInfo[] match,
            Type returnType,
            Type[] indexes,
            ParameterModifier[] modifiers )
        {
            throw new NotImplementedException();
        }
    }
}