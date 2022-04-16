using Dapper;
using DB.Context;

namespace DB.Repositories.User;

public class UserDapperRepository : IUserRepository
{
    private readonly DapperDatabaseContext _context;

    public UserDapperRepository(DapperDatabaseContext context)
    {
        _context = context;
    }
    
    public Entities.User? GetItem(ulong id)
    {
        const string cmdTxt = "SELECT * FROM USERS WHERE ID=@ID";
        var parameters = new DynamicParameters();
        parameters.Add("@ID", id);
        var user = _context.Get<Entities.User>(cmdTxt, parameters);
        return user;
    }
}