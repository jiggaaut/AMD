using DB.Entities;
using DB.Repositories.User;
using SharedKernel.Models;
using SharedKernel.qwe;

namespace SharedKernel.Services;

public class SimpleUserService : IUserService
{
    private readonly IUserFactory _userFactory;
    private readonly IUserRepository _userRepository;

    /*
    public SimpleUserService()
    {
        _userFactory = new UserFactory();
    }
    */

    public SimpleUserService(IUserFactory userFactory, IUserRepository userRepository)
    {
        _userFactory = userFactory;
        _userRepository = userRepository;
    }
    
    public UserModel GetUser(ulong id)
    {
        var user = _userRepository.GetItem(id);
        if (user == null) return new UserModel();
        
        var userModel = _userFactory.GetUserModel(user);
        return userModel;
    }
}