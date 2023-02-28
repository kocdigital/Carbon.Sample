FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
RUN addgroup --system --gid 1001 customgroup \
    && adduser --system --uid 1001 --ingroup customgroup --shell /bin/sh customuser
RUN chown customuser:customgroup /app && chmod -R 777 /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Carbon.Sample.API/Carbon.Sample.API.csproj", "Carbon.Sample.API/"]
RUN dotnet restore --disable-parallel "Carbon.Sample.API/Carbon.Sample.API.csproj"
COPY . .
WORKDIR "/src/Carbon.Sample.API"
RUN dotnet build "Carbon.Sample.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Carbon.Sample.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Carbon.Sample.API.dll"]