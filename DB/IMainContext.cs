using DB.Repositories.User;

namespace DB;

public interface IMainContext : IDisposable
{
    IUserRepository Users { get; }
}