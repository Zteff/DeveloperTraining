using Workshop1.DependencyInjection.Features;
using Workshop1.DependencyInjection.Interfaces;

namespace Workshop1.DependencyInjection.ExtensionMethods;

public static class IocExtensionMethods
{
    public static IServiceCollection AddOperations(this IServiceCollection services)
    {
        services.AddTransient<ITransientOperation, Operation>();
        services.AddScoped<IScopedOperation, Operation>();
        services.AddSingleton<ISingletonOperation, Operation>();
        return services;
    }
}