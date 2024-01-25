using Blog.Models;
using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Blog.Repositories;

public class RoleRepository
{
    private readonly SqlConnection _connection;
    // metodo construtor com somente um parametro
    public RoleRepository(SqlConnection connection)
        => _connection = connection;
    
    public IEnumerable<Role> Get()
        => _connection.GetAll<Role>();
    
    public Role Get(int id)
        => _connection.Get<Role>(id);

    public void Create(Role role)
    {
        role.Id = 0;
        _connection.Insert(role);
    }
    
    public void Update (Role role)
    {
        if(role.Id != 0)
            _connection.Update(role);
    }

    public void Delete(Role role)
    {
        if(role.Id != 0)
            _connection.Delete(role);
    }
    public void Delete(int id)
    {
        if(id == 0)
            return;
        var role = _connection.Get<Role>(id);
        _connection.Delete(role);
    }
    
}