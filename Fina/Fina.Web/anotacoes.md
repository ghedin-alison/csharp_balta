# Anotações WEB

Essa é a parte do CSharp rodando dentro do browser.
O resultado final desse projeto é uma "dll" que representa html, css e JS e roda no servidor.
Não precisa de .Net instalado no servidor(Github pages por exemplo)

- Inicia no Program.cs e chama App.razor
- No terminal instalar dentro do Fina.Web `dotnet add package MudBlazor`
- Mudblazor gera todo conteudo em tempo de execução
- Páginas, Layouts e componentes:
    - Páginas tem @page
    - Layouts tem @inherits LayoutComponentBase
    - Componentes não tem nenhuma referência.
- Implementar Handlers para consumir a API
- No terminal instalar dentro do Fina.Web `dotnet add package Microsoft.Extensions.Http`
Se for necessário acessar várias APis, configurar e nomear diferentes HttpClient
- ```cs 
  builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
  ```
