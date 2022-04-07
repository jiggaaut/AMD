using DB.Entities;

namespace SharedKernel.Services;

public class SimpleUserService : IUserService
{
    public User GetUser(ulong id)
    {
        var user = new User();
        user.ID = id;
        return user;
    }
}