using SharedKernel.Models;

namespace SharedKernel.Services;

public interface IUserService
{
    public UserModel GetUser(ulong id);
}