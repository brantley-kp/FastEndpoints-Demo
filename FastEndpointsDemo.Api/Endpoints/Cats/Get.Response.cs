namespace FastEndpointsDemo.Api.Endpoints.Cats;

public record GetResponse
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public required bool IsGood { get; set; }
}
