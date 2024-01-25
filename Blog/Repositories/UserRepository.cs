using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository
{
    // variavel privada
    private readonly SqlConnection _connection;
    // metodo construtor com somente um parametro
    public UserRepository(SqlConnection connection)
        => _connection = connection;
    public IEnumerable<User> Get()
        => _connection.GetAll<User>();
    
    public User Get(int id)
        => _connection.Get<User>(id);

    public void Create(User user)
    {
        user.Id = 0;
        _connection.Insert(user);
    }
    
    public void Update (User user)
    {
        if(user.Id != 0)
            _connection.Update(user);
    }

    public void Delete(User user)
    {
        if(user.Id != 0)
            _connection.Delete(user);
    }
    public void Delete(int id)
    {
        if(id == 0)
            return;
        var user = _connection.Get<User>(id);
        _connection.Delete(user);
    }

}
