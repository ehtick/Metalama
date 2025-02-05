(& dotnet nuget locals http-cache -c) | Out-Null
& dotnet run --project "$PSScriptRoot\eng\src\BuildMetalamaMigration.csproj" -- $args
exit $LASTEXITCODE

