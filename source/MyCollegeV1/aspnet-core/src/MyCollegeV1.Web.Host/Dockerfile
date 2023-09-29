FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/MyCollegeV1.Web.Host/MyCollegeV1.Web.Host.csproj", "src/MyCollegeV1.Web.Host/"]
COPY ["src/MyCollegeV1.Web.Core/MyCollegeV1.Web.Core.csproj", "src/MyCollegeV1.Web.Core/"]
COPY ["src/MyCollegeV1.Application/MyCollegeV1.Application.csproj", "src/MyCollegeV1.Application/"]
COPY ["src/MyCollegeV1.Core/MyCollegeV1.Core.csproj", "src/MyCollegeV1.Core/"]
COPY ["src/MyCollegeV1.EntityFrameworkCore/MyCollegeV1.EntityFrameworkCore.csproj", "src/MyCollegeV1.EntityFrameworkCore/"]
WORKDIR "/src/src/MyCollegeV1.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/MyCollegeV1.Web.Host", "src/MyCollegeV1.Web.Host"]
COPY ["src/MyCollegeV1.Web.Core", "src/MyCollegeV1.Web.Core"]
COPY ["src/MyCollegeV1.Application", "src/MyCollegeV1.Application"]
COPY ["src/MyCollegeV1.Core", "src/MyCollegeV1.Core"]
COPY ["src/MyCollegeV1.EntityFrameworkCore", "src/MyCollegeV1.EntityFrameworkCore"]
WORKDIR "/src/src/MyCollegeV1.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MyCollegeV1.Web.Host.dll"]
