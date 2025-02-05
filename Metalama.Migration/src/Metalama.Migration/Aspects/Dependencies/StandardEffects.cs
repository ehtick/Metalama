// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// Aspect effects are not supported in Metalama.
    /// </summary>
    public static class StandardEffects
    {
        public const string MemberImport = "MemberImport";

        public const string CustomAttributeIntroduction = "CustomAttributeIntroduction";

        public const string InterfaceIntroduction = "InterfaceIntroduction";

        public const string MemberIntroduction = "MemberIntroduction";

        public const string Custom = "Custom";

        public const string ChangeControlFlow = "ChangeControlFlow";

        public static string GetMemberIntroductionEffect( string memberName )
        {
            return MemberIntroduction + ":" + memberName;
        }

        public static string GetMemberImportEffect( string memberName )
        {
            return MemberImport + ":" + memberName;
        }

        public static string GetInterfaceIntroductionEffect( string typeName )
        {
            return InterfaceIntroduction + ":" + typeName;
        }
    }
}