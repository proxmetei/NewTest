#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Systems/Api/NewTest.Api/NewTest.Api.csproj", "Systems/Api/NewTest.Api/"]
COPY ["Data/NewTest.Context.Migrations/NewTest.Context.Migrations.PgSql/NewTest.Context.Migrations.PgSql.csproj", "Data/NewTest.Context.Migrations/NewTest.Context.Migrations.PgSql/"]
COPY ["Data/NewTest.Context/NewTest.Context.csproj", "Data/NewTest.Context/"]
COPY ["Shared/NewTest.Shared/NewTest.Shared.csproj", "Shared/NewTest.Shared/"]
COPY ["Data/NewTest.Context.Entities/NewTest.Context.Entities.csproj", "Data/NewTest.Context.Entities/"]
COPY ["Data/NewTest.Context.Seeder/NewTest.Context.Seeder.csproj", "Data/NewTest.Context.Seeder/"]
COPY ["Services/NewTest.Services.Logger/NewTest.Services.Logger.csproj", "Services/NewTest.Services.Logger/"]
COPY ["Services/NewTest.Services.Questions/NewTest.Services.Questions.csproj", "Services/NewTest.Services.Questions/"]
COPY ["Services/NewTest.Services.Settings/NewTest.Services.Settings.csproj", "Services/NewTest.Services.Settings/"]
RUN dotnet restore "./Systems/Api/NewTest.Api/NewTest.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/NewTest.Api"
RUN dotnet build "./NewTest.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NewTest.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewTest.Api.dll"]