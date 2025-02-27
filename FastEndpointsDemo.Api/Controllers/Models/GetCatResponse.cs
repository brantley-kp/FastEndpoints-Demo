namespace FastEndpointsDemo.Api.Controllers.Models;

public class GetCatResponse
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public required bool IsGood { get; set; }
}
