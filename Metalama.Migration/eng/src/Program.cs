// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Engineering.BuildTools;
using PostSharp.Engineering.BuildTools.Build.Model;
using PostSharp.Engineering.BuildTools.Build.Solutions;
using PostSharp.Engineering.BuildTools.Dependencies.Definitions;
using MetalamaDependencies = PostSharp.Engineering.BuildTools.Dependencies.Definitions.MetalamaDependencies.V2025_1;

var product = new Product( MetalamaDependencies.MetalamaMigration )
{
    Solutions = [new DotNetSolution( "src\\Metalama.Migration.sln" ) { CanFormatCode = true }],
    PublicArtifacts = Pattern.Create( "Metalama.Migration.$(PackageVersion).nupkg" ),
    Dependencies = [DevelopmentDependencies.PostSharpEngineering, MetalamaDependencies.MetalamaExtensions],
    MainVersionDependency = MetalamaDependencies.Metalama
};

return new EngineeringApp( product ).Run( args );