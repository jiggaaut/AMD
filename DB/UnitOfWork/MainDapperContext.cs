using DB.Context;
using DB.Repositories.Auth;
using DB.Repositories.User;

namespace DB.UnitOfWork;

public class MainDapperContext : IMainContext
{
    private readonly DapperDatabaseContext _context;

    public MainDapperContext(DapperDatabaseContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    private IUserRepository? _users;

    public IUserRepository Users
    {
        get
        {
            return _users ??= new UserDapperRepository(_context);
        }
    }

    private IAuthRepository? _auths;

    public IAuthRepository Auths
    {
        get
        {
            return _auths ??= new AuthDapperRepository(_context);
        }
    }
}