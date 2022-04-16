using DB.Context;
using DB.Repositories.Auth;
using DB.Repositories.User;

namespace DB.UnitOfWork;

//[Obsolete]
public class MainContext : IMainContext
{
    public const string ConnectionString = "server=localhost;user=root;password=root;database=amd;";
    private readonly EfDatabaseContext _context;

    public MainContext(EfDatabaseContext context)//, IUserRepository userRepository, IAuthRepository authRepository
    {
        _context = context;
        //Users = userRepository;
        //Auths = authRepository;
    }

    public IUserRepository Users { get; }
    public IAuthRepository Auths { get; }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}