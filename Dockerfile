# 1. Aşama: Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Proje dosyalarını kopyala
COPY . ./

# Restore nuget paketleri
RUN dotnet restore

# Projeyi build et
RUN dotnet publish -c Release -o out

# 2. Aşama: Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Build aşamasından çıktı dosyalarını kopyala
COPY --from=build /app/out ./

# Uygulamayı başlat
ENTRYPOINT ["dotnet", "WebAPI.SampleCQRS.dll"]
