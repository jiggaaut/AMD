namespace DB.Repositories.User;
using Entities;

public interface IUserRepository
{
    public User? GetItem(ulong id);
}