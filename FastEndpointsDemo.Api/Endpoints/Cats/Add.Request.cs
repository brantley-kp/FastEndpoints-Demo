namespace FastEndpointsDemo.Api.Endpoints.Cats;

public class AddRequest
{
    public required string Name { get; set; }

    public required bool IsGood { get; set; }
}
