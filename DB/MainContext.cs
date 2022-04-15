using DB.Repositories.User;

namespace DB;

public class MainContext : IMainContext
{
    private readonly EfDatabaseContext _context;

    public MainContext(EfDatabaseContext context, IUserRepository userRepository)
    {
        _context = context;
        Users = userRepository;
    }

    public IUserRepository Users { get; }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}