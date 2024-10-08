﻿namespace NewTest.Context.Seeder;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    /// <summary>
    /// Register db seeder
    /// </summary>
    public static IServiceCollection AddDbSeeder(this IServiceCollection services, IConfiguration configuration = null)
    {
        return services;
    }
}