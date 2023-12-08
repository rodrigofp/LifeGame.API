FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY "SkillService/*.csproj" "SkillService/"
COPY "Core/*.csproj" "Core/"
RUN dotnet restore "SkillService/SkillService.csproj"

COPY "SkillService/" "SkillService/"
COPY "Core/" "Core/"
WORKDIR "/app/SkillService"
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /out
COPY --from=build-env /out .
ENTRYPOINT [ "dotnet", "SkillService.dll" ]