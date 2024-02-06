# Anotações

## Iniciando o projeto

 - Dificuldades em iniciar pq estava usando .NET 7.0 e tentando instalar o EntityFrameworkCore sem determinar a versão.
 - Resolvi determinando a versão dotnet add package EntityFrameworkCore --version 7.0.15
 - https://dotnet.microsoft.com/en-us/download/dotnet

## CRUD
 - Somente em Insert usamos o new <Model>
 - Em update e delete consultamos a base de dados d contexto, atualizamos e **Sempre Salvamos**
 - Em Consultas, sempre utilizamos o .ToList() isso garante que a query foi executada;
 - O comando ToList() é sempre o último a ser executado, queries de filtro vem antes, pq está montando o texto.