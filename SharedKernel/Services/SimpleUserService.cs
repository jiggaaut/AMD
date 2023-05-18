using DB.Entities;
using DB.UnitOfWork;
using SharedKernel.Models;

namespace SharedKernel.Services;

public class SimpleUserService : IUserService
{
    private readonly Func<User, UserModel> _userFactory;
    private readonly IMainContext _mainContext;

    public SimpleUserService(IMainContext mainContext,
        Func<User, UserModel> userFactory)
    {
        _userFactory = userFactory;
        _mainContext = mainContext;
    }
    
    public UserModel GetUser(ulong id)
    {
        var user = _mainContext.Users.GetItem(id);
        if (user == null) return null;

        var auth = _mainContext.Auths.GetItem(1);
        var userModel = _userFactory.Invoke(user);
        return userModel;
    }
}