#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 7810

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Vedy.Api/Vedy.Api.csproj", "Vedy.Api/"]
COPY ["Vedy.Infrastructure/Vedy.Infrastructure.csproj", "Vedy.Infrastructure/"]
COPY ["Vedy.Application/Vedy.Application.csproj", "Vedy.Application/"]
COPY ["Vedy.Data/Vedy.Data.csproj", "Vedy.Data/"]
COPY ["Vedy.Common/Vedy.Common.csproj", "Vedy.Common/"]
RUN dotnet restore "./Vedy.Api/./Vedy.Api.csproj"
COPY . .
WORKDIR "/src/Vedy.Api"
RUN dotnet build "./Vedy.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Vedy.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vedy.Api.dll"]