namespace FastEndpointsDemo.Api.Endpoints.Dogs;

public class GetResponse
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public required bool IsGood { get; set; }
}
