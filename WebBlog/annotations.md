# Anotações

## Passo a passo pra início do projeto

- dotnet new web -o WebBLog
- acessar o diretório e copiar data e models de um projeto anterior
- no diretorio Data, documento DataContext, a connections string do sqlServer tem que ter o Encrypt=False
- no arquivo .csproj incluir <RuntimeIdentifier>ubuntu.22.04-x64</RuntimeIdentifier>
- adicionar o pacote SqlServer e Design
- executar migrations
- atualizar database

# Token
 - Criar a classe Token Service
 - instalar pacotes:<br>
        - Microsoft.AspNetCore.Authentication<br>
        - Microsoft.AspNetCore.Authentication.JwtBearer<br>