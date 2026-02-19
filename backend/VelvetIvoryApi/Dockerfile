# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["VelvetIvoryApi.csproj", "./"]
RUN dotnet restore "VelvetIvoryApi.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "VelvetIvoryApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Install curl for health checks (optional but good for Railway)
RUN apt-get update && apt-get install -y curl

# Environment variables
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
# Render sets PORT automatically, but we set a default just in case
ENV PORT=8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "VelvetIvoryApi.dll"]
