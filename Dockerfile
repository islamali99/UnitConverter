# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copy csproj and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

# Expose port (Render will set PORT env variable)
EXPOSE 8080

# Don't set ASPNETCORE_URLS here - let Program.cs handle it via PORT env variable
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "UnitConverter.dll"]
