# Comandos

dotnet add package Microsoft.Data.SqlClient
dotnet add package Dapper
dotnet add package Dapper.Contrib

Para funcionar o pacote da Microsoft no linux,
inserir:
<RuntimeIdentifier>ubuntu.22.04-x64</RuntimeIdentifier>
No <PropertyGroup> do Csproj

Esse porojeto está usando o Dapper.Contrib.Extensions
Esse pacote traz comandos prontos de SQL como o GETALL e deixa o código mais fácil.

