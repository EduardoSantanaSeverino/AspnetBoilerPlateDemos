FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/MyCollegeV2.Web.Host/MyCollegeV2.Web.Host.csproj", "src/MyCollegeV2.Web.Host/"]
COPY ["src/MyCollegeV2.Web.Core/MyCollegeV2.Web.Core.csproj", "src/MyCollegeV2.Web.Core/"]
COPY ["src/MyCollegeV2.Application/MyCollegeV2.Application.csproj", "src/MyCollegeV2.Application/"]
COPY ["src/MyCollegeV2.Core/MyCollegeV2.Core.csproj", "src/MyCollegeV2.Core/"]
COPY ["src/MyCollegeV2.EntityFrameworkCore/MyCollegeV2.EntityFrameworkCore.csproj", "src/MyCollegeV2.EntityFrameworkCore/"]
WORKDIR "/src/src/MyCollegeV2.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/MyCollegeV2.Web.Host", "src/MyCollegeV2.Web.Host"]
COPY ["src/MyCollegeV2.Web.Core", "src/MyCollegeV2.Web.Core"]
COPY ["src/MyCollegeV2.Application", "src/MyCollegeV2.Application"]
COPY ["src/MyCollegeV2.Core", "src/MyCollegeV2.Core"]
COPY ["src/MyCollegeV2.EntityFrameworkCore", "src/MyCollegeV2.EntityFrameworkCore"]
WORKDIR "/src/src/MyCollegeV2.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MyCollegeV2.Web.Host.dll"]
