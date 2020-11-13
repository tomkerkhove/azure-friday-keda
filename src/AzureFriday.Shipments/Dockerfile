FROM mcr.microsoft.com/dotnet/core/sdk:3.1.101-alpine AS publish
WORKDIR /src
COPY ["AzureFriday.Shipments/AzureFriday.Shipments.csproj", "AzureFriday.Shipments/"]
COPY ["AzureFriday.Core/AzureFriday.Core.csproj", "AzureFriday.Core/"]
RUN dotnet restore AzureFriday.Shipments/AzureFriday.Shipments.csproj
COPY ["AzureFriday.Shipments/", "AzureFriday.Shipments/"]
COPY ["AzureFriday.Core/", "AzureFriday.Core/"]
RUN dotnet publish AzureFriday.Shipments/AzureFriday.Shipments.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/azure-functions/dotnet:3.0 AS runtime
WORKDIR /home/site/wwwroot
EXPOSE 80
COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true