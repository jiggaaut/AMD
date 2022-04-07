using DB.Entities;

namespace SharedKernel.Services;

public interface IUserService
{
    public User GetUser(ulong id);
}