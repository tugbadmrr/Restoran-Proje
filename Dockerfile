# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyasını kopyala ve restore et
COPY ["LezzetDuragi/LezzetDuragi.csproj", "LezzetDuragi/"]
RUN dotnet restore "LezzetDuragi/LezzetDuragi.csproj"

# Tüm kaynak kodunu kopyala
COPY . .
WORKDIR "/src/LezzetDuragi"
RUN dotnet build "LezzetDuragi.csproj" -c Release -o /app/build

# Publish al
FROM build AS publish
RUN dotnet publish "LezzetDuragi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final Stage (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Render port ayarı (Varsayılan 8080)
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "LezzetDuragi.dll"]
