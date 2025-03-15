# 1. Using the official .NET 9 image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5173

# 2. Install the SDK and build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["web-api.csproj", "./"]
RUN dotnet restore "./web-api.csproj"

# 3. COPY all code and build
COPY . .
RUN dotnet publish -c Release -o /app/publish

# 4. Run API
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "web-api.dll"]
