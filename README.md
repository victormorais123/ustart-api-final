# Api - Projeto UStart

## EF Core

Instalar a ferramenta do EF no CLI
```
dotnet tool install --global dotnet-ef
```
https://docs.microsoft.com/pt-br/ef/core/cli/dotnet

### Migrations

Antes de criar a migrations é necessário adicionar a referência do para a biblioteca do EF Design
```bash
cd Infrastructure 
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.2

cd API
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.2

dotnet clean && dotnet build
```

Como criar as migrations
```bash
cd API

#dotnet ef migrations add usuarios -c UStartContext --project ../Infrastructure/Infrastructure.csproj

#dotnet ef migrations add usuarios_nome -c UStartContext --project ../Infrastructure/Infrastructure.csproj

dotnet ef migrations add grupos_produtos -c UStartContext --project ../Infrastructure/Infrastructure.csproj

dotnet ef migrations add produtos -c UStartContext --project ../Infrastructure/Infrastructure.csproj

dotnet ef migrations add dominio-v1 -c UStartContext --project ../Infrastructure/Infrastructure.csproj
dotnet ef migrations add dominio-v2 -c UStartContext --project ../Infrastructure/Infrastructure.csproj
dotnet ef migrations add cliente_estado_id -c UStartContext --project ../Infrastructure/Infrastructure.csproj
```