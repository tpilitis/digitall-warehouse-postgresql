#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001
	
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Digitall.Warehouse.Api/Digitall.Warehouse.Api.csproj", "Digitall.Warehouse.Api/"]
COPY ["Digitall.Persistance.EF/Digitall.Persistance.EF.csproj", "Digitall.Persistance.EF/"]
COPY ["Digitall.Warehouse.Application/Digitall.Warehouse.Application.csproj", "Digitall.Warehouse.Application/"]
COPY ["Digitall.Warehouse.Domain/Digitall.Warehouse.Domain.csproj", "Digitall.Warehouse.Domain/"]
RUN dotnet restore "./Digitall.Warehouse.Api/Digitall.Warehouse.Api.csproj"
COPY . .
WORKDIR "/src/Digitall.Warehouse.Api"
RUN dotnet build "./Digitall.Warehouse.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Digitall.Warehouse.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Digitall.Warehouse.Api.dll"]