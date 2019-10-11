FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["dnc-web.csproj", "./"]
RUN dotnet restore "./dnc-web.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "dnc-web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dnc-web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dnc-web.dll"]
