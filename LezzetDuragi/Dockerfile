# 1. Aşama: İnşa etme (Build)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Önce sadece proje dosyasını kopyala (Daha hızlı build için)
COPY ["LezzetDuragi/LezzetDuragi.csproj", "LezzetDuragi/"]
RUN dotnet restore "LezzetDuragi/LezzetDuragi.csproj"

# Şimdi kalan her şeyi kopyala
COPY . .
WORKDIR "/app/LezzetDuragi"
RUN dotnet publish -c Release -o /app/out

# 2. Aşama: Çalıştırma (Run)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Port ayarı
ENV ASPNETCORE_URLS=http://+:8080

# Başlat
ENTRYPOINT ["dotnet", "LezzetDuragi.dll"]