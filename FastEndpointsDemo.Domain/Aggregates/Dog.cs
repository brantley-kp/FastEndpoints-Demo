namespace FastEndpointsDemo.Domain.Aggregates;

public record Dog(Guid Id, string Name)
{
    public bool IsGood { get; } = true;
}
