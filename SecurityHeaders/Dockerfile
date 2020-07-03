FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq

WORKDIR /src
COPY ["SecurityHeaders/SecurityHeaders.csproj", "SecurityHeaders/"]
COPY ["UnitTest/UnitTest.csproj", "UnitTest/"]

RUN dotnet restore "SecurityHeaders/SecurityHeaders.csproj"
RUN dotnet restore "UnitTest/UnitTest.csproj"

COPY . .
WORKDIR "/src/SecurityHeaders"
RUN dotnet build "SecurityHeaders.csproj" -c Release -o /app/build

WORKDIR "/src/UnitTest"
RUN dotnet build "UnitTest.csproj" -c Release -o /app/build

RUN dotnet test "UnitTest.csproj" --logger "trx;LogFileName=SecurityHeaders.trx" 
WORKDIR "/src/SecurityHeaders"

FROM build AS publish
RUN dotnet publish "SecurityHeaders.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecurityHeaders.dll"]