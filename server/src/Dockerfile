FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY Jaroszek.PoC.SignalRChat.sln Jaroszek.PoC.SignalRChat.sln
COPY Jaroszek.PoC.SignalRChat.Domain/Jaroszek.PoC.SignalRChat.Domain.csproj Jaroszek.PoC.SignalRChat.Domain/Jaroszek.PoC.SignalRChat.Domain.csproj
COPY Jaroszek.PoC.SignalRChat.Application/Jaroszek.PoC.SignalRChat.Application.csproj Jaroszek.PoC.SignalRChat.Application/Jaroszek.PoC.SignalRChat.Application.csproj
COPY Jaroszek.PoC.SignalRChat.Infrastructure/Jaroszek.PoC.SignalRChat.Infrastructure.csproj Jaroszek.PoC.SignalRChat.Infrastructure/Jaroszek.PoC.SignalRChat.Infrastructure.csproj
COPY Jaroszek.PoC.SignalRChat.WebUI/Jaroszek.PoC.SignalRChat.WebUI.csproj Jaroszek.PoC.SignalRChat.WebUI/Jaroszek.PoC.SignalRChat.WebUI.csproj

RUN dotnet restore

COPY . .

RUN dotnet build --configuration Release --output /app/build
RUN dotnet publish --configuration Release --output /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

RUN apt-get update && apt-get install -y net-tools iputils-ping telnet

COPY --from=build /app/publish .

RUN groupadd -g 10000 dotnet && useradd -u 10000 -g dotnet dotnet && chown -R dotnet:dotnet /app
USER dotnet:dotnet

ENV ASPNETCORE_URLS http://+:5001
EXPOSE 5001
ENTRYPOINT [ "dotnet", "Jaroszek.PoC.SignalRChat.WebUI.dll"]