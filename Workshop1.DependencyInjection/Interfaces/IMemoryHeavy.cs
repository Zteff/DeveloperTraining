namespace Workshop1.DependencyInjection.Interfaces;

public interface IMemoryHeavy
{
    Task<bool> DoHeavyStuffAsync();
}