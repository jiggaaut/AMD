using Autofac;
using DB.Repositories.User;
using Microsoft.Extensions.Logging;
using SharedKernel.Services;

namespace SharedKernel;

public static class ServiceBoot
{
    public static ContainerBuilder ConfigureServices(this ContainerBuilder container)
    {
        // Register individual components
        container.RegisterInstance(new DapperUserRepository())
            .As<IUserRepository>();
        container.RegisterInstance(new SimpleUserService())
            .As<IUserService>();
        //builder.Register(c => new LogManager(DateTime.Now))
        //    .As<ILogger>();

        return container;
    }
}