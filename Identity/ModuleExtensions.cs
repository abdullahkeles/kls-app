using System;
using Identity.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Constants;
using Shared.Extensions;

namespace Identity;

public static class ModuleExtensions
{
    public static IServiceCollection AddIdentityModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseContext<IdentityContext>(ChosenDatabaseCnst.Sqlite, configuration);

        return services;
    }

}
