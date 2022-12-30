FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PocMvcAppWithFluentValidation/PocMvcAppWithFluentValidation.csproj", "PocMvcAppWithFluentValidation/"]
RUN dotnet restore "PocMvcAppWithFluentValidation/PocMvcAppWithFluentValidation.csproj"
COPY . .
WORKDIR "/src/PocMvcAppWithFluentValidation"
RUN dotnet build "PocMvcAppWithFluentValidation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PocMvcAppWithFluentValidation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PocMvcAppWithFluentValidation.dll"]
