# Release
FROM mcr.microsoft.com/dotnet/sdk:9.0 as build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY LibraryFront/ ./LibraryFront/
COPY LibraryCommon/ ./LibraryCommon/
RUN dotnet restore ./LibraryFront/LibraryFront.csproj

RUN dotnet publish ./LibraryFront/LibraryFront.csproj -c $BUILD_CONFIGURATION -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5108

ENTRYPOINT [ "dotnet", "LibraryFront.dll" ]


# Debug
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS debug
WORKDIR /src
RUN dotnet tool install --global dotnet-watch
ENV PATH="$PATH:/root/.dotnet/tools"
COPY LibraryFront/ ./LibraryFront/
COPY LibraryCommon ./LibraryCommon/
RUN dotnet restore ./LibraryFront/LibraryFront.csproj
CMD [ "dotnet", "watch", "run","--no-launch-profile","--project", "./LibraryFront/LibraryFront.csproj"]