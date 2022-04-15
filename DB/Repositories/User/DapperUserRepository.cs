using Dapper;
using DB.Context;

namespace DB.Repositories.User;
using Entities;

public class DapperUserRepository : IUserRepository
{
    private readonly DapperDatabaseContext _context;

    public DapperUserRepository(DapperDatabaseContext context)
    {
        _context = context;
    }
    
    public User? GetItem(ulong id)
    {
        const string cmdTxt = "SELECT * FROM USERS WHERE ID=@ID";
        var parameters = new DynamicParameters();
        parameters.Add("@ID", id);
        var user = _context.Get<User>(cmdTxt, parameters);
        return user;
    }
}