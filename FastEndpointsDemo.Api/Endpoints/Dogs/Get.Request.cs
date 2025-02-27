using FastEndpoints;

namespace FastEndpointsDemo.Api.Endpoints.Dogs;

public class GetRequest
{
    [BindFrom("id")]
    public required Guid Id { get; set; }
}
