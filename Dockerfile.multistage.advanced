FROM mcr.microsoft.com/dotnet/core/sdk AS build
WORKDIR /app

ARG sln=DShop.Api.sln
ARG api=src/DShop.Api
ARG configuration=Release
ARG feed='--source "https://api.nuget.org/v3/index.json"'

COPY ${sln} ./
COPY ./${api} ./${api}/

RUN dotnet restore /property:Configuration=${configuration} ${feed}

COPY . ./
RUN dotnet publish ${api} -c ${configuration} -o out ${feed}

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app

ARG api=src/DShop.Api

COPY --from=builder /app/${api}/out/ .

ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker

EXPOSE 5000

ENTRYPOINT dotnet DShop.Api.dll