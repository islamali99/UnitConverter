# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copy everything
COPY . .

# Restore and build
RUN dotnet restore
RUN dotnet publish -c Release -o /app --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

# Expose port
EXPOSE 8080

# Set to Development to see detailed errors
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "UnitConverter.dll"]
