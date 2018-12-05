FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY ./src/DShop.Api/bin/docker .
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 5000
ENTRYPOINT dotnet DShop.Api.dll