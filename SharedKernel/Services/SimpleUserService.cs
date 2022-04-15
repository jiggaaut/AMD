using DB;
using DB.Entities;
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

        var qq = _userFactory.Invoke(user);
        return qq;
    }
}