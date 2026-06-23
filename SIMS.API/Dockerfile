# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
ARG APP_UID=1000
EXPOSE 80


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SIMS.API/SIMS.API.csproj", "SIMS.API/"]
COPY ["SIMS.Application/SIMS.Application.csproj", "SIMS.Application/"]
COPY ["SIMS.Core/SIMS.Core.csproj", "SIMS.Core/"]
COPY ["SIMS.Infrastructure/SIMS.Infrastructure.csproj", "SIMS.Infrastructure/"]
RUN dotnet restore "./SIMS.API/SIMS.API.csproj"
COPY . .
WORKDIR "/src/SIMS.API"
RUN dotnet build "./SIMS.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SIMS.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SIMS.API.dll"]
