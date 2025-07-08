FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Infrastructure/EquadisRJP.Identity/EquadisRJP.Identity.csproj", "Infrastructure/EquadisRJP.Identity/"]
RUN dotnet restore "Infrastructure/EquadisRJP.Identity/EquadisRJP.Identity.csproj"
COPY . .
WORKDIR "/src/Infrastructure/EquadisRJP.Identity"
RUN dotnet build "EquadisRJP.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EquadisRJP.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EquadisRJP.Identity.dll"]
