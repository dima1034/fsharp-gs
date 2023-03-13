FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["fsharp-exp-23/fsharp-exp-23.fsproj", "fsharp-exp-23/"]
RUN dotnet restore "fsharp-exp-23/fsharp-exp-23.fsproj"
COPY . .
WORKDIR "/src/fsharp-exp-23"
RUN dotnet build "fsharp-exp-23.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "fsharp-exp-23.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "fsharp-exp-23.dll"]
