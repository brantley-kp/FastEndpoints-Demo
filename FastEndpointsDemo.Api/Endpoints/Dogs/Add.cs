using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointsDemo.Application.Commands;
using MediatR;

namespace FastEndpointsDemo.Api.Endpoints.Dogs;

public class Add(ISender sender) : Endpoint<AddRequest, AddResponse>
{
    public override void Configure()
    {
        Post("/endpoints/dogs/add");
        AllowAnonymous();
        Description(x => x.AutoTagOverride("Dogs Endpoints"));
    }

    public override async Task HandleAsync(AddRequest req, CancellationToken _)
    {
        var command = new AddDogCommand(req.Name);

        var id = await sender.Send(command);

        await SendAsync(new() { Id = id });
    }
}
