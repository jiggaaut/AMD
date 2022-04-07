using System.Text.Json;
using SharedKernel.Services;

namespace Web.Controllers;

public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public string Index()
    {
        var user = _userService.GetUser(1);
        var json = JsonSerializer.Serialize(user);
        return json;
    }
}