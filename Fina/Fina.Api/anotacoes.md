# Anotações da Api

Na Api ficarão os acessos a dados sensíveis(connection string).<br>
Mapear o banco de dados, criar as migrações, gerar banco de dados.<br>
Na sequencia implementar os handlers que acessarão os requests e retornarão responses.

 - Instalar via terminal: `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
 - Instalar via terminal: `dotnet add package Microsoft.EntityFrameworkCore.Design`
 - Criar diretório Data/Mappings cada modelo herda da interface IEntityTypeConfiguration, implementar.
- 