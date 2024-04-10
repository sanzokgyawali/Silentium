FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/AnonymousChat.Web.Host/AnonymousChat.Web.Host.csproj", "src/AnonymousChat.Web.Host/"]
COPY ["src/AnonymousChat.Web.Core/AnonymousChat.Web.Core.csproj", "src/AnonymousChat.Web.Core/"]
COPY ["src/AnonymousChat.Application/AnonymousChat.Application.csproj", "src/AnonymousChat.Application/"]
COPY ["src/AnonymousChat.Core/AnonymousChat.Core.csproj", "src/AnonymousChat.Core/"]
COPY ["src/AnonymousChat.EntityFrameworkCore/AnonymousChat.EntityFrameworkCore.csproj", "src/AnonymousChat.EntityFrameworkCore/"]
WORKDIR "/src/src/AnonymousChat.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/AnonymousChat.Web.Host", "src/AnonymousChat.Web.Host"]
COPY ["src/AnonymousChat.Web.Core", "src/AnonymousChat.Web.Core"]
COPY ["src/AnonymousChat.Application", "src/AnonymousChat.Application"]
COPY ["src/AnonymousChat.Core", "src/AnonymousChat.Core"]
COPY ["src/AnonymousChat.EntityFrameworkCore", "src/AnonymousChat.EntityFrameworkCore"]
WORKDIR "/src/src/AnonymousChat.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "AnonymousChat.Web.Host.dll"]
