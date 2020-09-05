#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Seguranca.WebAPI/Seguranca.WebAPI.csproj", "Seguranca.WebAPI/"]
RUN dotnet restore "Seguranca.WebAPI/Seguranca.WebAPI.csproj"
COPY . .
WORKDIR "/src/Seguranca.WebAPI"
RUN dotnet build "Seguranca.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Seguranca.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Seguranca.WebAPI.dll"]