$currentWorkingDirectory = (Get-Location).Path | Split-Path -Parent
$helmRootDirectory = Join-Path $currentWorkingDirectory "helm"
$projectRootDirectory = Join-Path $currentWorkingDirectory "k8s"
