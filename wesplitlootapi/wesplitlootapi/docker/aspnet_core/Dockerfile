FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["wesplitlootapi/wesplitlootapi.csproj", "wesplitlootapi/"]
RUN dotnet restore "wesplitlootapi/wesplitlootapi.csproj"
COPY . .
WORKDIR "/src/wesplitlootapi"
RUN dotnet build "wesplitlootapi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "wesplitlootapi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "wesplitlootapi.dll"]