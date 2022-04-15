using DB.Context;
using DB.Repositories.User;

namespace DB;

public class MainContext : IMainContext
{
    public const string ConnectionString = "server=localhost;user=root;password=root;database=amd;";
    private readonly DapperDatabaseContext _context;

    public MainContext(DapperDatabaseContext context, IUserRepository userRepository)
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