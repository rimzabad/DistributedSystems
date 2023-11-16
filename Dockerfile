# Use the official .NET SDK image as a base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory in the container
WORKDIR /app

# Copy the project files to the container
COPY . ./

# Restore NuGet packages and build the application
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Create a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/publish .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "DistributedWeatherApplication.dll"]
