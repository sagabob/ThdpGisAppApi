#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TdpGisApi.Services/TdpGisApi.Services.csproj", "TdpGisApi.Services/"]
COPY ["TdpGisApi.Application/TdpGisApi.Application.csproj", "TdpGisApi.Application/"]
COPY ["TdpGisApi.Configuration.Mongodb/TdpGisApi.Configuration.Mongodb.csproj", "TdpGisApi.Configuration.Mongodb/"]
COPY ["TdpGisApi.Configuration/TdpGisApi.Configuration.csproj", "TdpGisApi.Configuration/"]
COPY ["TdpGisApi.Infrastructure.Mongodb/TdpGisApi.Infrastructure.Mongodb.csproj", "TdpGisApi.Infrastructure.Mongodb/"]
RUN dotnet restore "TdpGisApi.Services/TdpGisApi.Services.csproj"
COPY . .
WORKDIR "/src/TdpGisApi.Services"
RUN dotnet build "TdpGisApi.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TdpGisApi.Services.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TdpGisApi.Services.dll"]