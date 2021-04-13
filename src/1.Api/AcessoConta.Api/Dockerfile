#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/1.Api/AcessoConta.Api/AcessoConta.Api.csproj", "src/1.Api/AcessoConta.Api/"]
RUN dotnet restore "src/1.Api/AcessoConta.Api/AcessoConta.Api.csproj"
COPY . .
WORKDIR "/src/src/1.Api/AcessoConta.Api"
RUN dotnet build "AcessoConta.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AcessoConta.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AcessoConta.Api.dll"]