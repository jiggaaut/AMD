﻿using DB;
using DB.Context;
using DB.Entities;
using DB.Repositories.User;
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

    public static void ConfigureDatabase(this IServiceCollection container)
    {
        container.AddScoped<IMainContext, MainContext>();
        container.ConfigureDapper();
        //container.ConfigureEf();
    }

    public static void ConfigureServices(this IServiceCollection container)
    {
        container.AddScoped<IUserService, SimpleUserService>();
    }

    private static void ConfigureEf(this IServiceCollection container)
    {
        //container.AddScoped<IContext, EfDatabaseContext>();
        container.AddDbContext<EfDatabaseContext>();
        container.AddScoped<IUserRepository, EfUserRepository>();
    }

    private static void ConfigureDapper(this IServiceCollection container)
    {
        //container.AddScoped<IContext, DapperDatabaseContext>();
        container.AddScoped<DapperDatabaseContext>();
        container.AddScoped<IUserRepository, DapperUserRepository>();
    }
    
    private static void AddFactory<T1, T2>(this IServiceCollection container)
        where T1 : class
        where T2 : class, IFactory<T1>
    {
        container.AddTransient<T2>();
        container.AddSingleton<Func<T1, T2>>(serviceProvider =>
        {
            var f = serviceProvider.GetService<T2>();

            return t0 =>
            {
                f!.Invoke(t0);
                return f;
            };
        });
    }
}