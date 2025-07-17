# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/EquadisRJP.Service/EquadisRJP.Service.csproj", "Services/EquadisRJP.Service/"]
COPY ["Libraries/Application/EquadisRJP.Application/EquadisRJP.Application.csproj", "Libraries/Application/EquadisRJP.Application/"]
COPY ["Libraries/Identity/EquadisRJP.IdentityAuth.Public/EquadisRJP.IdentityAuth.Public.csproj", "Libraries/Identity/EquadisRJP.IdentityAuth.Public/"]
COPY ["Libraries/Application/EquadisRJP.Domain/EquadisRJP.Domain.csproj", "Libraries/Application/EquadisRJP.Domain/"]
COPY ["Libraries/Application/EquadisRJP.Infrastructure/EquadisRJP.Infrastructure.csproj", "Libraries/Application/EquadisRJP.Infrastructure/"]
RUN dotnet restore "./Services/EquadisRJP.Service/EquadisRJP.Service.csproj"
COPY . .
WORKDIR "/src/Services/EquadisRJP.Service"
RUN dotnet build "./EquadisRJP.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EquadisRJP.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EquadisRJP.Service.dll"]