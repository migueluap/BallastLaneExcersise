FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/BallastLane.UI.Web/BallastLane.UI.Web.csproj", "src/BallastLane.UI.Web/"]
RUN dotnet restore "src/BallastLane.UI.Web/BallastLane.UI.Web.csproj"
COPY . .
WORKDIR "/src/src/BallastLane.UI.Web"
RUN dotnet build "BallastLane.UI.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BallastLane.UI.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BallastLane.UI.Web.dll"]