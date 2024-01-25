using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING =
    @"Server=localhost,1433;Database=Blog;User ID=sa;password=1q2w3e4r@#$;Encrypt=False";

var connection = new SqlConnection(CONNECTION_STRING);
connection.Open();
// ReadUsers(connection);
// ReadUser(connection);
// CreateUser(connection);
// UpdateUser(connection);
// DeleteUser(connection);
// ReadRoles(connection);
ReadTags(connection);
// DeleteRole(connection);
connection.Close();


// CRUD Users
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
    var repository = new Repository<User>(connection);
    repository.Create(user);
    Console.WriteLine("Criado novo usuário");
}
static void ReadUsers(SqlConnection connection)
{
    var repository = new Repository<User>(connection);
    var users = repository.Get();
    foreach (var user in users)
        Console.WriteLine(user.Name);
}
static void ReadUser(SqlConnection connection)
{
    var repository = new Repository<User>(connection);
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
    var repository = new Repository<User>(connection);
    repository.Update(user);
    Console.WriteLine("Usuário atualizado");
}
static void DeleteUser(SqlConnection connection)
{
    var repository = new Repository<User>(connection);
    var user = repository.Get(4);
    repository.Delete(user);
    Console.WriteLine("Usuário foi excluído com sucesso");
}

// CRUD Roles
static void CreateRole(SqlConnection connection)
{
    var role = new Role()
    {
        Name = "Developer Backend",
        Slug = "developer-backend"
    };
    var repository = new Repository<Role>(connection);
    repository.Create(role);
    Console.WriteLine("Criado novo perfil");
}
static void ReadRoles(SqlConnection connection)
{
    var repository = new Repository<Role>(connection);
    var roles = repository.Get();
    foreach (var role in roles)
    {
        Console.WriteLine(role.Name);
    }
}
static void ReadRole(SqlConnection connection)
{
    var repository = new Repository<Role>(connection);
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
    var repository = new Repository<Role>(connection);
    repository.Update(role);
    Console.WriteLine("Perfil atualizado");
}
static void DeleteRole(SqlConnection connection)
{
    var repository = new Repository<Role>(connection);
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
    var repository = new Repository<Tag>(connection);
    repository.Create(tag);
    Console.WriteLine("Criado nova tag");
}
static void ReadTags(SqlConnection connection)
{
    var repository = new Repository<Tag>(connection);
    var tags = repository.Get();
    foreach (var tag in tags)
        Console.WriteLine(tag.Name);
}
static void ReadTag(SqlConnection connection)
{
    var repository = new Repository<Tag>(connection);
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
    var repository = new Repository<Tag>(connection);
    repository.Update(tag);
    Console.WriteLine("Tag atualizada");
}
static void DeleteTag(SqlConnection connection)
{
    var repository = new Repository<Tag>(connection);
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
    var repository = new Repository<Category>(connection);
    repository.Create(category);
    Console.WriteLine("Criada nova categoria");
}
static void ReadCategories(SqlConnection connection)
{
    var repository = new Repository<Category>(connection);
    var categories = repository.Get();
    foreach (var category in categories)
        Console.WriteLine(category.Name);
}
static void ReadCategory(SqlConnection connection)
{
    var repository = new Repository<Category>(connection);
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
    var repository = new Repository<Category>(connection);
    repository.Update(category);
    Console.WriteLine("Categoria atualizada");
}
static void DeleteCategory(SqlConnection connection)
{
    var repository = new Repository<Category>(connection);
    repository.Delete(2);
    
}

// atualizar o git