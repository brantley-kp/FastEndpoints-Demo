using FastEndpoints;

namespace FastEndpointsDemo.Api.Endpoints.Cats;

public class GetRequest
{
    [BindFrom("id")]
    public required Guid Id { get; set; }
}
