using DB;
using DB.Entities;
using DB.Repositories.User;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Factories;
using SharedKernel.Models;
using SharedKernel.Services;

namespace SharedKernel;

public static class ServiceBoot
{
    public static IServiceCollection ConfigureFactories(this IServiceCollection container)
    {
        container.AddTransient<IKekModel, KekModel>();
        container.AddFactory<User, UserModel>();
        return container;
    }

    public static IServiceCollection AddFactory<T1, T2>(this IServiceCollection container)
        where T1 : class
        where T2 : class, IFactory<T1>
    {
        container.AddTransient<T2>();
        container.AddSingleton<Func<T1, T2>>(serviceProvider =>
        {
            var f = serviceProvider.GetService<T2>();

            return t0 =>
            {
                f.Invoke(t0);
                return f;
            };
        });
        return container;
    }

    public static IServiceCollection ConfigureRepositories(this IServiceCollection container)
    {
        container.AddScoped<IUserService, SimpleUserService>();
        container.AddScoped<IUserRepository, EfUserRepository>();
        container.AddScoped<IMainContext, MainContext>();
        //container.AddScoped<DapperDatabaseContext>();
        container.AddDbContext<EfDatabaseContext>();
        return container;
    }
}