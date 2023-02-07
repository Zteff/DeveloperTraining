using Workshop1.DependencyInjection.Interfaces;

namespace Workshop1.DependencyInjection.Features;

public class SomeBusinessLogicService : ISomeBusinessLogicService
{
    private readonly IMemoryHeavy _memoryHeavyComponent;

    public SomeBusinessLogicService(IMemoryHeavy memoryHeavyComponent)
    {
        _memoryHeavyComponent = memoryHeavyComponent;
    }

    public async Task DoStuffAsync()
    {
        await _memoryHeavyComponent.DoHeavyStuffAsync();
    }
}