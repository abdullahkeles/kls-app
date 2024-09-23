
using Microsoft.Extensions.DependencyInjection;
using Shared.DAL;
using Shared.Helpers.Constants.AppSettings;

namespace Shared;

public static class ModuleExtensions
{
    public static IServiceCollection AddSharedModule(this IServiceCollection services)
    {
        services.AddSingleton<IKlsAppContext, KlsAppContext>();
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        return services;
    }
}
