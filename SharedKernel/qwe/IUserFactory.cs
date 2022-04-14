using DB.Entities;
using SharedKernel.Models;

namespace SharedKernel.qwe;

public interface IUserFactory
{
    public UserModel GetUserModel(User user);
}