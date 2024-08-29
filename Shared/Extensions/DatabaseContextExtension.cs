using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Constants;

namespace Shared.Extensions;

public static class DatabaseContextExtension
{
    public static IServiceCollection AddDatabaseContext<T>(this IServiceCollection services, ChosenDatabaseCnst db, IConfiguration configuration)
        where T : DbContext
    {
        switch (db)
        {
            case ChosenDatabaseCnst.PostgreSQL:
                services.AddNpgsqlKls<T>(configuration, db);
                break;
            case ChosenDatabaseCnst.Sqlite:
                services.AddSqliteKls<T>(configuration, db);
                break;
        }
        return services;
    }

    private static IServiceCollection AddSqliteKls<T>(this IServiceCollection services, IConfiguration configuration, ChosenDatabaseCnst chosenDatabase)
        where T : DbContext
    {

        services.AddDbContext<T>(m =>
            m.UseSqlite(configuration.GetConnectionString(chosenDatabase.ToString()), e => e.MigrationsAssembly(typeof(T).Assembly.FullName)));
        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<T>();
        dbContext.Database.EnsureCreated();
        return services;
    }

    private static IServiceCollection AddNpgsqlKls<T>(this IServiceCollection services, IConfiguration configuration, ChosenDatabaseCnst chosenDatabase)
        where T : DbContext
    {
        services.AddDbContext<T>(m =>
            m.UseNpgsql(configuration.GetConnectionString(chosenDatabase.ToString()), e => e.MigrationsAssembly(typeof(T).Assembly.FullName)));
        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<T>();
        dbContext.Database.EnsureCreated();
        return services;
    }
}
