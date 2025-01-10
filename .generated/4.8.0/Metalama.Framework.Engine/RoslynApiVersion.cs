// Copyright (c) SharpCrafters s.r.o. See the LICENSE.md file in the root directory of this repository root for details.

#pragma warning disable CS8669 // Nullability
#pragma warning disable IDE0005, IDE0040, SA1013, SA1027, SA1205, SA1210, SA1216, SA1508 // Formatting
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Metalama.Framework.Engine.CompileTime;
using Metalama.Framework.Engine.Utilities.Roslyn;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Metalama.Framework.Engine.CompileTime;

internal enum RoslynApiVersion 
{
	V4_0_1 = 0,
	V4_4_0 = 1,
	V4_8_0 = 2,
	V4_12_0 = 3,
	Current = V4_8_0,
	Lowest = V4_0_1,
	Highest = V4_12_0
}