# Anotações da Api

Na Api ficarão os acessos a dados sensíveis(connection string).<br>
Mapear o banco de dados, criar as migrações, gerar banco de dados.<br>
Na sequencia implementar os handlers que acessarão os requests e retornarão responses.

 - Instalar via terminal: `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
 - Instalar via terminal: `dotnet add package Microsoft.EntityFrameworkCore.Design`
 - Criar diretório Data/Mappings cada modelo herda da interface IEntityTypeConfiguration, implementar.
 - Criar AppDbContext
 - Criar conexão no program:
```cs
const string connectionString =
   "Server=localhost,1433;Database=Fina;User ID=sa;Password=1q2w3e4r@#$;encrypt=False;";

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));
```

 - no Terminal `dotnet ef migrations add v1`
 - no Terminal `dotnet ef database update`
 
 - Implementar os Handlers no diretório Handlers
 - No vídeo em 1:42 há uma explicação excelente sobre métodos de busca e performance para paginação.
