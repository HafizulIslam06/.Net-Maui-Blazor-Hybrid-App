using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Uapp.Services.Auth;
using Uapp.Services.Dropdowns;

namespace Uapp.Services;

public static class ServiceCollectionExtensions
{
    //public static IServiceCollection AddServiceModule(this IServiceCollection services, IConfiguration configuration)
    //{
    //    //services.AddScoped<IAuthService, AuthService>();
    //    services.AddTransient<IUniversityCountryService, UniversityCountryService>();
    //    //services.AddScoped<INameTitleService, NameTitleService>();

    //    return services;
    //}
    public static IServiceCollection AddClientServices(this IServiceCollection services)
    {
        RegisterTypeServices(services, typeof(IBaseService));

        return services;
    }
    private static void RegisterTypeServices(IServiceCollection services, Type type)
    {
        var implementations = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => type.IsAssignableFrom(p) && p.IsInterface && p != type);

        foreach (var implementation in implementations)
        {
            var implementedTypes = AppDomain.CurrentDomain.GetAssemblies()
                   .SelectMany(s => s.GetTypes())
                   .Where(p => implementation.IsAssignableFrom(p) && !p.IsAbstract);

            foreach (var gen in implementedTypes)
            {
                services.AddTransient(implementation, gen);

            }
        }
    }
}
