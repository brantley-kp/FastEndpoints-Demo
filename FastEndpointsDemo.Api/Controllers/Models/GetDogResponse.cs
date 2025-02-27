namespace FastEndpointsDemo.Api.Controllers.Models;

public class GetDogResponse
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public required bool IsGood { get; set; }
}
