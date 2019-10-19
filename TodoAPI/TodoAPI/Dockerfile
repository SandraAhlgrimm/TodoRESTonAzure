FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TodoAPI/TodoAPI/TodoAPI.csproj", "TodoAPI/TodoAPI/"]
RUN dotnet restore "TodoAPI/TodoAPI/TodoAPI.csproj"
COPY . .
WORKDIR "/src/TodoAPI/TodoAPI"
RUN dotnet build "TodoAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoAPI.dll"]