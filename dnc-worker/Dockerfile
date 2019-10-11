FROM mcr.microsoft.com/dotnet/core/runtime:3.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["dnc-worker.csproj", "./"]
RUN dotnet restore "./dnc-worker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "dnc-worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dnc-worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dnc-worker.dll"]
