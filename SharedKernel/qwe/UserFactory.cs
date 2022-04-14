using DB.Entities;
using SharedKernel.Models;

namespace SharedKernel.qwe;

public class UserFactory : IUserFactory
{
    public UserModel GetUserModel(User user)
    {
        var userModel = new UserModel
        {
            ID = user.ID,
            Login = user.Login,
            Type = user.Type,
        };

        return userModel;
    }
}