FROM bitnami/dotnet-sdk as build
WORKDIR /src

COPY LibraryBack .
COPY LibraryCommon .
RUN dotnet restore LibraryBack.csproj

RUN dotnet publish LibraryBack.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5001

ENTRYPOINT [ "dotnet", "LibraryBack.dll" ]