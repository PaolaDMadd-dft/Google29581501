FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app
RUN dotnet tool install --global dotnet-dev-certs && dotnet dev-certs https -ep /https/aspnetapp.pfx -p google29581501

# Copy csproj and restore as distinct layers
COPY ./Google29581501/Google29581501.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c release -o out

# Build runtime iage
FROM mcr.microsoft.com/dotnet/aspnet:5.0
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
     && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build-env /app/out .
COPY --from=build-env /https/ /https/

EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENTRYPOINT ["dotnet", "Google29581501.dll"]
