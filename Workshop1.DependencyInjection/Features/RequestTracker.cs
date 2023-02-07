using Workshop1.DependencyInjection.Interfaces;

namespace Workshop1.DependencyInjection.Features;

public class RequestTracker : IRequestTracker
{
    private readonly IMemoryHeavy _memoryHeavyComponent;
    public Guid RequestGuid { get; } 

    public RequestTracker(IMemoryHeavy memoryHeavyComponent)
    {
        RequestGuid = Guid.NewGuid();
        _memoryHeavyComponent = memoryHeavyComponent;
    }
}