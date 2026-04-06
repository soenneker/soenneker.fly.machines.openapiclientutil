using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Fly.Machines.HttpClients.Registrars;
using Soenneker.Fly.Machines.OpenApiClientUtil.Abstract;

namespace Soenneker.Fly.Machines.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class FlyMachinesOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="FlyMachinesOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddFlyMachinesOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddFlyMachinesOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IFlyMachinesOpenApiClientUtil, FlyMachinesOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="FlyMachinesOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddFlyMachinesOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddFlyMachinesOpenApiHttpClientAsSingleton()
                .TryAddScoped<IFlyMachinesOpenApiClientUtil, FlyMachinesOpenApiClientUtil>();

        return services;
    }
}
