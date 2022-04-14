using DB.Entities;
using SharedKernel.Models;
using SharedKernel.qwe;

namespace SharedKernel.Services;

public class SimpleUserService : IUserService
{
    private readonly IUserFactory _userFactory;

    /*
    public SimpleUserService()
    {
        _userFactory = new UserFactory();
    }
    */

    public SimpleUserService(IUserFactory userFactory)
    {
        _userFactory = userFactory;
    }
    
    public UserModel GetUser(ulong id)
    {
        var user = new User
        {
            ID = id
        };
        var userModel = _userFactory.GetUserModel(user);

        return userModel;
    }
}