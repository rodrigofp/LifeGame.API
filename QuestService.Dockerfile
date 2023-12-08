FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY "QuestsService/*.csproj" "QuestsService/"
COPY "Core/*.csproj" "Core/"
RUN dotnet restore "QuestsService/QuestsService.csproj"

COPY "QuestsService/" "QuestsService/"
COPY "Core/" "Core/"
WORKDIR "/app/QuestsService"
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /out
COPY --from=build-env /out .
ENTRYPOINT [ "dotnet", "QuestsService.dll" ]