FROM mcr.microsoft.com/dotnet/core/sdk:3.1.101-alpine AS publish
WORKDIR /src
COPY . .
RUN dotnet publish AzureFriday.Orders/AzureFriday.Orders.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/runtime:3.1.1-alpine AS runtime
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AzureFriday.Orders.dll"]