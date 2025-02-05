
// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public static class DebuggerInterop
    {
        public static long NextStateMachineId = 1;
        public static bool IsInInspectionQuery = false;
    }
}