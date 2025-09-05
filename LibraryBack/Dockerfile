# Release
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY LibraryBack/ ./LibraryBack/
COPY LibraryCommon/ ./LibraryCommon/
RUN dotnet restore ./LibraryBack/LibraryBack.csproj

RUN dotnet publish ./LibraryBack/LibraryBack.csproj -c $BUILD_CONFIGURATION -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5001

ENTRYPOINT [ "dotnet", "LibraryBack.dll" ]

# Debug
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS debug
WORKDIR /src
RUN dotnet tool install --global dotnet-watch
ENV PATH="$PATH:/root/.dotnet/tools"
COPY LibraryBack/ ./LibraryBack/
COPY LibraryCommon/ ./LibraryCommon/
RUN dotnet restore ./LibraryBack/LibraryBack.csproj
CMD [ "dotnet","watch","run","--project", "./LibraryBack/LibraryBack.csproj" ]