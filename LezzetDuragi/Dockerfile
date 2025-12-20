# 1. Aşama: İnşa etme (Build)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Proje dosyalarını kopyala
COPY . .

# Kütüphaneleri indir
RUN dotnet restore

# Projeyi yayınlanabilir hale getir
RUN dotnet publish -c Release -o out

# 2. Aşama: Çalıştırma (Run)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Veritabanı dosyasının oluşması için izin ver
ENV ASPNETCORE_URLS=http://+:8080

# Uygulamayı başlat
ENTRYPOINT ["dotnet", "LezzetDuragi.dll"]