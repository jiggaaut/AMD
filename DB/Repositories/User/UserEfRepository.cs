using DB.Context;

namespace DB.Repositories.User;

public class UserEfRepository : IUserRepository
{
    private readonly EfDatabaseContext _context;

    public UserEfRepository(EfDatabaseContext context)
    {
        _context = context;
    }

    public Entities.User? GetItem(ulong id)
    {
        var user = _context.Users.Find(id);
        return user;
    }
}