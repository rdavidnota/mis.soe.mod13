FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Security.Web/Security.Web.csproj", "Security.Web/"]
RUN dotnet restore "Security.Web/Security.Web.csproj"
COPY . .
WORKDIR "/src/Security.Web"
RUN dotnet build "Security.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Security.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Security.Web.dll"]