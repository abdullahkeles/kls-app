using System;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Shared.BLL.Services;
using Shared.DAL;
using Shared.Helpers.Constants.AppSettings;

namespace Shared;

public static class ModuleExtensions
{
    public static IServiceCollection AddSharedModule(this IServiceCollection services)
    {
        services.AddSingleton<IKlsAppContext, KlsAppContext>();
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddTransient<IEmailSender,EmailSenderService>();
        return services;
    }
}
