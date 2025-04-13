# Define the URL for the SBOM (Software Bill of Materials)
$sbomUrl = "https://github.com/metalama/Metalama/dependency-graph/sbom"

# Define the output file for the downloaded SBOM
$tempFile = "$env:TEMP\sbom.json"

# Download the SBOM JSON file
Write-Host "Downloading SBOM from $sbomUrl..."
Invoke-WebRequest -Uri $sbomUrl -OutFile $tempFile -ErrorAction Stop
Write-Host "SBOM downloaded to $tempFile."

# Parse the SBOM JSON file
Write-Host "Parsing SBOM..."
$sbom = Get-Content -Path $tempFile | ConvertFrom-Json

# Function to fetch license and owner information from NuGet.org API
function Get-PackageInfo {
    param ($packageName)
    Start-Sleep -Seconds 1
    $url = "https://www.nuget.org/packages/$packageName"
    try {
        $response = Invoke-WebRequest -Uri $url -ErrorAction Stop
        $content = $response.Content

        # Extract license information
        $licenseMatch = $content -match '<a href="https://licenses.nuget.org/[^"]+" aria-label="License [^"]+">([^<]+) license</a>'
        $license = if ($licenseMatch) { $matches[1] } else { "Unknown" }

        # Extract owner information
        $ownerMatches = $content -match '<a class="username" href="/profiles/[^"]+" title="[^"]+">([^<]+)</a>'
        if ($ownerMatches) {
            $owners = @()
            while ($content -match '<a class="username" href="/profiles/[^"]+" title="[^"]+">([^<]+)</a>') {
                $owners += $matches[1].Trim()
                $content = $content -replace '<a class="username" href="/profiles/[^"]+" title="[^"]+">[^<]+</a>', ''
            }
            $owners = ($owners -join ", ").Trim()
        } elseif ($packageName -like "Microsoft*") {
            $owners = "Microsoft"
        } else {
            $owners = "Unknown"
        }

        # Extract source repository URL
        $sourceRepoMatch = $content -match '<a href="([^"]+)" data-track="outbound-repository-url" title="View the source code for this package" rel="nofollow">'
        $sourceRepo = if ($sourceRepoMatch) { $matches[1] } else { "Unknown" }

        return @{
            License = $license
            Owners = $owners
            SourceRepository = $sourceRepo
        }
    } catch {
        $license = "Cannot find package $url"
        $owners = if ($packageName -like "Microsoft*") { "Microsoft" } else { "Cannot find owners" }
        $sourceRepo = "Cannot find source repository"
        return @{
            License = $license
            Owners = $owners
            SourceRepository = $sourceRepo
        }
    }
}

# Extract, filter, and sort dependency names
Write-Host "Dependencies (NuGet only, excluding System and Metalama namespaces):"
$dependencies = $sbom.packages | Where-Object {
    $_.SPDXID -like "SPDXRef-nuget-*" -and -not (   $_.name -like "System.*" -or $_.name -like "Metalama.*" -or $_.name -like "Microsoft.*" )
} | Sort-Object -Property name

# Fetch and display license, owner information, source repository, and usage type for each dependency in Markdown table format
Write-Host "| Package Name | License | Owners | Source Repository | Usage |"
Write-Host "|--------------|---------|--------|-------------------|-------|"
$dependencies | ForEach-Object {
    $packageInfo = Get-PackageInfo -packageName $_.name
    $packageUrl = "https://www.nuget.org/packages/$($_.name)"
    
    # Determine usage type
    $usage = if ($_.name -like "*Azure.*" -or $_.name -like "LibGit2Sharp"  -or $_.name -like "PostSharp.Engineering"  ) {
        "Building Metalama"
    } elseif ($_.name -like "coverlet*" -or $_.name -like "xunit*" -or $_.name -like "FakeItEasy*"  -or $_.name -like "Diff*") {
        "Testing"
    } else {
        "Flows to End Users"
    }

    Write-Host "| [$($_.name)]($packageUrl) | $($packageInfo.License) | $($packageInfo.Owners) | $($packageInfo.SourceRepository) | $usage |"
}

# Clean up the temporary file
Remove-Item -Path $tempFile -Force
