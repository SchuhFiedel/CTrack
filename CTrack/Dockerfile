#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-bookworm-slim-arm64v8 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-bookworm-slim-arm64v8 AS build
WORKDIR /src
COPY ["Server/CTrack.Server.csproj", "Server/"]
COPY ["Client/CTrack.Client.csproj", "Client/"]
COPY ["Shared/CTrack.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/CTrack.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "CTrack.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CTrack.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CTrack.Server.dll"]