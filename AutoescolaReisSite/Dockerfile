# AutoescolaReisSite/Dockerfile

# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY AutoescolaReisSite/AutoescolaReisSite.csproj AutoescolaReisSite/
RUN dotnet restore AutoescolaReisSite/AutoescolaReisSite.csproj

COPY AutoescolaReisSite/ AutoescolaReisSite/
WORKDIR /src/AutoescolaReisSite
RUN dotnet publish -c Release -o /app/publish --no-restore

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "AutoescolaReisSite.dll"]