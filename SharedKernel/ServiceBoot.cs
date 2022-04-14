using Autofac;
using DB.Repositories.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharedKernel.qwe;
using SharedKernel.Services;

namespace SharedKernel;

public static class ServiceBoot
{
    public static ContainerBuilder ConfigureServices(this ContainerBuilder container)
    {
        // Register individual components
        container.RegisterType<UserFactory>().As<IUserFactory>();
        container.RegisterType<SimpleUserService>();
        container.RegisterType<SimpleUserService>().As<IUserService>();
        container.RegisterInstance(new DapperUserRepository())
            .As<IUserRepository>();
        //container.RegisterInstance(new SimpleUserService(new UserFactory())).As<IUserService>();
        //builder.Register(c => new LogManager(DateTime.Now))
        //    .As<ILogger>();

        return container;
    }
    
    public static IServiceCollection ConfigureServices(this IServiceCollection container)
    {
        container.AddSingleton<IUserFactory, UserFactory>();
        container.AddScoped<IUserService, SimpleUserService>();
        container.AddScoped<IUserRepository, DapperUserRepository>();
        return container;
    }
}