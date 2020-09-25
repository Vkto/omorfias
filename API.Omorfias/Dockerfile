# FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
# WORKDIR /app

# ARG BUILD_CONFIGURATION=Debug
# ENV ASPNETCORE_ENVIRONMENT=Development
# ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
# ENV ASPNETCORE_URLS=https://+:5001
# EXPOSE 5001

# FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
# WORKDIR /src
# COPY "API.Omorfias/API.Omorfias.csproj" ./
# RUN dotnet restore "API.Omorfias.csproj"
# COPY . .
# RUN dotnet build . -c Release -o /app

# FROM build as publish
# RUN dotnet publish "./API.Omorfias/API.Omorfias.csproj" -c Release -o app

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app .


# # ENTRYPOINT [ "dotnet", "API.Omorfias.dll" ]
# CMD ASPNETCORE_URLS=http://*:$PORT dotnet app/API.Omorfias.dll



FROM mcr.microsoft.com/dotnet/core/sdk:3.1
# WORKDIR /app
ENV PORT=5001
EXPOSE 5001

COPY "API.Omorfias.csproj" ./
# RUN dotnet restore

COPY . ./
# RUN dotnet publish -c Release -o API.Omorfias/
CMD ASPNETCORE_URLS=http://*:$PORT dotnet bin/Debug/netcoreapp3.1/API.Omorfias.dll