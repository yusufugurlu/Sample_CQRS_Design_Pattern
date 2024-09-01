# SampleCQRS API

Bu proje, .NET Core ve Entity Framework Core kullanılarak geliştirilmiş basit bir Web API örneğidir. Proje, CQRS(Command Query Responsibility Segregation) deseni, Unit of work deseni kullanılmuştır. 
SQL Server veritabanına bağlanır ve Docker kullanılarak çalıştırılabilir.

## Gereksinimler

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started)


Projeyi docker üzerinden çalıştırmak için aşağıdaki komutu kullanın:

```bash
docker-compose up --build
