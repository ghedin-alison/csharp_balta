//Microsoft.Data.SqlClient

using System.Data;
using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString  = "Server=localhost,1433;Database=balta;User ID=sa;password=1q2w3e4r@#$;Encrypt=False";


using (var connection = new SqlConnection(connectionString))
{
    // Console.WriteLine("Conectado");
    // connection.Open();
    //
    // using (var command = new SqlCommand())
    // {
    //     command.Connection = connection;
    //     command.CommandType = CommandType.Text;
    //     command.CommandText = "SELECT [Id], [Title] FROM [Category]";
    //     var reader = command.ExecuteReader();
    //
    //     while (reader.Read())
    //     {
    //         Console.WriteLine($"Id: {reader.GetGuid(0)} Title: {reader.GetString(1)}");
    //     }
    // }

    CreateManyCategories(connection);
    // UpdateCategory(connection);
    ListCategories(connection);
    // CreateCategory(connection);
    ExecuteProcedure(connection);
}


static void ListCategories(SqlConnection connection)
{
    var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

    foreach (var cat in categories)
    {
        Console.WriteLine($"Id: {cat.Id} Title: {cat.Title}");
    }
    
}

static void CreateCategory(SqlConnection connection)
{
    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Amazon AWS";
    category.Url = "amazon";
    category.Description = "Categoria destinada a serviços de AWS";
    category.Summary = "AWS Cloud";
    category.Order = 8;
    category.Features = false;

    var insertSql = @"INSERT INTO [Category] 
                VALUES(@Id, 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Features)";
    
    var rows = connection.Execute(insertSql, new
    {
        category.Id,
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Features

    });
    Console.WriteLine($"{rows} linhas inseridas na tabela Category");
    
}

static void UpdateCategory(SqlConnection connection)
{
    var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
    var rows = connection.Execute(updateQuery, new
    {
        id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
        title = "FrontEnd 2023"
    });
    Console.WriteLine($"{rows} registros atualizados");
}

static void CreateManyCategories(SqlConnection connection)
{
    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Novo Titulo 1";
    category.Url = "novo-titulo-2";
    category.Description = "Testes de inclusao multipla";
    category.Summary = "teste inclusao";
    category.Order = 9;
    category.Features = false;

    var category2 = new Category();
    category2.Id = Guid.NewGuid();
    category2.Title = "Novo Titulo 2";
    category2.Url = "novo-titulo-2";
    category2.Description = "Testes de inclusao multipla";
    category2.Summary = "teste inclusao";
    category2.Order = 10;
    category2.Features = true;

    var insertSql = @"INSERT INTO [Category] 
                VALUES(@Id, 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Features)";
    
    var rows = connection.Execute(insertSql, new[]
        {
            new {
            category.Id,
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Features
            },
            new{
                category2.Id,
                category2.Title,
                category2.Url,
                category2.Summary,
                category2.Order,
                category2.Description,
                category2.Features
            }
        }
    );
    Console.WriteLine($"{rows} linhas inseridas na tabela Category");
    
}

static void ExecuteProcedure(SqlConnection connection)
{
    var procedure = "spDeleteStudent";
    var parStudent = new { StudentId = "c69d74d8-1537-4388-8e60-236244732903" };
    var affectedRows  = connection.Execute(procedure, parStudent, commandType: CommandType.StoredProcedure);
    Console.WriteLine($"{affectedRows} linhas excluidas na tabela Student");

}