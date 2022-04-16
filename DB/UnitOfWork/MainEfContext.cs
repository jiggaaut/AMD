using DB.Context;
using DB.Repositories.Auth;
using DB.Repositories.User;

namespace DB.UnitOfWork;

public class MainEfContext : IMainContext
{
    private readonly EfDatabaseContext _context;

    public MainEfContext(EfDatabaseContext context)
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
            return _users ??= new UserEfRepository(_context);
        }
    }

    private IAuthRepository? _auths;

    public IAuthRepository Auths
    {
        get
        {
            return _auths ??= new AuthEfRepository(_context);
        }
    }
}