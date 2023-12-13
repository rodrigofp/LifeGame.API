FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app
WORKDIR /src

COPY ["QuestsService/QuestsService.csproj", "QuestsService/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "QuestsService/QuestsService.csproj" 

COPY ["QuestsService/", "QuestsService/"]
COPY ["Core/", "Core/"]
WORKDIR "/src/QuestsService"
RUN dotnet build "QuestsService.csproj" -c Release -o /app
RUN dotnet publish "QuestsService.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT [ "dotnet", "QuestsService.dll" ]