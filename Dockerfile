FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /app

COPY *.sln .
COPY src/Aimrank.Agones.Cluster.Api/*.csproj ./src/Aimrank.Agones.Cluster.Api/
COPY src/Aimrank.Agones.Cluster.Core/*.csproj ./src/Aimrank.Agones.Cluster.Core/
COPY src/Aimrank.Agones.Cluster.Infrastructure/*.csproj ./src/Aimrank.Agones.Cluster.Infrastructure/
COPY src/Aimrank.Agones.Cluster.Migrator/*.csproj ./src/Aimrank.Agones.Cluster.Migrator/

RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

COPY --from=build /app/out/ .

RUN apt-get update && apt-get install -y curl

HEALTHCHECK --interval=30s --timeout=30s --start-period=30s --retries=5 \
  CMD curl -f http://localhost/ || exit 1
  
ENV ASPNETCORE_ENVIRONMENT=Production

CMD ["dotnet", "Aimrank.Agones.Cluster.Api.dll"]
