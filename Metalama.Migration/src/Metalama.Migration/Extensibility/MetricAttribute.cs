// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using JetBrains.Annotations;
using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = true )]
    [PublicAPI]
    public class MetricAttribute : Attribute
    {
        public string MetricName { get; }

        public object Operand { get; }

        public MetricAttribute( string metricName, object operand )
        {
            throw new NotImplementedException();
        }

        public bool AllowImplementationMetrics { get; set; }
    }
}