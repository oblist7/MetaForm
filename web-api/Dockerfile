# 1. Используем официальный образ .NET 9
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000

# 2. Ставим SDK и билдим приложение
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["web-api.csproj", "./"]
RUN dotnet restore "./web-api.csproj"

# 3. Копируем весь код и собираем
COPY . .
RUN dotnet publish -c Release -o /app/publish

# 4. Запускаем API
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "web-api.dll"]
