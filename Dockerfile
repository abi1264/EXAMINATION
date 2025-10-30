# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set working directory
WORKDIR /app

# Copy project files
COPY . .

# Make sure we run as root to avoid ContainerUser error
USER root

# Restore dependencies
RUN dotnet restore "./EXAMINATION.csproj"

# Build the project in Release mode
RUN dotnet build "./EXAMINATION.csproj" -c Release -o /app/build

# Publish the project
RUN dotnet publish "./EXAMINATION.csproj" -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .

# Expose the default port
EXPOSE 5000

# Start the app
ENTRYPOINT ["dotnet", "EXAMINATION.dll"]
