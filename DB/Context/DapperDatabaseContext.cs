using System.Data;
using MySqlConnector;
using Dapper;
using DB.Entities;

namespace DB.Context;

public class DapperDatabaseContext : IContext
{
    private readonly IDbConnection _connection;

    public DapperDatabaseContext()
    {
        _connection = new MySqlConnection(MainContext.ConnectionString);
        _connection.Open();
    }
    
    public IList<TEntity> GetByQuery<TEntity>(string commandText, DynamicParameters parameters) where TEntity : BaseEntity, new()
    {
        return _connection.Query<TEntity>(commandText, parameters).ToList();
    }

    public TEntity Get<TEntity>(string commandText, DynamicParameters parameters) where TEntity : BaseEntity, new()
    {
        return _connection.QuerySingleOrDefault<TEntity>(commandText, parameters);
    }
    
    public void Dispose()
    {
        if (_connection.State != ConnectionState.Closed)
        {
            _connection.Close();
        }
        
        _connection.Dispose();
    }
}