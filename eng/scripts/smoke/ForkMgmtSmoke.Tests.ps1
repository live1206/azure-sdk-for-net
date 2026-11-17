#Requires -Version 7.0
# Local tests for the fork-only, temporary GitHub Actions smoke workflow.
Import-Module Pester -MinimumVersion 5.3.3 -ErrorAction Stop
Import-Module powershell-yaml -MinimumVersion 0.4.1 -ErrorAction Stop

BeforeAll {
    $root = Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..')
    $path = Join-Path $root '.github' 'workflows' 'fork-mgmt-bump-smoke.yml'
    $text = Get-Content -LiteralPath $path -Raw
    $workflow = $text | ConvertFrom-Yaml
}

Describe 'Fork-only management bump smoke workflow' -Tag 'SmokeTest' {
    It 'runs only on an explicit marker commit to the fork smoke branch' {
        $workflow.on.push.branches | Should -Be 'smoke/mgmt-bump-base'
        foreach ($job in $workflow.jobs.Values) {
            $job.if | Should -Match "github.repository == 'live1206/azure-sdk-for-net'"
            $job.if | Should -Match "github.ref == 'refs/heads/smoke/mgmt-bump-base'"
            $job.if | Should -Match "github.event.head_commit.message == 'Run fork-only mgmt bump smoke'"
        }
        $workflow.permissions.contents | Should -Be 'read'
    }

    It 'runs the real updater and official unfiltered regeneration without a write secret' {
        $generate = $workflow.jobs.generate | ConvertTo-Json -Depth 100
        $generate | Should -Match 'Update-MgmtGeneratorDependency.ps1'
        $generate | Should -Match 'eng/scripts/Generate.ps1'
        $generate | Should -Not -Match '(?i)-filter\b'
        $generate | Should -Not -Match 'MGMT_BUMP_SMOKE_TOKEN'
        $generate | Should -Match 'npm ci'
        $generate | Should -Match 'azure.generator/index.json'
        $generate | Should -Match 'Expected an older branded pin'
        $generate | Should -Match 'lockfile does not match'
        $generate | Should -Match 'ErrorActionPreference'
        $generate | Should -Match 'git diff --cached --no-renames --name-only'
    }

    It 'fails regeneration on a nonterminating PowerShell error' {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        New-Item -ItemType Directory -Force (Join-Path $fixture 'eng' 'scripts') | Out-Null
        Set-Content -Path (Join-Path $fixture 'eng' 'scripts' 'Generate.ps1') -Value "Write-Error 'injected generation failure'; `$global:LASTEXITCODE = 0"
        $generate = @($workflow.jobs.generate.steps | Where-Object name -eq 'Update dependencies and regenerate all local management fixtures')[0].run
        $line = @($generate -split "`n" | Where-Object { $_ -match '^\s*& pwsh .*Generate\.ps1' })[0]
        $line | Should -Not -BeNullOrEmpty
        $command = $line + '; exit $LASTEXITCODE'
        $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($command))
        Push-Location $fixture
        try {
            $output = & pwsh -NoLogo -NoProfile -EncodedCommand $encoded 2>&1 | Out-String
            $LASTEXITCODE | Should -Not -Be 0
            $output | Should -Match 'injected generation failure'
        } finally { Pop-Location }
    }

    It 'checks and scopes the generated patch before introducing the token' {
        $steps = @($workflow.jobs.'publish-fork-pr'.steps)
        $validate = @($steps | Where-Object name -eq 'Apply and validate the generated patch')
        $push = @($steps | Where-Object name -eq 'Push to the fork and create a draft smoke PR')
        $validate.Count | Should -Be 1
        $push.Count | Should -Be 1
        [array]::IndexOf($steps, $validate[0]) | Should -BeLessThan ([array]::IndexOf($steps, $push[0]))
        $validate[0].run | Should -Match 'git apply --index --check'
        $validate[0].run | Should -Match 'git diff --cached --no-renames --name-only'
        $validate[0].run | Should -Match 'Unexpected|unexpected path'
        $validate[0].run | Should -Match '6711657492090BE33DCEFB928E3A9C8353E4E86824705A60EFBC903E28EEEDC7'
        $push[0].env.SMOKE_GITHUB_TOKEN | Should -Be '${{ secrets.MGMT_BUMP_SMOKE_TOKEN }}'
        $push[0].run | Should -Match 'https://github.com/live1206/azure-sdk-for-net.git'
        $push[0].run | Should -Match 'https://api.github.com/repos/live1206/azure-sdk-for-net'
        $push[0].run | Should -Match 'smoke/mgmt-bump-base-'
        $push[0].run | Should -Match 'refs/heads/\$baseBranch'
        $push[0].run | Should -Match 'refusing to reuse a colliding smoke branch'
        $push[0].run | Should -Match 'draft = \$true'
        $push[0].run | Should -Match 'Git URL rewrites are not permitted'
    }

    It 'rejects a patch that renames a file from outside the allowed paths' {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $repo = Join-Path $fixture 'repo'
        $temp = Join-Path $fixture 'temp'
        New-Item -ItemType Directory -Force $repo, (Join-Path $temp 'mgmt-bump-smoke') | Out-Null
        git init -b main $repo 2>&1 | Out-Null
        Push-Location $repo
        $saved = @{}
        foreach ($name in @('GITHUB_REPOSITORY','GITHUB_REF','GITHUB_SHA','RUNNER_TEMP')) { $saved[$name] = [Environment]::GetEnvironmentVariable($name) }
        try {
            git config user.name test
            git config user.email test@example.com
            New-Item -ItemType Directory -Force 'eng/scripts/typespec', 'eng/packages/http-client-csharp-mgmt' | Out-Null
            Copy-Item (Join-Path $root 'eng/scripts/typespec/Push-MgmtDependencyBranch.ps1') 'eng/scripts/typespec/Push-MgmtDependencyBranch.ps1'
            Set-Content -Path 'outside.txt' -Value 'unchanged content for a detectable rename'
            git add -A
            git commit -m base 2>&1 | Out-Null
            $sha = git rev-parse HEAD
            git mv outside.txt eng/packages/http-client-csharp-mgmt/renamed.txt
            git diff --cached --binary --output (Join-Path $temp 'mgmt-bump-smoke' 'mgmt-bump.patch')
            git reset --hard HEAD 2>&1 | Out-Null
            $env:GITHUB_REPOSITORY = 'live1206/azure-sdk-for-net'
            $env:GITHUB_REF = 'refs/heads/smoke/mgmt-bump-base'
            $env:GITHUB_SHA = $sha
            $env:RUNNER_TEMP = $temp
            $run = @($workflow.jobs.'publish-fork-pr'.steps | Where-Object name -eq 'Apply and validate the generated patch')[0].run
            $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($run))
            $output = & pwsh -NoLogo -NoProfile -EncodedCommand $encoded 2>&1 | Out-String
            $LASTEXITCODE | Should -Not -Be 0
            $output | Should -Match 'unexpected path'
        } finally {
            foreach ($name in $saved.Keys) { [Environment]::SetEnvironmentVariable($name, $saved[$name]) }
            Pop-Location
        }
    }

    It 'refuses a colliding update branch before creating any PR' {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        New-Item -ItemType Directory -Force $fixture | Out-Null
        $saved = @{}
        foreach ($name in @('GITHUB_REPOSITORY','GITHUB_REF','GITHUB_RUN_ID','GITHUB_WORKSPACE','SMOKE_GITHUB_TOKEN')) { $saved[$name] = [Environment]::GetEnvironmentVariable($name) }
        try {
            $env:GITHUB_REPOSITORY = 'live1206/azure-sdk-for-net'
            $env:GITHUB_REF = 'refs/heads/smoke/mgmt-bump-base'
            $env:GITHUB_RUN_ID = '123'
            $env:GITHUB_WORKSPACE = $fixture
            $env:SMOKE_GITHUB_TOKEN = 'fake-test-token'
            $run = @($workflow.jobs.'publish-fork-pr'.steps | Where-Object name -eq 'Push to the fork and create a draft smoke PR')[0].run
            $stub = @'
function git {
    if ($args[0] -eq 'config') { $global:LASTEXITCODE = 1; return }
    if ($args[0] -eq 'ls-remote') { $global:LASTEXITCODE = 0; return '0123456789012345678901234567890123456789 refs/heads/smoke/mgmt-bump-update-123' }
    throw 'Unexpected git call'
}
function Invoke-RestMethod { throw 'The GitHub API must not be called for a collision' }
'@
            $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($stub + "`n" + $run))
            $output = & pwsh -NoLogo -NoProfile -EncodedCommand $encoded 2>&1 | Out-String
            $LASTEXITCODE | Should -Not -Be 0
            $output | Should -Match 'refusing to reuse a colliding smoke branch'
            $output | Should -Not -Match 'fake-test-token'
        } finally {
            foreach ($name in $saved.Keys) { [Environment]::SetEnvironmentVariable($name, $saved[$name]) }
        }
    }

    It 'creates a draft PR only between the validated fork branches' {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        New-Item -ItemType Directory -Force (Join-Path $fixture 'eng' 'scripts' 'typespec') | Out-Null
        Set-Content -Path (Join-Path $fixture 'eng' 'scripts' 'typespec' 'Push-MgmtDependencyBranch.ps1') -Value 'param($RepoRoot,$Branch,$Version,$GitUrl,[bool]$Failed,$AuthToken); if ($GitUrl -cne "https://github.com/live1206/azure-sdk-for-net.git") { throw "wrong git target" }; $global:mockPushDone=$true'
        $names = @('GITHUB_REPOSITORY','GITHUB_REF','GITHUB_RUN_ID','GITHUB_WORKSPACE','GITHUB_SHA','GITHUB_SERVER_URL','GITHUB_STEP_SUMMARY','SMOKE_GITHUB_TOKEN')
        $saved = @{}; foreach ($name in $names) { $saved[$name] = [Environment]::GetEnvironmentVariable($name) }
        try {
            $env:GITHUB_REPOSITORY = 'live1206/azure-sdk-for-net'
            $env:GITHUB_REF = 'refs/heads/smoke/mgmt-bump-base'
            $env:GITHUB_RUN_ID = '123'
            $env:GITHUB_WORKSPACE = $fixture
            $env:GITHUB_SHA = 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa'
            $env:GITHUB_SERVER_URL = 'https://github.com'
            $env:GITHUB_STEP_SUMMARY = Join-Path $fixture 'summary.md'
            $env:SMOKE_GITHUB_TOKEN = 'fake-test-token'
            $run = @($workflow.jobs.'publish-fork-pr'.steps | Where-Object name -eq 'Push to the fork and create a draft smoke PR')[0].run
            $stub = @'
$global:mockPushDone = $false
function git {
    if ($args[0] -eq 'config') { $global:LASTEXITCODE = 1; return }
    if ($args[0] -eq 'ls-remote') {
        $global:LASTEXITCODE = 0
        if ($global:mockPushDone) { return "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb`trefs/heads/smoke/mgmt-bump-update-123" }
        return
    }
    if ($args[0] -eq 'rev-parse') { $global:LASTEXITCODE = 0; return 'bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb' }
    throw 'Unexpected git call'
}
function Invoke-RestMethod {
    param($Uri,$Method,$Headers,$ContentType,$Body)
    if ($Uri -notlike 'https://api.github.com/repos/live1206/azure-sdk-for-net/*') { throw 'Unexpected API destination' }
    if ($Uri -like '*/git/refs' -or $Uri -like '*/git/ref/heads/*') { return @{ object = @{ sha = $env:GITHUB_SHA } } }
    if ($Uri -like '*/pulls?*') { return @() }
    if ($Uri -like '*/pulls' -and $Method -eq 'Post') {
        $request = $Body | ConvertFrom-Json
        if ($request.base -cne 'smoke/mgmt-bump-base-123' -or $request.head -cne 'live1206:smoke/mgmt-bump-update-123' -or -not $request.draft) { throw 'Unexpected PR target' }
        return @{ html_url = 'https://github.com/live1206/azure-sdk-for-net/pull/42'; base = @{ ref = $request.base; sha = $env:GITHUB_SHA; repo = @{ full_name = 'live1206/azure-sdk-for-net' } }; head = @{ ref = 'smoke/mgmt-bump-update-123'; sha = 'bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb'; repo = @{ full_name = 'live1206/azure-sdk-for-net' } } }
    }
    throw 'Unexpected API request'
}
'@
            $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($stub + "`n" + $run))
            Push-Location $fixture
            try {
                $output = & pwsh -NoLogo -NoProfile -EncodedCommand $encoded 2>&1 | Out-String
                $LASTEXITCODE | Should -Be 0
                $output | Should -Match 'https://github.com/live1206/azure-sdk-for-net/pull/42'
                $output | Should -Not -Match 'fake-test-token'
            } finally { Pop-Location }
        } finally {
            foreach ($name in $saved.Keys) { [Environment]::SetEnvironmentVariable($name, $saved[$name]) }
        }
    }

    It 'does not publish packages or address the Azure repository for writes' {
        $text | Should -Not -Match '(?i)npm\s+publish|dotnet\s+nuget\s+push|EsrpRelease|PublishNuget'
        $publish = $workflow.jobs.'publish-fork-pr' | ConvertTo-Json -Depth 100
        $publish | Should -Not -Match 'github.com/Azure/azure-sdk-for-net'
        $publish | Should -Not -Match 'api.github.com/repos/Azure/'
    }
}
