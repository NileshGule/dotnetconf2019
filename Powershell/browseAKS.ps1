Param(
    [parameter(Mandatory = $false)]
    [string]$resourceGroupName = "demo-dncsg",
    [parameter(Mandatory = $false)]
    [string]$clusterName = "dncCluster"
)

# Browse AKS dashboard
Write-Host "Browse AKS cluster $clusterName" -ForegroundColor Yellow
az aks browse `
    --resource-group=$resourceGroupName `
    --name=$clusterName