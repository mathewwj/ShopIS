# Use the ASP.NET Core runtime image as a base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
ENV DOTNET_URLS=http://+:5281;http://+:5263;http://+:7170;http://+:1668

# ENV SWAGGER_PORT=5263
ENV ASPNETCORE_ENVIRONMENT=Development
# Expose ports
# EXPOSE $DOTNET_URLS
# EXPOSE $SWAGGER_PORT

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /src
ADD api/Temp/floor_plan.svg /app/Data/floor_plan.svg
COPY ["api/api.csproj", "api/"]
COPY ["SVGUtils/SVGUtils.csproj", "SVGUtils/"]
RUN dotnet restore "api/api.csproj"
COPY . .
WORKDIR "/src/api"
RUN dotnet build "api.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "api.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]
