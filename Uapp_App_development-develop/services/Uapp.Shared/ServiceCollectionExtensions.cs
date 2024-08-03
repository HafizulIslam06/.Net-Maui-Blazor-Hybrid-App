using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Uapp.Shared.Core.Services.auth;
using Uapp.Shared.Http;
using Uapp.Shared.States;

namespace Uapp.Shared;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(typeof(IHttpClientService<,>), typeof(HttpClientService<,>));
        services.AddTransient(typeof(IHttpService), typeof(HttpService));
        services.AddTransient<ITokenStorageService, TokenStorageService>();
        services.AddTransient<IUserStorageService, UserStorageService>();


        return services;
    }
    public static IServiceCollection AddPageState(this IServiceCollection services)
    {
        RegisterTypeServices(services, typeof(IBaseState));

        return services;
    }
    private static void RegisterTypeServices(IServiceCollection services, Type type)
    {
        var implementations = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => type.IsAssignableFrom(p) && p.IsClass && p != type);

        foreach (var imp in implementations)
        {
            services.AddSingleton(imp);
        }
    }
}
