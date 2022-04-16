using DB.Context;
using DB.Repositories.Auth;
using DB.Repositories.User;

namespace DB.UnitOfWork;

//[Obsolete]
public class MainContext : IMainContext
{
    public const string ConnectionString = "server=localhost;user=root;password=root;database=amd;";
    private readonly DbFactory _dbFactory;
    private readonly Func<IUserRepository> _func;

    public MainContext(DbFactory dbFactory, IUserRepository userRepository, IAuthRepository authRepository, Func<IUserRepository> func)
    {
        _dbFactory = dbFactory;
        //Users = userRepository;
        Auths = authRepository;
        _func = func;
    }

    //public IUserRepository Users { get; }

    public IAuthRepository Auths { get; }

    private IUserRepository? _us;

    public IUserRepository Users
    {
        get
        {
            return _us ??= _func.Invoke();
        }
    }

    public IUserRepository Us
    {
        get
        {
            return _us ??= new UserEfRepository(_dbFactory.DbContext);
        }
    }
    
    public void Dispose()
    {
        _dbFactory.Dispose();
        GC.SuppressFinalize(this);
    }
}