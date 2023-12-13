FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app
WORKDIR /src

COPY ["SkillService/SkillService.csproj", "SkillService/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "SkillService/SkillService.csproj" 

COPY ["SkillService/", "SkillService/"]
COPY ["Core/", "Core/"]
WORKDIR "/src/SkillService"
RUN dotnet build "SkillService.csproj" -c Release -o /app
RUN dotnet publish "SkillService.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT [ "dotnet", "SkillService.dll" ]