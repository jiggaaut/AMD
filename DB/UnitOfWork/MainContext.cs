using DB.Repositories.Auth;
using DB.Repositories.User;
using Microsoft.Extensions.DependencyInjection;

namespace DB.UnitOfWork;

public class MainContext : IMainContext
{
    public const string ConnectionString = "server=192.168.88.254;user=root;password=root;database=amd;";

    //private readonly DbFactory _dbFactory;
    private readonly IServiceProvider _container;

    public MainContext(IServiceProvider container)//DbFactory dbFactory, 
    {
        //_dbFactory = dbFactory;
        _container = container;
    }

    private IAuthRepository? _auths;
    public IAuthRepository Auths
    {
        get
        {
            return _auths ??= _container.GetRequiredService<IAuthRepository>();
        }
    }

    private IUserRepository? _users;
    public IUserRepository Users
    {
        get
        {
            return _users ??= _container.GetRequiredService<IUserRepository>();
        }
    }

    public void SaveChanges()
    {
        //_dbFactory.DbContext.SaveChanges();
    }

    public void Dispose()
    {
        //_dbFactory.Dispose();
        GC.SuppressFinalize(this);
    }
}