using Workshop1.DependencyInjection.Interfaces;

namespace Workshop1.DependencyInjection.Operations;

public class Operation : ITransientOperation, IScopedOperation, ISingletonOperation
{
    public Guid OperationId { get; } = Guid.NewGuid();
}