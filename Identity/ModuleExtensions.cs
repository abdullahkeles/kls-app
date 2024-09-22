using System;
using System.Reflection;
using System.Security.Cryptography.Xml;
using Identity.BLL.Auth;
using Identity.DAL;
using Identity.DAL.Users;
using Identity.Helpers.Constants.JwtSettings;
using Identity.Helpers.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.DAL;
using Shared.Helpers.Constants;
using Shared.Helpers.Extensions;

namespace Identity;

public static class ModuleExtensions
{
    public static IServiceCollection AddIdentityModule(this IServiceCollection services, IConfiguration configuration)
    {
        IJwtContext jwtContext = new JwtContext(configuration);
        services.AddSingleton<IJwtContext, JwtContext>();
        services.AddAuthenticationJwt(jwtContext);
        services.AddDatabaseContext<KlsIdentityDbContext>(ChosenDatabaseCnst.PostgreSQL, configuration);
        services.AddDatabaseContext<IdentityDbContext>(ChosenDatabaseCnst.PostgreSQL, configuration);
        services.AddKeyedScoped<IUnitOfWork, IdentityUnitOfWork>("uowIdentity");
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // web api projesinden çağırıp hepsi tek hamlede eklenebilir.
        services.AddRepositoriesAndServices();
        return services;
    }

}
