
# Create a build container with .NET 6 SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build 

# Setting current directory (of the build container) to be /app
WORKDIR /app

# Copy the curent directory (of the project) to the currne the directory (of the build container, at /app)
COPY . .

# Restoring dependencies.
RUN dotnet restore

# Publishing the application to /app/out 
RUN dotnet publish -c release -o dist


# Create a final container with .NET 6 runtime to run only the built application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

# Setting current directory (of the final container) to be /app
WORKDIR /app

# Using the build container, copying from build: /app/dist to final: /app
COPY --from=build /app/dist .

# Running the application on final container
ENTRYPOINT [ "dotnet", "NginxDemo.dll" ]


