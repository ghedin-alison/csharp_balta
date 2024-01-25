using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;


namespace Blog.Repositories;

public class Repository<TModel> where TModel : class
{
    // variavel privada
    private readonly SqlConnection _connection;
    // metodo construtor com somente um parametro
    public Repository(SqlConnection connection)
        => _connection = connection;

    public IEnumerable<TModel> Get()
        => _connection.GetAll<TModel>();

    public TModel Get(int id)
        => _connection.Get<TModel>(id);

    public void Create(TModel tModel)
        => _connection.Insert(tModel);
    
    public void Update (TModel tModel)
        => _connection.Update(tModel);

    public void Delete(TModel tModel)
        => _connection.Delete(tModel);
    
    public void Delete(int id)
    {
        if(id == 0)
            return;
        var tModel = _connection.Get<TModel>(id);
        _connection.Delete(tModel);
    }

}