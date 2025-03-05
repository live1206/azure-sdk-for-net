#Requires -Version 7.0

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
. "$PSScriptRoot/../../common/scripts/common.ps1"
Set-ConsoleEncoding

$azurePackageRoot = Resolve-Path "$RepoRoot/eng/packages/http-client-csharp"
$mgmtPackageRoot = Resolve-Path "$RepoRoot/eng/packages/http-client-csharp-mgmt"

function Get-AzureTspCommand {
    param (
        [string]$specFile,
        [string]$generationDir
    )
    $azureCommand = "npx tsp compile $specFile"
    $azureCommand += " --trace @azure-typespec/http-client-csharp"
    $azureCommand += " --emit @azure-typespec/http-client-csharp"
    $configFile = Join-Path $generationDir "tspconfig.yaml"
    if (Test-Path $configFile) {
        $azureCommand += " --config=$configFile"
    }
    $azureCommand += " --option @azure-typespec/http-client-csharp.emitter-output-dir=$generationDir"
    $azureCommand += " --option @azure-typespec/http-client-csharp.save-inputs=true"
    $azureCommand += " --option @azure-typespec/http-client-csharp.new-project=true"
    return $azureCommand
}

function Get-MgmtTspCommand {
    param (
        [string]$specFile,
        [string]$generationDir
    )
    $mgmtCommand = "npx tsp compile $specFile"
    $mgmtCommand += " --trace @azure-typespec/http-client-csharp-mgmt"
    $mgmtCommand += " --emit @azure-typespec/http-client-csharp-mgmt"
    $configFile = Join-Path $generationDir "tspconfig.yaml"
    if (Test-Path $configFile) {
        $mgmtCommand += " --config=$configFile"
    }
    $mgmtCommand += " --option @azure-typespec/http-client-csharp-mgmt.emitter-output-dir=$generationDir"
    $mgmtCommand += " --option @azure-typespec/http-client-csharp-mgmt.save-inputs=true"
    $mgmtCommand += " --option @azure-typespec/http-client-csharp-mgmt.new-project=true"
    return $mgmtCommand
}

function Refresh-Build {
    Write-Host "Building emitter and generator" -ForegroundColor Cyan
    Invoke-LoggedCommand "npm run build:emitter"

    # we don't want to build the entire solution because the test projects might not build until after regeneration
    # generating Azure.Generator.csproj is enough
    Invoke-LoggedCommand "dotnet build $azurePackageRoot/generator/Azure.Generator/src"
    Invoke-LoggedCommand "dotnet build $mgmtPackageRoot/generator/Azure.Generator/src"
}

$azureTestProjectsLocalDir = Join-Path $azurePackageRoot 'generator' 'TestProjects' 'Local'
$mgmtTestProjectsLocalDir = Join-Path $mgmtPackageRoot 'generator' 'TestProjects' 'Local'
$basicTypespecTestProject = Join-Path $azureTestProjectsLocalDir "Basic-TypeSpec"
$mgmtTypespecTestProject = Join-Path $mgmtTestProjectsLocalDir "Mgmt-TypeSpec"

Push-Location $azurePackageRoot

Write-Host "Generating test projects ..."
Refresh-Build

Write-Host "Generating BasicTypeSpec" -ForegroundColor Cyan
Invoke-LoggedCommand (Get-AzureTspCommand "$basicTypespecTestProject/Basic-TypeSpec.tsp" $basicTypespecTestProject)

Write-Host "Building BasicTypeSpec" -ForegroundColor Cyan
Invoke-LoggedCommand "dotnet build $azurePackageRoot/generator/TestProjects/Local/Basic-TypeSpec/src/BasicTypeSpec.csproj"

Write-Host "Generating MgmtTypeSpec" -ForegroundColor Cyan
Invoke-LoggedCommand (Get-MgmtTspCommand "$mgmtTypespecTestProject/main.tsp" $mgmtTypespecTestProject)

# temporarily disable building MgmtTypeSpec because now the generated code of this project cannot build
# Write-Host "Building BasicTypeSpec" -ForegroundColor Cyan
# Invoke-LoggedCommand "dotnet build $azurePackageRoot/generator/TestProjects/Local/Mgmt-TypeSpec/src/MgmtTypeSpec.csproj"

Pop-Location

Write-Host 'Code generation is completed.'
