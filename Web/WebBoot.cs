using Autofac;
using DB.Repositories.User;
using SharedKernel.qwe;
using SharedKernel.Services;
using Web.Controllers;

namespace Web;

public static class WebBoot
{
    public static ContainerBuilder ConfigureControllers(this ContainerBuilder container)
    {
        container.RegisterType<UserController>();
        return container;
    }
}