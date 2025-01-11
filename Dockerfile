FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY release/app/ .

ENV OTL_INSTANCE_ID=""
ENV ASPNETCORE_ENVIRONMENT=""
ENV TZ=Asia/Tashkent
ENV ASPNETCORE_HTTP_PORTS=80

ENTRYPOINT ["dotnet", "Vedy.Api.dll"]