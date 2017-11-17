FROM microsoft/dotnet:latest

COPY . /app

WORKDIR /app

RUN dotnet restore

RUN dotnet build

WORKDIR /app/PaasCRMSystemCoreWeb

EXPOSE 8080

ENTRYPOINT dotnet run --no-launch-profile

