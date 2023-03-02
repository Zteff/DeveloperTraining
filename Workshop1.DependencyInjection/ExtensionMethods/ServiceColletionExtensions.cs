using Workshop1.DependencyInjection.Features;
using Workshop1.DependencyInjection.Interfaces;

namespace Workshop1.DependencyInjection.ExtensionMethods;

public static class ServiceColletionExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {   
        services.AddTransient<ITransientOperation, Operation>();
        services.AddScoped<IScopedOperation, Operation>();
        services.AddSingleton<ISingletonOperation, Operation>();
        services.AddScoped<ISomeBusinessLogicService, SomeBusinessLogicService>();
        services.AddSingleton<IMemoryHeavy, MemHeavyComponent>();
        return services;
    }
}