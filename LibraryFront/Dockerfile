FROM bitnami/dotnet-sdk as build
WORKDIR /src

COPY LibraryFront/ .
COPY LibraryCommon/ .
RUN dotnet restore LibraryFront.csproj

RUN dotnet publish LibraryFront.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5108

ENTRYPOINT [ "dotnet", "LibraryFront.dll" ]