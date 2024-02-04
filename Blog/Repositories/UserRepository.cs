using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository : Repository<User>
{
    // variavel privada
    private readonly SqlConnection _connection;
    // metodo construtor com somente um parametro
    public UserRepository(SqlConnection connection) : base(connection) => _connection = connection;

    // One to Many específico
    public List<User> GetWithRoles()
    {
        
        // QUERY Q TRAZ TODOS OS USUARIOS E SE HOUVER PERFIS ASSOCIADOS, BUSCA ESSA INFORMACAO. POR ISSO LEFT JOIN
        var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] On [UserRole].[RoleId] = [Role].[Id]";
        var users = new List<User>();
        var items = _connection.Query<User, Role, User>(query, (user, role) =>
        {
            var usr = users.FirstOrDefault(x => x.Id == user.Id);
            if (usr == null)
            {
                usr = user;
                //condição pra evitar quebra de código quando role for nulo pra query resultante ##NullReferenceException
                if(role != null)
                    usr.Roles.Add(role);
                
                users.Add(usr);
            }
            else
                usr.Roles.Add(role);

            return user;
        }, splitOn:"Id");
        return users;
    }
}
