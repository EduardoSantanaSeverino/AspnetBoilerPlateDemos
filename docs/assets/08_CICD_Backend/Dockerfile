# Build Environment: Reuse/Cached if no changes in csproj files
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY ./OTHERBackend.sln .
COPY ./OtherBackend/OtherBackend.csproj ./OtherBackend/
COPY ./OtherBackendTests/OtherBackendTests.csproj ./OtherBackendTests/
RUN dotnet restore
# Copy All Files
COPY . .
RUN dotnet build -c Release

# Build testrunner image
FROM build as testrunner
WORKDIR /app/OtherBackendTests
CMD ["dotnet", "test", "-c:Release", "--no-build", "--logger:trx"]

# Publish 
FROM build as publish
WORKDIR /app/OtherBackend
RUN dotnet publish -c Release -o out --no-build

# Build runtime image | Set TARGET_ENV in VM to override
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
ARG TARGET_ENV=Development
ENV ASPNETCORE_ENVIRONMENT $TARGET_ENV
EXPOSE 80
WORKDIR /app
COPY --from=publish /app/OtherBackend/out .
ENTRYPOINT ["dotnet", "OtherBackend.dll"]