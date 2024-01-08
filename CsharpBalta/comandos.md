# Comandos de terminal 
dotnet new console -o ProjectName

dotnet add package Microsoft.Data.SqlClient

dotnet remove package Microsoft.Data.SqlClient


# Observações Linux

## Conexão com banco de dados Microsoft
Tive dois erros de conexão:
1 - Configuração
Problema: a configuração do projeto por ser executar Microsoft no linux.
Solução: incluir     <RuntimeIdentifier>ubuntu.22.04-x64</RuntimeIdentifier> no ProjectName.csproj.
A versão vai depender do resultado do comando dotnet --info. Utilizar o RID.

1 - Connection String.
Problema: Mesmo cm todos os dados da conexão corretos, indicava handshake security problem.
Solução: adicionar Encrypt=False no final da connection string











