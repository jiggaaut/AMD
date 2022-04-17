using System.Runtime.InteropServices.ComTypes;
using DB;
using DB.Context;
using DB.Entities;
using DB.Repositories;
using DB.Repositories.Auth;
using DB.Repositories.User;
using DB.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Factories;
using SharedKernel.Models;
using SharedKernel.Services;

namespace SharedKernel;

public static class ServiceBoot
{
    public static void ConfigureFactories(this IServiceCollection container)
    {
        container.AddTransient<IKekModel, KekModel>();
        container.AddFactory<User, UserModel>();
    }

    public static void ConfigureServices(this IServiceCollection container)
    {
        container.AddScoped<IUserService, SimpleUserService>();
    }

    public static void ConfigureDatabase(this IServiceCollection container)
    {
        container.AddScoped<IMainContext, MainContext>();
        //container.AddScoped<DbFactory>();
        
        //container.ConfigureDapper();
        container.ConfigureEf();
    }

    private static void AddRepository<T1, T2>(this IServiceCollection container)
        where T1 : class
        where T2 : class, T1
    {
        container.AddScoped<Func<T1>>(e => e.GetRequiredService<T1>);
        container.AddScoped<T1, T2>();
    }

    private static void ConfigureEf(this IServiceCollection container)
    {
        container.AddDbContext<EfDatabaseContext>();
        //container.AddScoped<Func<EfDatabaseContext>>(provider => provider.GetRequiredService<EfDatabaseContext>);
        container.AddScoped<IUserRepository, UserEfRepository>();
        container.AddScoped<IAuthRepository, AuthEfRepository>();
    }

    private static void ConfigureDapper(this IServiceCollection container)
    {
        container.AddScoped<DapperDatabaseContext>();
        //container.AddScoped<Func<DapperDatabaseContext>>(provider => provider.GetRequiredService<DapperDatabaseContext>);
        container.AddScoped<IUserRepository, UserDapperRepository>();
        container.AddScoped<IAuthRepository, AuthDapperRepository>();
    }
    
    private static void AddFactory<T1, T2>(this IServiceCollection container)
        where T1 : class
        where T2 : class, IFactory<T1>
    {
        container.AddTransient<T2>();
        container.AddSingleton<Func<T1, T2>>(serviceProvider =>
        {
            var f = serviceProvider.GetRequiredService<T2>();

            return t0 =>
            {
                f.Invoke(t0);
                return f;
            };
        });
    }
}