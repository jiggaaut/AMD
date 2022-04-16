using DB.Repositories.Auth;
using DB.Repositories.User;

namespace DB.UnitOfWork;

public interface IMainContext : IDisposable
{
    IUserRepository Users { get; }
    IAuthRepository Auths { get; }
}