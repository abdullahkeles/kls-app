
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace Shared.Helpers.Extensions;
// Repository sınıflarını otomatik kaydetmek için extension method yazalım
public static class ServiceCollectionExtensions
{
    public static void AddRepositoriesAndServices(this IServiceCollection services)
    {

        var assembly = Assembly.GetCallingAssembly(); // çağrılan assembly taraması
        var types = assembly.GetTypes()
            .Where(t => (t.Name.EndsWith("Repository") || t.Name.EndsWith("Service")) && t.IsClass && !t.IsAbstract)
            .ToList();

        foreach (var implementationType in types)
        {
            var interfaceType = implementationType.GetInterface($"I{implementationType.Name}");
            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, implementationType);
            }
        }
    }
}