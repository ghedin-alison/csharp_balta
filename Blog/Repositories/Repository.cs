using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;


namespace Blog.Repositories;

public class Repository<TModel> where TModel : class
{
// variável privada deposi q a conexão de banco de dados foi compartilhada em Database
    // variavel privada
    // private readonly SqlConnection _connection;
    // // metodo construtor com somente um parametro
    // public Repository(SqlConnection connection)
    //     => _connection = connection;

    public IEnumerable<TModel> Get()
        => Database.Connection.GetAll<TModel>();

    public TModel Get(int id)
        => Database.Connection.Get<TModel>(id);

    public void Create(TModel tModel)
        => Database.Connection.Insert(tModel);
    
    public void Update (TModel tModel)
        => Database.Connection.Update(tModel);

    public void Delete(TModel tModel)
        => Database.Connection.Delete(tModel);
    
    public void Delete(int id)
    {
        if(id == 0)
            return;
        var tModel = Database.Connection.Get<TModel>(id);
        Database.Connection.Delete(tModel);
    }

}