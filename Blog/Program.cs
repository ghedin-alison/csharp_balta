using Blog;
using Blog.Models;
using Blog.Repositories;
using Blog.Services.TagServices;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING =
    @"Server=localhost,1433;Database=Blog;User ID=sa;password=1q2w3e4r@#$;Encrypt=False";

Database.Connection = new SqlConnection(CONNECTION_STRING);
Database.Connection.Open();
// ReadUsers(connection);
// ReadUsersWithRoles(connection);
// ReadUser(connection);
// CreateUser(connection);
// UpdateUser(connection);
// DeleteUser(connection);
// ReadRoles(connection);
// ReadTags(connection);
// DeleteRole(connection);
Load();
Console.ReadKey();
Database.Connection.Close();

void Load()
{
    Console.Clear();
    Console.WriteLine("Meu Blog");
    Console.WriteLine("==============");
    Console.WriteLine("Digite uma opção: ");
    Console.WriteLine();
    Console.WriteLine("1 - Gestão de Usuário");
    Console.WriteLine("2 - Gestão de Perfil");
    Console.WriteLine("3 - Gestão de Categoria");
    Console.WriteLine("4 - Gestão de Tags");
    Console.WriteLine("5 - Vincular Perfil/Usuário");
    Console.WriteLine("6 - Vincular Post/Tag");
    Console.WriteLine("7 - Relatórios");
    Console.WriteLine();
    Console.WriteLine();
    var option = short.Parse(Console.ReadLine()!);
    switch (option)
    {
        case 4:
            MenuTagService.Load();
            break;
        default:
            Load();
            break;
    }
}




// CRUD Users
static void CreateUser(SqlConnection connection)
{
    var user = new User()
    {
        Bio = "Equipe balta.io",
        Email = "silvia@gmail.com",
        Name = "Silvia dos Santos",
        Image = "https://image-silvia.jpg",
        PasswordHash = "HASH",
        Slug = "image-silvia-jpg"
    };
    var repository = new Repository<User>();
    repository.Create(user);
    Console.WriteLine("Criado novo usuário");
}
static void ReadUsers(SqlConnection connection)
{
    var repository = new Repository<User>();
    var users = repository.Get();
    foreach (var user in users)
        Console.WriteLine($"Nome do usuário: {user.Name}");
}
static void ReadUser(SqlConnection connection)
{
    var repository = new Repository<User>();
    var user = repository.Get(1);
    Console.WriteLine(user.Email);
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
    var repository = new Repository<User>();
    repository.Update(user);
    Console.WriteLine("Usuário atualizado");
}
static void DeleteUser(SqlConnection connection)
{
    var repository = new Repository<User>();
    var user = repository.Get(4);
    repository.Delete(user);
    Console.WriteLine("Usuário foi excluído com sucesso");
}
static void ReadUsersWithRoles(SqlConnection connection)
{
    var repository = new UserRepository();
    var items = repository.GetWithRoles();
    foreach (var item in items)
    {
        Console.WriteLine($"Nome do usuário: {item.Name}");
        foreach (var role in item.Roles)
        {
            Console.WriteLine($" - {role.Name}");
        }
    }
}

// CRUD Roles
static void CreateRole(SqlConnection connection)
{
    var role = new Role()
    {
        Name = "Developer Backend",
        Slug = "developer-backend"
    };
    var repository = new Repository<Role>();
    repository.Create(role);
    Console.WriteLine("Criado novo perfil");
}
static void ReadRoles(SqlConnection connection)
{
    var repository = new Repository<Role>();
    var roles = repository.Get();
    foreach (var role in roles)
    {
        Console.WriteLine(role.Name);
    }
}
static void ReadRole(SqlConnection connection)
{
    var repository = new Repository<Role>();
    var role = repository.Get(1);
    Console.WriteLine(role.Name);
}
static void UpdateRole(SqlConnection connection)
{
    var role = new Role()
    {
        Id = 4,
        Name = "FrontEnd Developer",
        Slug = "frontend-developer"
    };
    var repository = new Repository<Role>();
    repository.Update(role);
    Console.WriteLine("Perfil atualizado");
}
static void DeleteRole(SqlConnection connection)
{
    var repository = new Repository<Role>();
    repository.Delete(2);
    
}

// CRUD Tags
static void CreateTag(SqlConnection connection)
{
    var tag = new Tag()
    {
        Name = "Django",
        Slug = "django"
    };
    var repository = new Repository<Tag>();
    repository.Create(tag);
    Console.WriteLine("Criado nova tag");
}
static void ReadTags(SqlConnection connection)
{
    var repository = new Repository<Tag>();
    var tags = repository.Get();
    foreach (var tag in tags)
        Console.WriteLine(tag.Name);
}
static void ReadTag(SqlConnection connection)
{
    var repository = new Repository<Tag>();
    var tag = repository.Get(1);
    Console.WriteLine(tag.Name);
}
static void UpdateTag(SqlConnection connection)
{
    var tag = new Tag()
    {
        Id = 3,
        Name = "Spring",
        Slug = "spring"
    };
    var repository = new Repository<Tag>();
    repository.Update(tag);
    Console.WriteLine("Tag atualizada");
}
static void DeleteTag(SqlConnection connection)
{
    var repository = new Repository<Tag>();
    repository.Delete(2);
    
}

// CRUD Categories
static void CreateCategory(SqlConnection connection)
{
    var category = new Category()
    {
        Name = "Backend",
        Slug = "backend"
    };
    var repository = new Repository<Category>();
    repository.Create(category);
    Console.WriteLine("Criada nova categoria");
}
static void ReadCategories(SqlConnection connection)
{
    var repository = new Repository<Category>();
    var categories = repository.Get();
    foreach (var category in categories)
        Console.WriteLine(category.Name);
}
static void ReadCategory(SqlConnection connection)
{
    var repository = new Repository<Category>();
    var category = repository.Get(1);
    Console.WriteLine(category.Name);
}
static void UpdateCategory(SqlConnection connection)
{
    var category = new Category()
    {
        Id = 3,
        Name = "Frontend",
        Slug = "frontend"
    };
    var repository = new Repository<Category>();
    repository.Update(category);
    Console.WriteLine("Categoria atualizada");
}
static void DeleteCategory(SqlConnection connection)
{
    var repository = new Repository<Category>();
    repository.Delete(2);
    
}

// atualizar o git