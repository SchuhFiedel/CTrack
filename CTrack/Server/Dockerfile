#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/CTrack.Server.csproj", "Server/"]
COPY ["Client/CTrack.Client.csproj", "Client/"]
COPY ["Shared/CTrack.Shared.Models.csproj", "Shared/"]
COPY ["CTrack.Server.Contracts/CTrack.Server.Shared.Contracts.csproj", "CTrack.Server.Contracts/"]
COPY ["CTrack.Server.Services/CTrack.Server.Services.csproj", "CTrack.Server.Services/"]
COPY ["CTrack.Server.Shared/CTrack.Server.Shared.csproj", "CTrack.Server.Shared/"]
COPY ["CTrackServer.DAL/CTrack.Server.DAL.csproj", "CTrackServer.DAL/"]
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