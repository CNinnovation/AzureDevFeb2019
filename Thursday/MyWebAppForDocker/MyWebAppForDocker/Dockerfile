FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["MyWebAppForDocker/MyWebAppForDocker.csproj", "MyWebAppForDocker/"]
RUN dotnet restore "MyWebAppForDocker/MyWebAppForDocker.csproj"
COPY . .
WORKDIR "/src/MyWebAppForDocker"
RUN dotnet build "MyWebAppForDocker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MyWebAppForDocker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MyWebAppForDocker.dll"]