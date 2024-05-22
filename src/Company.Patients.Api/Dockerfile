
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 4043

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Company.Patients.Api/Company.Patients.Api.csproj", "src/Company.Patients.Api/"]
COPY ["src/Company.Patients.Application/Company.Patients.Application.csproj", "src/Company.Patients.Application/"]
COPY ["src/Company.Patients.Domain/Company.Patients.Domain.csproj", "src/Company.Patients.Domain/"]
COPY ["src/Company.Patients.Infrastructure/Company.Patients.Infrastructure.csproj", "src/Company.Patients.Infrastructure/"]
RUN dotnet restore "src/Company.Patients.Api/Company.Patients.Api.csproj"
COPY . .
WORKDIR "/src/src/Company.Patients.Api"
RUN dotnet build "Company.Patients.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Company.Patients.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Company.Patients.Api.dll"]