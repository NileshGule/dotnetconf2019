# Dotnet conf Singapore 2019 Demo

## Create Resource group `demo-dncsg`

```bash

az group create \
-n demo-dncsg \
-l SouthEastAsia

```

## Create Azure Container Registry `dncacr`

```bash

az acr create \
-g demo-dncsg \
-n dncacr \
--sku Basic \
--admin-enabled

```

## Build Docker image using acr

```bash

az acr build \
-r dncacr \
-f "Dockerfile" \
-t dnc-worker:latest .

```

```bash

az acr repository list -n dncacr

az acr repository show -n dncacr -t dnc-worker:latest

az acr repository show-manifests -n dncacr --repository dnc-worker --detail --query '[].{Size: imageSize, Tags: tags}'

```

```Powershell

az acr build `-r dncacr`
-f "Dockerfile" `
-t dnc-worker:latest .

docker build `-f "Dockerfile"`
-t nileshgule/dnc-worker .

docker build `-f "Dockerfile"`
-t nileshgule/dnc-web .

```

## Deploy Kubernetes secret

```bash

kubectl create secret generic secret-appsettings --from-file=./appsettings.secrets.json

```
