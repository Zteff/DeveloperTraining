using Workshop1.DependencyInjection.Interfaces;

namespace Workshop1.DependencyInjection.Features;

public class Operation : ITransientOperation, IScopedOperation, ISingletonOperation
{
    public Guid OperationId { get; } = Guid.NewGuid();
}