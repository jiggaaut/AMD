using DB.Context;

namespace DB.Repositories.Auth;

public class AuthEfRepository : IAuthRepository
{
    private readonly EfDatabaseContext _context;

    public AuthEfRepository(EfDatabaseContext context)
    {
        _context = context;
    }

    public Entities.Auth? GetItem(ulong id)
    {
        if (id == 0) return null;
        
        var auth =_context.Auths.Find(id);
        return auth;
    }
}