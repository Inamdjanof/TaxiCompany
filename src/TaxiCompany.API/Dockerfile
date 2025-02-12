#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TaxiCompany.API/TaxiCompany.API.csproj", "src/TaxiCompany.API/"]
COPY ["src/TaxiCompany.Application/TaxiCompany.Application.csproj", "src/TaxiCompany.Application/"]
COPY ["src/TaxiCompany.Core/TaxiCompany.Core.csproj", "src/TaxiCompany.Core/"]
COPY ["src/TaxiCompany.DataAccess/TaxiCompany.DataAccess.csproj", "src/TaxiCompany.DataAccess/"]
COPY ["tests/TaxiCompany.Shared/TaxiCompany.Shared.csproj", "tests/TaxiCompany.Shared/"]
RUN dotnet restore "./src/TaxiCompany.API/TaxiCompany.API.csproj"
COPY . .
WORKDIR "/src/src/TaxiCompany.API"
RUN dotnet build "./TaxiCompany.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TaxiCompany.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaxiCompany.API.dll"]