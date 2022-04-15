namespace DB.Repositories.User;
using Entities;

public class EfUserRepository : IUserRepository
{
    private readonly EfDatabaseContext _context;
    public EfUserRepository()
    {
        _context = new EfDatabaseContext();
    }
    public User? GetItem(ulong id)
    {
        var user = _context.Users.Find(id);
        return user;
    }
}