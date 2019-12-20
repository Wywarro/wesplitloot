# build .NET app:
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS buildnet
WORKDIR /app

COPY wesplitlootapi/WMCC.csproj ./
RUN dotnet restore

COPY wesplitlootapi/ ./
RUN dotnet publish -c Release -o out

# build Vue app:
FROM node:alpine as buildvue

WORKDIR /app

COPY frontend/package.json .
RUN npm install

# webpack build
COPY frontend .
RUN npm run build

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
# copy .net content
COPY --from=buildnet /app/out .
# copy vue content into .net's static files folder:
COPY --from=buildvue /backend/src/ClientApp /app/ClientApp

WORKDIR /app

ENTRYPOINT ["dotnet", "wesplitlootapi.dll"]