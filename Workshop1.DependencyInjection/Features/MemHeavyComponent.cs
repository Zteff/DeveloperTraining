using Workshop1.DependencyInjection.Interfaces;

namespace Workshop1.DependencyInjection.Features;

public class MemHeavyComponent : IMemoryHeavy
{
    public Task<bool> DoHeavyStuffAsync()
    {
        return Task.FromResult(true);
    }
}