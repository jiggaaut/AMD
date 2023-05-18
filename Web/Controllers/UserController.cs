using Microsoft.AspNetCore.Mvc;
using SharedKernel.Models;
using SharedKernel.Services;
using System;
using Web.ViewModels;

namespace Web.Controllers;

public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public Result<UserModel> Index()
    {
        var qq = this.HttpContext.Request;
        var user = _userService.GetUser(1);
        var result = new Result<UserModel>(true, user);
        return result;
    }

}