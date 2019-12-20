# build .NET app:
FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS buildnet
WORKDIR /app

COPY WMCC.csproj ./
RUN dotnet restore

COPY ./ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
# copy .net content
COPY --from=buildnet /app/out .

WORKDIR /app

ENTRYPOINT ["dotnet", "WMCC.dll"]