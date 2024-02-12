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

## As no Tracking
 - Depois de montar a consulta do contexto, utilizar o *AsNoTracking()* auxilia na performance, evitando trazer metadados
 - Usar AsNoTracking só em leituras de tabela simples. Quando tiver Join e/ou um update ou delete, NÃO utilizar

## First, Single
 - First(traz o item e se não existir, levanta erro)
 - FirstOrDefault(traz o item e se não existir, retorna nulo)
 - Single(age igual First mas se houver mais de um reg com a mesma chave, retorna erro)

## Mapeamento
 - Por convenção classes e nomes de arquivos no **SINGULAR**.
### Data Annotations
 - Data Annotations servem pra gerar os metadados das classes.
 - "[Table]" é um Data Annotation 
![data_annotation.png](pictures/data_annotation.png)
 - Data Annotations dependem da biblioteca EntityFrameworkCore
 - Data Annotations poluem muito as classes

### Fluent Mapping
- Criada uma classe externa exclusiva pra mapear. 
- Não polui a classe principal
- Mudar tipo de dados fica na classe mapping, regras de negocio fica na classe principal
- 