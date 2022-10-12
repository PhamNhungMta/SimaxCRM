#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SimaxCrm/SimaxCrm.csproj", "SimaxCrm/"]
COPY ["SimaxCrm.Data/SimaxCrm.Data.csproj", "SimaxCrm.Data/"]
COPY ["SimaxCrm.Model/SimaxCrm.Model.csproj", "SimaxCrm.Model/"]
COPY ["SimaxCrm.Service/SimaxCrm.Service.csproj", "SimaxCrm.Service/"]
RUN dotnet restore "SimaxCrm/SimaxCrm.csproj"
COPY . .
WORKDIR "/src/SimaxCrm"
RUN dotnet ef database update
RUN dotnet build "SimaxCrm.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet tool restore
RUN dotnet ef database update
RUN dotnet publish "SimaxCrm.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimaxEstateCrm.dll"]