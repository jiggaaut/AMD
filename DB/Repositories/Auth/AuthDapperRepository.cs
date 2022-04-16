using DB.Context;

namespace DB.Repositories.Auth;

public class AuthDapperRepository : IAuthRepository
{
    private readonly DapperDatabaseContext _context;

    public AuthDapperRepository(DapperDatabaseContext context)
    {
        _context = context;
    }

    public Entities.Auth? GetItem(ulong id)
    {
        return null;
    }
}