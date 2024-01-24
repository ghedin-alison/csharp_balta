using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING =
    @"Server=localhost,1433;Database=Blog;User ID=sa;password=1q2w3e4r@#$;Encrypt=False";

var connection = new SqlConnection(CONNECTION_STRING);
connection.Open();
// ReadUsers(connection);
// ReadUser(connection);
// CreateUser(connection);
// UpdateUser(connection);
DeleteUser(connection);
connection.Close();

static void ReadUsers(SqlConnection connection)
{
    var repository = new UserRepository(connection);
    var users = repository.Get();
    foreach (var user in users)
        Console.WriteLine(user.Name);
}

static void ReadUser(SqlConnection connection)
{
    var repository = new UserRepository(connection);
    var user = repository.Get(1);
    Console.WriteLine(user.Email);
}

static void CreateUser(SqlConnection connection)
{
    var user = new User()
    {
        Bio = "Equipe balta.io",
        Email = "silvia@gmail.com",
        Name = "Silva dos Santos",
        Image = "https://image-silvia.jpg",
        PasswordHash = "HASH",
        Slug = "image-silvia-jpg"
    };
    var repository = new UserRepository(connection);
    repository.Create(user);
    Console.WriteLine("Criado novo usuário");
}

static void UpdateUser(SqlConnection connection)
{
    var user = new User()
    {
        Id = 4,
        Bio = "Equipe Alterada balta.io",
        Email = "severino@gmail.com",
        Name = "Severino",
        Image = "https://severino.jpg",
        PasswordHash = "HASH",
        Slug = "image-severino"
    };
    var repository = new UserRepository(connection);
    repository.Update(user);
    Console.WriteLine("Usuário atualizado");
}

static void DeleteUser(SqlConnection connection)
{
    var repository = new UserRepository(connection);
    var user = repository.Get(4);
    repository.Delete(user);
    Console.WriteLine("Usuário foi excluído com sucesso");
}