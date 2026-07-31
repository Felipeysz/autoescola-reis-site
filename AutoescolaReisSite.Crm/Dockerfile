# AutoescolaReisSite.Crm/Dockerfile

# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY AutoescolaReisSite.Crm/AutoescolaReisSite.Crm.csproj AutoescolaReisSite.Crm/
RUN dotnet restore AutoescolaReisSite.Crm/AutoescolaReisSite.Crm.csproj

COPY AutoescolaReisSite.Crm/ AutoescolaReisSite.Crm/
WORKDIR /src/AutoescolaReisSite.Crm
RUN dotnet publish -c Release -o /app/publish --no-restore

# Etapa 2: runtime (imagem final, bem mais leve que a de build)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "AutoescolaReisSite.Crm.dll"]