FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ["SmartMeterLogger.sln", "."]
COPY ["./SmartMeterLogger.Api/*.csproj", "./SmartMeterLogger.Api/"]
COPY ["./SmartMeterLogger.Business/*.csproj", "./SmartMeterLogger.Business/"]
COPY ["./SmartMeterLogger.Data/*.csproj", "./SmartMeterLogger.Data/"]

RUN dotnet restore

# copy everything else and build app
COPY ["./SmartMeterLogger.Api/.", "./SmartMeterLogger.Api/"]
COPY ["./SmartMeterLogger.Business/.", "./SmartMeterLogger.Business/"]
COPY ["./SmartMeterLogger.Data/.", "./SmartMeterLogger.Data/"]

WORKDIR /app/SmartMeterLogger.Api
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "SmartMeterLogger.Api.dll"]