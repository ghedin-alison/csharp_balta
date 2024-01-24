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

    // CreateManyCategories(connection);
    // UpdateCategory(connection);
    // ListCategories(connection);
    // CreateCategory(connection);
    // ExecuteProcedure(connection);
    // ExecuteReadProcedure(connection);
    // ExecuteScalar(connection);
    // ExecuteReadView(connection);
    // ExecuteOneToOne(connection);
    // ExecuteOneToMany(connection);
    // ExecuteLike(connection, "api");
    ExecuteTransaction(connection);
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
static void ExecuteReadProcedure(SqlConnection connection)
{
    var procedure = "spGetCoursesByCategory";
    var parCategory = new { CategoryId = "25d510c8-3108-44c2-86c5-924d9832aa8c" };
    var courses  = connection.Query(procedure, parCategory, commandType: CommandType.StoredProcedure);

    foreach (var course in courses)
    {
        Console.WriteLine(course.Title);
    }
    

}
static void ExecuteScalar(SqlConnection connection){
    var category = new Category();
    category.Title = "Azure Board4";
    category.Url = "microsoft-azure4";
    category.Description = "Categoria destinada a serviços azure4";
    category.Summary = "Board Azure4";
    category.Order = 18;
    category.Features = true;

    var insertSql = @"INSERT INTO [Category] 
                    OUTPUT inserted.[Id]
                VALUES(NEWID(), 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Features)";
    
    var id = connection.ExecuteScalar<Guid>(insertSql, new
    {
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Features

    });
    Console.WriteLine($"{id} inserido na tabela Category");
    
}
static void ExecuteReadView(SqlConnection connection)
{
    var sql = "SELECT * FROM [vwCourses]";

    var courses = connection.Query(sql);
    foreach (var item in courses)
    {
        Console.WriteLine($"{item.Id} - {item.Title}");
    }
}
static void ExecuteOneToOne(SqlConnection connection)
{
    var sql = @"SELECT * 
                FROM [CareerItem] 
                INNER JOIN [Course]
                ON [CareerItem].[CourseId] = [Course].[Id]";

    var items = connection.Query<CareerItem, Course, CareerItem>(sql,
        (careerItem, course) =>
        {
            careerItem.Course = course;
            return careerItem;
        }, splitOn:"Id");

    foreach (var item in items)
    {
        Console.WriteLine($"{item.Title} - Curso: {item.Course.Title}");
    }
}
static void ExecuteOneToMany(SqlConnection connection)
{
    var sql = @"SELECT
                    [Career].[Id],
                    [Career].[Title],
                    [CareerItem].[CareerId],
                    [CareerItem].[Title]
                FROM
                    [Career]
                INNER JOIN
                    [CareerItem] on [CareerItem].[CareerId] = [Career].[Id]
                ORDER BY [Career].[Title]";

    var careers = new List<Career>();
    
    var items = connection.Query<Career, CareerItem, Career>(
        sql,
        (career, careerItem) =>
        {
            // checar se já tem o item na carreira
            var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
            if (car == null)
            {
                //se a carreira não tem esse item, c
                car = career;
                car.Items.Add(careerItem);
                careers.Add(car);
            }
            else
            {
                car.Items.Add(careerItem);
            }
            return career;
        },
        splitOn: "CareerId"
    );

    foreach (var career in careers)
    {
        Console.WriteLine($"{career.Title}");
        foreach (var item in career.Items)
        {
            Console.WriteLine($"    -    {item.Title}");
        }
    }

}
static void ExecuteLike(SqlConnection connection, string term)
{
    var query = @"SELECT * FROM [Course] WHERE [Title] LIKE @exp";

    var items = connection.Query<Course>(query, new
    {
        exp = $"%{term.ToUpper()}%"
    });

    foreach (var item in items)
    {
        Console.WriteLine($"{item.Title}");
    }
}

static void ExecuteTransaction(SqlConnection connection)
{
    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Minha categoria que não quero salvar";
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

    connection.Open();
    using (var transaction = connection.BeginTransaction())
    {
        var rows = connection.Execute(insertSql, new
        {
            category.Id,
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Features

        }, transaction);
        // transaction.Commit();
        transaction.Rollback();
        Console.WriteLine($"{rows} linhas inseridas na tabela Category");
    }
}
    
